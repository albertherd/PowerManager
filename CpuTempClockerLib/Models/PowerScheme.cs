using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Native;
using System;
using System.Runtime.InteropServices;

namespace CpuTempClockerLib.Models
{
    public class PowerScheme : IDisposable
    {
        private static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = Guid.Parse("54533251-82BE-4824-96C1-47B60B740D00");
        private static Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = Guid.Parse("BC5038F7-23E0-4960-96DA-33ABAF5935EC");

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

            if (powerTypeFlags.HasFlag(PowerType.AC) && PowrProf.PowerWriteACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ReturnCodes.ERROR_SUCCESS)
                return false;

            if (powerTypeFlags.HasFlag(PowerType.DC) && PowrProf.PowerWriteDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ReturnCodes.ERROR_SUCCESS)
                return false;

            bool result = PowrProf.PowerSetActiveScheme(IntPtr.Zero, guidHandleDangerous) == ReturnCodes.ERROR_SUCCESS;

            if (result)
                _lastPercentageSet = percentage;

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
