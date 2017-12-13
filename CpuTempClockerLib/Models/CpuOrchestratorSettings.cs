using CpuTempClockerLib.Enums;

namespace CpuTempClockerLib.Models
{
    public class CpuOrchestratorSettings
    {
        public int TargetCPUTemperature { get; set; }
        public PowerType PowerWriteType { get; set; }
        public PowerScheme PowerScheme { get; set; }
    }
}
