using System.Threading;
using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;

namespace CpuTempClockerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            CPUClockOrchestrator clockOrchestrator = new CPUClockOrchestrator(new CpuOrchestratorSettings { PowerWriteType = PowerWriteType.AC | PowerWriteType.DC, TargetCPUTemperature = 48 });

            while (true)
            {
                CPUReading reading = clockOrchestrator.DoCycle();
                Console.WriteLine($"Temp: {reading.Temperature}, Change: {reading.TemperatureFluctuationType}, Percentage: {reading.ProcessorState}");
                Thread.Sleep(250);
            }
        }
    }
}
