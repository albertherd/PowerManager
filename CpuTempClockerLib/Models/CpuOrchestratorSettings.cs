using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Managers;

namespace CpuTempClockerLib.Models
{
    public class CPUOrchestratorSettings
    {
        public int TargetCPUTemperature { get; set; }
        public PowerType PowerWriteType { get; set; }
        public PowerScheme PowerScheme { get; set; }
        public ProcessorStateSettings ProcessorStateSettings { get; set; }
        public CPUSensorCollection CPUSensorCollection { get; set; }
    }
}
