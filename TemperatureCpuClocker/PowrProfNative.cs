using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public static class PowrProfNative
    {
        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerWriteACValueIndex(IntPtr HKey, IntPtr SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, int AcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerWriteDCValueIndex(IntPtr HKey, IntPtr SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, int DcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true)]
        public static extern UInt32 PowerSetActiveScheme(IntPtr UserRootPowerKey, IntPtr SchemeGuid);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hMem);
    }
}
