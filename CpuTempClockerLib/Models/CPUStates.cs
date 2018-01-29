using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Models
{
    public class CPUStates
    {
        public int AcMinPowerIndex { get; set; }
        public int AcMaxPowerIndex { get; set; }
        public int DcMinPowerIndex { get; set; }
        public int DcMaxPowerIndex { get; set; }
        public bool IsOnAcPower { get; set; }
        public bool IsOnDcPower { get; set; }
    }
}
