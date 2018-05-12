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

        private bool _disposed = false;
        private SafeHeapHandle<Guid> _guidHandleSafe;
        private int _originalCPUStateSet;
        private int _lastMaxCPUStateSet;
        
        private Guid _guid;
        private string _friendlyName;
        private PowerType _powerType;

        public Guid Guid { get => _guid;}
        public string FriendlyName { get => _friendlyName;}
        public PowerType CurrentPowerType { get => _powerType; }

        internal PowerScheme(SafeHeapHandle<Guid> schemeGuid, string friendlyName)
        {
            _guidHandleSafe = schemeGuid;
            _guid = _guidHandleSafe.ToManagedMemory();
            _friendlyName = friendlyName;
            _powerType = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online ? PowerType.AC : PowerType.DC;
            _originalCPUStateSet = GetMaxCPUState();
        }

        public bool SetMaxCPUState(int cpuState)
        {
            if (cpuState <= 0 || cpuState > 100)
                throw new ArgumentException(nameof(cpuState));

            if (_lastMaxCPUStateSet == cpuState)
                return true;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (_powerType.HasFlag(PowerType.AC) && PowrProf.PowerWriteACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, cpuState) != ReturnCodes.ERROR_SUCCESS)
                return false;

            if (_powerType.HasFlag(PowerType.DC) && PowrProf.PowerWriteDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, cpuState) != ReturnCodes.ERROR_SUCCESS)
                return false;

            bool result = PowrProf.PowerSetActiveScheme(IntPtr.Zero, guidHandleDangerous) == ReturnCodes.ERROR_SUCCESS;

            if (result)
                _lastMaxCPUStateSet = cpuState;

            return result;
        }

        public int GetMaxCPUState()
        {
            int state = 0;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (_powerType == PowerType.AC && PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                return state;
            }

            if (_powerType == PowerType.DC && PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MAXIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                return state;
            }

            return state;
        }

        public int GetMinCPUState()
        {
            int state = 0;

            IntPtr guidHandleDangerous = _guidHandleSafe.DangerousGetHandle();

            if (_powerType == PowerType.AC && PowrProf.PowerReadACValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                return state;
            }

            if (_powerType == PowerType.DC && PowrProf.PowerReadDCValueIndex(IntPtr.Zero, guidHandleDangerous, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref User32.GUID_PROCESSOR_THROTTLE_MINIMUM, ref state) == ReturnCodes.ERROR_SUCCESS)
            {
                return state;
            }

            return state;
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _guidHandleSafe.Dispose();
                SetMaxCPUState(_originalCPUStateSet);
            }

            _disposed = true;
        }
    }
}
