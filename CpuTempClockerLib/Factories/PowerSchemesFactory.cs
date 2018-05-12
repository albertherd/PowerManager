using CpuTempClockerLib.Models;
using CpuTempClockerLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Factories
{
    public static class PowerSchemesFactory
    {
        private static List<PowerScheme> powerSchemes = new List<PowerScheme>();

        public static List<PowerScheme> GetPowerSchemes()
        {
            if (powerSchemes.Any())
                return new List<PowerScheme>(powerSchemes);

            List<SafeHeapHandle<Guid>> powerSchemeGuids = GetPowerSchemeGuids();

            foreach (SafeHeapHandle<Guid> guid in powerSchemeGuids)
            {
                powerSchemes.Add(new PowerScheme(guid, GetSchemeName(guid)));
            }

            return powerSchemes;
        }

        public static PowerScheme GetActivePowerScheme()
        {
            return GetPowerSchemes().FirstOrDefault(powerScheme => powerScheme.IsActive());
        }

        private static List<SafeHeapHandle<Guid>> GetPowerSchemeGuids()
        {
            List<SafeHeapHandle<Guid>> result = new List<SafeHeapHandle<Guid>>();
            IntPtr powerSchemeGuidBuffer;
            int guidSize = Marshal.SizeOf(typeof(Guid));

            int index = 0;
            int returnCode = 0;

            while (returnCode == 0)
            {
                powerSchemeGuidBuffer = Marshal.AllocHGlobal(guidSize);
                returnCode = PowrProf.PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, PowrProf.PowerDataAccessor.ACCESS_SCHEME, index, powerSchemeGuidBuffer, ref guidSize);

                if (returnCode == 259)
                    break;
                if (returnCode != 0)
                    throw new COMException("Error occurred while enumerating power schemes. Win32 error code: " + returnCode);

                result.Add(new SafeHeapHandle<Guid>(powerSchemeGuidBuffer));
                index++;
            }

            return result;
        }

        private static string GetSchemeName(SafeHeapHandle<Guid> guid)
        {
            IntPtr schemeNameGuidPtr = guid.DangerousGetHandle();

            int buffSize = 0;
            if (PowrProf.PowerReadFriendlyName(IntPtr.Zero, schemeNameGuidPtr, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref buffSize) != ReturnCodes.ERROR_SUCCESS)
                return string.Empty;

            if (buffSize == 0)
                return string.Empty;

            IntPtr schemeNamePtr = Marshal.AllocHGlobal(buffSize);
            if (PowrProf.PowerReadFriendlyName(IntPtr.Zero, schemeNameGuidPtr, IntPtr.Zero, IntPtr.Zero, schemeNamePtr, ref buffSize) != ReturnCodes.ERROR_SUCCESS)
            {
                Marshal.FreeHGlobal(schemeNamePtr);
                return string.Empty;
            }

            string schemeName = Marshal.PtrToStringUni(schemeNamePtr);
            Marshal.FreeHGlobal(schemeNamePtr);
            return schemeName;
        }
    }
}
