using CpuTempClockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.PowerModes
{
    public class CpuUsageTargetedPowerMode
    {
        private readonly PowerScheme _powerScheme;

        public CpuUsageTargetedPowerMode(PowerScheme powerScheme)
        {
            _powerScheme = powerScheme;
        }

        public void SetCPUStates(CPUStates cpuStates)
        {
            _powerScheme.SetCPUStates(cpuStates);
        }
    }
}
