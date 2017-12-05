using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public class CPUPowerManager
    {
        private Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = Guid.Parse("54533251-82be-4824-96c1-47b60b740d00");
        private Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = Guid.Parse("BC5038F7-23E0-4960-96DA-33ABAF5935EC");

        public uint ERROR_SUCCESS;

        public bool SetCpuProcessorClockPercentage(int percentage)
        {
            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException(nameof(percentage));

            IntPtr ptrActiveSchemeGuid = IntPtr.Zero;

            if(PowrProfNative.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveSchemeGuid) != ERROR_SUCCESS)
                return false;

            if(PowrProfNative.PowerWriteACValueIndex(IntPtr.Zero, ptrActiveSchemeGuid, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS 
                || PowrProfNative.PowerWriteDCValueIndex(IntPtr.Zero, ptrActiveSchemeGuid, ref GUID_PROCESSOR_SETTINGS_SUBGROUP, ref GUID_PROCESSOR_THROTTLE_MAXIMUM, percentage) != ERROR_SUCCESS)
            {
                PowrProfNative.LocalFree(ptrActiveSchemeGuid);
                return false;
            }

            bool result = PowrProfNative.PowerSetActiveScheme(IntPtr.Zero, ptrActiveSchemeGuid) == ERROR_SUCCESS;
            PowrProfNative.LocalFree(ptrActiveSchemeGuid);
            return result;
        }
    
    }
}
