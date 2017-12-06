using CpuTempClockerLib.Enums;

namespace CpuTempClockerLib.Models
{
    public class CpuOrchestratorSettings
    {
        public int TargetCPUTemperature { get; set; }
        public PowerWriteType PowerWriteType { get; set; }
    }
}
