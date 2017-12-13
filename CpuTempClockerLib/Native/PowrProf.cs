using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public static class PowrProf
    {
        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        public static extern UInt32 PowerReadFriendlyName(IntPtr UserRootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref int BufferSize);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerWriteACValueIndex(IntPtr HKey, IntPtr SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, int AcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerWriteDCValueIndex(IntPtr HKey, IntPtr SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, int DcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerSetActiveScheme(IntPtr UserRootPowerKey, IntPtr SchemeGuid);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern int PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingsGuid, PowerDataAccessor AccessFlags, int Index, IntPtr Buffer, ref int BufferSize);

        public enum PowerDataAccessor : uint
        {
            ACCESS_AC_POWER_SETTING_INDEX = 0,
            ACCESS_DC_POWER_SETTING_INDEX = 1,
            ACCESS_SCHEME = 16,
            ACCESS_SUBGROUP = 17,
            ACCESS_INDIVIDUAL_SETTING = 18,
            ACCESS_ACTIVE_SCHEME = 19,
            ACCESS_CREATE_SCHEME = 20
        }

    }
}
