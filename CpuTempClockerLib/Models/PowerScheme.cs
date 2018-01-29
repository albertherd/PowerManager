using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Native;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CpuTempClockerLib.Models
{
    public class PowerScheme : IDisposable
    {
        private static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = Guid.Parse("54533251-82BE-4824-96C1-47B60B740D00");

        private SafeHeapHandle<Guid> _guidHandleSafe;
        private int _lastPercentageSet;

        private Guid _guid;
        private string _friendlyName;

        public Guid Guid { get => _guid;}
        public string FriendlyName { get => _friendlyName;}

        internal PowerScheme(SafeHeapHandle<Guid> schemeGuid, string friendlyName)
        {
            _guidHandleSafe = schemeGuid;
            _guid = _guidHandleSafe.ToManagedMemory();
            _friendlyName = friendlyName;
        }

        public bool SetMaxCPUState(PowerType powerTypeFlags, int percentage)
        {
            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException(nameof(percentage));

            if (_lastPercentageSet == percentage)
                return true;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (powerTypeFlags.HasFlag(PowerType.AC) && PowrProf.PowerWriteACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ReturnCodes.ERROR_SUCCESS)
                return false;

            if (powerTypeFlags.HasFlag(PowerType.DC) && PowrProf.PowerWriteDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ReturnCodes.ERROR_SUCCESS)
                return false;

            bool result = PowrProf.PowerSetActiveScheme(IntPtr.Zero, guidHandleDangerous) == ReturnCodes.ERROR_SUCCESS;

            if (result)
                _lastPercentageSet = percentage;

            return result;
        }

        public CPUStates GetCPUStates()
        {
            CPUStates result = new CPUStates();
            int state = 0;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.AcMaxPowerIndex = state;
            }

            if (PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.DcMaxPowerIndex = state;
            }

            if (PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.AcMinPowerIndex = state;
            }

            if (PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.DcMinPowerIndex = state;
            }

            result.IsOnAcPower = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline;
            result.IsOnDcPower = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online;

            return result;
        }

        public bool IsActive()
        {
            IntPtr ptrActiveSchemeGuid = IntPtr.Zero;

            if (PowrProf.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveSchemeGuid) != ReturnCodes.ERROR_SUCCESS)
                throw new COMException("Could not determine the active power scheme");

            SafeHeapHandle<Guid> activeSchemeGuidHandleSafe = new SafeHeapHandle<Guid>(ptrActiveSchemeGuid);
            bool result = activeSchemeGuidHandleSafe.Equals(_guidHandleSafe);
            activeSchemeGuidHandleSafe.Close();
            return result;            
        }

        public void Dispose()
        {
            _guidHandleSafe.Dispose();
        }
    }
}
