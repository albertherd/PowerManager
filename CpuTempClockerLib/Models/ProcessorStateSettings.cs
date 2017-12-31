using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Models
{
    public class ProcessorStateSettings
    {
        public int MinimumProcessorState { get; private set; }
        public int MaximumProcessorState { get; private set; }

        public ProcessorStateSettings(int minimumProcessorState, int maximumProcessorState)
        {
            if (minimumProcessorState < 0 || minimumProcessorState > 100)
                throw new ArgumentException(nameof(minimumProcessorState));

            if (maximumProcessorState < 0 || maximumProcessorState > 100)
                throw new ArgumentException(nameof(maximumProcessorState));

            MinimumProcessorState = minimumProcessorState;
            MaximumProcessorState = maximumProcessorState;
        }

    }
}
