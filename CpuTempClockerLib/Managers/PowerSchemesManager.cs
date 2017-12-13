﻿using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CpuTempClockerLib.Native;

namespace CpuTempClockerLib.Managers
{
    public class PowerSchemesManager
    {
        private List<PowerScheme> powerSchemes = new List<PowerScheme>();

        public List<PowerScheme> GetPowerSchemes()
        {
            if (powerSchemes.Any())
                return new List<PowerScheme>(powerSchemes);

            List<SafeHeapHandle<Guid>> powerSchemeGuids = GetPowerSchemeGuids();
            SafeHeapHandle<Guid> activePowerScheme = GetActivePowerSchemeGuid();

            foreach(SafeHeapHandle<Guid> guid in powerSchemeGuids)
            {
                bool isActive = guid.Equals(activePowerScheme);
                powerSchemes.Add(new PowerScheme(guid, GetSchemeName(guid), guid.Equals(activePowerScheme)));
            }

            return powerSchemes;
        }

        private List<SafeHeapHandle<Guid>> GetPowerSchemeGuids()
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

        private SafeHeapHandle<Guid> GetActivePowerSchemeGuid()
        {
            IntPtr ptrActiveSchemeGuid = IntPtr.Zero;

            if (PowrProf.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveSchemeGuid) != ReturnCodes.ERROR_SUCCESS)
                throw new COMException("Could not determine the active power scheme");

            return new SafeHeapHandle<Guid>(ptrActiveSchemeGuid);
        }

        private string GetSchemeName(SafeHeapHandle<Guid> guid)
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
