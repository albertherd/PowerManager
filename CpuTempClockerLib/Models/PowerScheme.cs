using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Models
{
    public class PowerScheme : IDisposable
    {
        private static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = Guid.Parse("54533251-82be-4824-96c1-47b60b740d00");
        private static Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = Guid.Parse("BC5038F7-23E0-4960-96DA-33ABAF5935EC");

        private SafeHeapHandle<Guid> _guidHandleSafe;
        private int _lastPercentageSet;
        public uint ERROR_SUCCESS;

        private Guid _guid;
        private string _friendlyName;
        private bool _isActive;

        public Guid Guid { get => _guid;}
        public string FriendlyName { get => _friendlyName;}
        public bool IsActive { get => _isActive; }

        internal PowerScheme(SafeHeapHandle<Guid> schemeGuid, string friendlyName, bool isActive)
        {
            _guidHandleSafe = schemeGuid;
            _guid = _guidHandleSafe.ToManagedMemory();
            _friendlyName = friendlyName;
            _isActive = isActive;  
        }

        public bool SetMaxCPUState(PowerType powerTypeFlags, int percentage)
        {
            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException(nameof(percentage));

            if (_lastPercentageSet == percentage)
                return true;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (powerTypeFlags.HasFlag(PowerType.AC) && PowrProf.PowerWriteACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS)
                return false;

            if (powerTypeFlags.HasFlag(PowerType.DC) && PowrProf.PowerWriteDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS)
                return false;

            bool result = PowrProf.PowerSetActiveScheme(IntPtr.Zero, guidHandleDangerous) == ERROR_SUCCESS;

            if (result)
                _lastPercentageSet = percentage;

            return result;
        }

        public void Dispose()
        {
            _guidHandleSafe.Dispose();
        }
    }
}
