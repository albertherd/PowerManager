using System.Linq;
using System.Threading;
using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using CpuTempClockerLib.Managers;
using System.Collections.Generic;

namespace CpuTempClockerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            CPUClockOrchestrator clockOrchestrator = ParseArgs(args);

            while (true)
            {
                CPUReading reading = clockOrchestrator.DoCycle();
                Console.WriteLine($"Temp: {reading.Temperature}, Change: {reading.TemperatureFluctuationType}, Percentage: {reading.ProcessorState}");
                Thread.Sleep(25);
            }
        }

        private static CPUClockOrchestrator ParseArgs(string[] args)
        {
            CPUOrchestratorSettings orchestratorSettings = new CPUOrchestratorSettings();

            orchestratorSettings.TargetCPUTemperature = GetIntValue(args, TargetTemperature);
            orchestratorSettings.ProcessorStateSettings = new ProcessorStateSettings(GetIntValue(args, MinimumProcessorState), GetIntValue(args, MaximumProcessorState));

            if (args.Contains(PowerTypeAc))
            {
                orchestratorSettings.PowerWriteType = orchestratorSettings.PowerWriteType | PowerType.AC;
            }

            if (args.Contains(PowerTypeDc))
            {
                orchestratorSettings.PowerWriteType = orchestratorSettings.PowerWriteType | PowerType.DC;
            }

            if(args.Contains(UseActivePowerScheme))
            {
                orchestratorSettings.PowerScheme = new PowerSchemesManager().GetPowerSchemes().Where(powerScheme => powerScheme.IsActive).SingleOrDefault();
            }
            else if(args.Contains(PowerScheme))
            {
                string powerSchemeValue = GetStringValue(args, PowerScheme);
                orchestratorSettings.PowerScheme = new PowerSchemesManager().GetPowerSchemes().Where(powerScheme => powerScheme.FriendlyName.Contains(powerSchemeValue)).SingleOrDefault();
                if(orchestratorSettings.PowerScheme == null)
                {
                    ShowUsage();
                    return null;
                }
            }
            else
            {
                ShowUsage();
                return null;
            }

            if(args.Contains(CPUSensorIndex))
            {
                int index = GetIntValue(args, CPUSensorIndex);
                IEnumerable<CPUSensorCollection> sensors = new CPUSensorsManager().GetCPUSensors();
                if((index + 1) > sensors.Count())
                {
                    ShowUsage();
                    return null;
                }
                orchestratorSettings.SensorCollection = new CPUSensorsManager().GetCPUSensors().ElementAt(index);
            }
            else
            {
                orchestratorSettings.SensorCollection = new CPUSensorsManager().GetCPUSensors().FirstOrDefault();
            }

            return new CPUClockOrchestrator(orchestratorSettings);
        }

        private static int GetIntValue(string[] args, string key)
        {
            return GetValueInternal(args, key, (value) =>
            {
                int result;
                if (!int.TryParse(value, out result))
                {
                    ShowUsage();
                    return -1;
                }
                return result;
            });
        }

        private static string GetStringValue(string[] args, string key)
        {
            return GetValueInternal(args, key, (value) => value);
        }

        private static T GetValueInternal<T>(string[] args, string key, Func<string, T> parseFunc)
        {
            int result = -1;
            int pos = Array.IndexOf(args, key);
            if (pos > 0)
            {
                int targetTemperatureValuePosition = pos + 1;
                if (targetTemperatureValuePosition + 1 >= args.Length)
                {
                    ShowUsage();
                    return default(T);
                }

                return parseFunc(args[targetTemperatureValuePosition]);
            }
            else
            {
                ShowUsage();
                return default(T);
            }
        }

        private static void ShowUsage()
        {
            throw new Exception("Error");
        }

        private const string PowerTypeAc = "PowerTypeAc";
        private const string PowerTypeDc = "PowerTypeDc";
        private const string TargetTemperature = "TargetTemperature";
        private const string MinimumProcessorState = "MinimumProcessorState";
        private const string MaximumProcessorState = "MaximumProcessorState";
        private const string UseActivePowerScheme = "UseActivePowerScheme";
        private const string PowerScheme = "PowerScheme";
        private const string CPUSensorIndex = "CPUSensorIndex";
    }
}
