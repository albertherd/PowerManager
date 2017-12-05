using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace CpuTempClockerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            CPUClockOrchestrator clockOrchestrator = 
                new CPUClockOrchestrator(new CPUThermalManager(), new CPUPowerManager());

            while (true)
            {
                clockOrchestrator.DoCycle();
                Thread.Sleep(250);
            }
        }
    }
}
