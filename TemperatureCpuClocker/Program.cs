using System.Linq;
using System.Threading;
using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using CpuTempClockerLib.Managers;

namespace CpuTempClockerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            CPUClockOrchestrator clockOrchestrator = new CPUClockOrchestrator(new CPUOrchestratorSettings {
                PowerWriteType = PowerType.AC | PowerType.DC,
                TargetCPUTemperature = 48,
                PowerScheme = new PowerSchemesManager().GetPowerSchemes().Where(powerScheme => powerScheme.IsActive).SingleOrDefault()
            });

            while (true)
            {
                CPUReading reading = clockOrchestrator.DoCycle();
                Console.WriteLine($"Temp: {reading.Temperature}, Change: {reading.TemperatureFluctuationType}, Percentage: {reading.ProcessorState}");
                Thread.Sleep(25);
            }
        }
    }
}
