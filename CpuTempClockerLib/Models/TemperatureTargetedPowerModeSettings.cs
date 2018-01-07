using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Managers;
using OpenHardwareMonitor.Hardware;

namespace CpuTempClockerLib.Models
{
    public class TemperatureTargetedPowerModeSettings
    {
        public int TargetCPUTemperature { get; set; }
        public PowerType PowerWriteType { get; set; }
        public PowerScheme PowerScheme { get; set; }
        public ProcessorStateSettings ProcessorStateSettings { get; set; }
        public CPUSensorCollection SensorCollection { get; set; }
    }
}
