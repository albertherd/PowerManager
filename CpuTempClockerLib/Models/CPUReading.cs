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
        private int _minimumProcessorState = 5;
        private int _maximumProcessorState = 100;
        private int _processorState = 100;

        public float Temperature { get; set; }
        public TemperatureFluctuationType TemperatureFluctuationType { get; set; }
        public int ProcessorState
        {
            get => _processorState;
            set
            {
                if (value <= _minimumProcessorState)
                {
                    _processorState = _minimumProcessorState;
                }
                else if (value >= _maximumProcessorState)
                {
                    _processorState = _maximumProcessorState;
                }
                else
                {
                    _processorState = value;
                }
            }
        }

        public CPUReading()
        {
        }
    }
}
