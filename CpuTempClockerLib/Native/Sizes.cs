using System;
using System.Runtime.InteropServices;

namespace CpuTempClockerLib.Native
{
    public static class Sizes
    {
        public static readonly int Guid = Marshal.SizeOf(typeof(Guid));
    }
}
