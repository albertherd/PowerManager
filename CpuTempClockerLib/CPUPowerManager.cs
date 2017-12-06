using CpuTempClockerLib.Enums;
using System;

namespace CpuTempClockerLib
{
    public class CPUPowerManager : IDisposable
    {
        private Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = Guid.Parse("54533251-82be-4824-96c1-47b60b740d00");
        private Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = Guid.Parse("BC5038F7-23E0-4960-96DA-33ABAF5935EC");

        private int _lastPercentageSet;

        public uint ERROR_SUCCESS;

        IntPtr ptrActiveSchemeGuid = IntPtr.Zero;

        public bool SetCpuProcessorClockPercentage(PowerWriteType powerTypeFlags, int percentage)
        {
            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException(nameof(percentage));

            if (_lastPercentageSet == percentage)
                return true;

            if(ptrActiveSchemeGuid == IntPtr.Zero && PowrProfNative.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveSchemeGuid) != ERROR_SUCCESS)
                return false;

            if(powerTypeFlags.HasFlag(PowerWriteType.AC) &&  PowrProfNative.PowerWriteACValueIndex(IntPtr.Zero, ptrActiveSchemeGuid, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS)
                return false;
            

            if (powerTypeFlags.HasFlag(PowerWriteType.DC) && PowrProfNative.PowerWriteDCValueIndex(IntPtr.Zero, ptrActiveSchemeGuid, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS)
                return false;
            

            bool result = PowrProfNative.PowerSetActiveScheme(IntPtr.Zero, ptrActiveSchemeGuid) == ERROR_SUCCESS;

            if (result)
                _lastPercentageSet = percentage;

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                PowrProfNative.LocalFree(ptrActiveSchemeGuid);
                disposedValue = true;
            }
        }

        ~CPUPowerManager() {
          Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
