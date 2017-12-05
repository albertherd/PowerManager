using CpuTempClockerLib.Enums;

namespace CpuTempClockerLib.Models
{
    public class CpuOrchestratorSettings
    {
        public float TargetCPUTemperature { get; set; }
        public PowerWriteType PowerWriteType { get; set; }
    }
}
