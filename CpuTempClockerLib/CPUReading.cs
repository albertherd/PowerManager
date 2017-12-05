using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    class CPUReading
    {
        private int processorState;

        public float Temperature;
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

        public CPUReading()
        {
            ProcessorState = 100;
        }
    }
}
