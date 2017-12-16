using CpuTempClockerLib.Enums;

namespace CpuTempClockerLib.Models
{
    public class CPUOrchestratorSettings
    {
        public int TargetCPUTemperature { get; set; }
        public PowerType PowerWriteType { get; set; }
        public PowerScheme PowerScheme { get; set; }
        public ProcessorStateSettings ProcessorStateSettings { get; set; }
    }
}
