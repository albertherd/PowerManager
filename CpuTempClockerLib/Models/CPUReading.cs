using CpuTempClockerLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Models
{
    public class CPUReading
    {
        public float Temperature { get; set; }
        public TemperatureFluctuationType TemperatureFluctuationType { get; set;}
        
        private int processorState = 100;
        public int ProcessorState
        {
            get => processorState;
            set
            {
                if(value <= 5)
                {
                    processorState = 5;
                }
                else if(value >= 100)
                {
                    processorState = 100;
                }
                else
                {
                    processorState = value;
                }
            }
        }
    }
}
