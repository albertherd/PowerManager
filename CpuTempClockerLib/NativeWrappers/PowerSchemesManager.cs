using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CpuTempClockerLib.Native;

namespace CpuTempClockerLib.NativeWappers
{
    public static class User32NativeWrapper
    {
        public static IntPtr SubscribeToPowerSchemeChange(IntPtr hwnd)
        {
            return User32.RegisterPowerSettingNotification(hwnd, ref User32.GUID_POWERSCHEME_PERSONALITY, User32.DEVICE_NOTIFY_WINDOW_HANDLE);
        }
    }
}
