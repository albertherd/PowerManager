using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Native;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CpuTempClockerLib.Models
{
    public class PowerScheme : IDisposable
    {
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

            bool result = SetCPUState(percentage, User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, powerTypeFlags);
            if (!result)
                return result;

            result = PowrProf.PowerSetActiveScheme(IntPtr.Zero, guidHandleDangerous) == ReturnCodes.ERROR_SUCCESS;

            if (result)
                _lastPercentageSet = percentage;

            return result;
        }

        public CPUStates GetCPUStates()
        {
            CPUStates result = new CPUStates();
            int state = 0;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.AcMaxPowerIndex = state;
            }

            if (PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.DcMaxPowerIndex = state;
            }

            if (PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.AcMinPowerIndex = state;
            }

            if (PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                result.DcMinPowerIndex = state;
            }

            result.IsOnAcPower = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline;
            result.IsOnDcPower = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online;

            return result;
        }

        public void SetCPUStates(CPUStates cpuStates)
        {
            SetCPUState(cpuStates.AcMaxPowerIndex, User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, PowerType.AC);
            SetCPUState(cpuStates.AcMinPowerIndex, User32.GUID_PROCESSOR_THROTTLE_MINIMUM, PowerType.AC);
            SetCPUState(cpuStates.DcMaxPowerIndex, User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, PowerType.DC);
            SetCPUState(cpuStates.DcMinPowerIndex, User32.GUID_PROCESSOR_THROTTLE_MINIMUM, PowerType.DC);
        }

        private bool SetCPUState(int percentage, Guid processorThrottleType, PowerType powerTypeFlags)
        {
            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (powerTypeFlags.HasFlag(PowerType.AC)) 
            {
                return PowrProf.PowerWriteACValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref processorThrottleType, percentage) != ReturnCodes.ERROR_SUCCESS;
            }

            if (powerTypeFlags.HasFlag(PowerType.DC))
            {
                return PowrProf.PowerWriteDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref User32.GUID_PROCESSOR_SETTINGS_SUBGROUP, ref processorThrottleType, percentage) != ReturnCodes.ERROR_SUCCESS;
            }

            return false;
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
