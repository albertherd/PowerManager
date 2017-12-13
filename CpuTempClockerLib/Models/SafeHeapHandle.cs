using CpuTempClockerLib.Native;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CpuTempClockerLib.Models
{
    internal sealed class SafeHeapHandle<T> : SafeBuffer, IEquatable<SafeHeapHandle<T>> where T: struct
    {
        private T _managedValue = default(T);

        internal static SafeHeapHandle<T> InvalidHandle
        {
            get
            {
                return new SafeHeapHandle<T>(IntPtr.Zero);
            }
        }

        private SafeHeapHandle() : base(true)
        {
        }

        internal SafeHeapHandle(IntPtr handle) : base(true)
        {
            Initialize<T>(1);
            SetHandle(handle);
        }
        
        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            IntPtr handle = this.handle;
            this.handle = IntPtr.Zero;
            if (handle != IntPtr.Zero)
            {
                RemoveMemoryPressure(ByteLength);
                Marshal.FreeHGlobal(handle);
            }
            return true;
        }

        public T ToManagedMemory()
        {
            if (!_managedValue.Equals(default(T)))
                return _managedValue;

            _managedValue = Marshal.PtrToStructure<T>(this.handle);

            return _managedValue;
        }

        private void RemoveMemoryPressure(ulong removedBytes)
        {
            if (removedBytes == 0)
                return;

            if (removedBytes > long.MaxValue)
            {
                GC.RemoveMemoryPressure(long.MaxValue);
                GC.RemoveMemoryPressure((long)(removedBytes - long.MaxValue));
                return;
            }
            GC.RemoveMemoryPressure((long)removedBytes);
        }

        public bool Equals(SafeHeapHandle<T> other)
        {
            return ToManagedMemory().Equals(other.ToManagedMemory());
        }
    }
}
