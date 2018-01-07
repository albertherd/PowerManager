using System.Linq;
using System.Threading;
using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using CpuTempClockerLib.Managers;
using System.Collections.Generic;
using CpuTempClockerLib.Constants;

namespace CpuTempClockerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureTargetedPowerMode clockOrchestrator = ParseArgs(args);

            while (true)
            {
                CPUReading reading = clockOrchestrator.DoCycle();
                Console.WriteLine($"Temp: {reading.Temperature}, Change: {reading.TemperatureFluctuationType}, Percentage: {reading.ProcessorState}");
                Thread.Sleep(25);
            }
        }

        private static TemperatureTargetedPowerMode ParseArgs(string[] args)
        {
            TemperatureTargetedPowerModeSettings settings = new TemperatureTargetedPowerModeSettings();

            settings.TargetCPUTemperature = GetIntValue(args, ProgramArgs.TargetTemperature);
            settings.ProcessorStateSettings = new ProcessorStateSettings(GetIntValue(args, ProgramArgs.MinimumProcessorState), GetIntValue(args, ProgramArgs.MaximumProcessorState));

            if (args.Contains(ProgramArgs.PowerTypeAc))
            {
                settings.PowerWriteType = settings.PowerWriteType | PowerType.AC;
            }

            if (args.Contains(ProgramArgs.PowerTypeDc))
            {
                settings.PowerWriteType = settings.PowerWriteType | PowerType.DC;
            }

            if(args.Contains(ProgramArgs.UseActivePowerScheme))
            {
                settings.PowerScheme = new PowerSchemesManager().GetPowerSchemes().Where(powerScheme => powerScheme.IsActive()).SingleOrDefault();
            }
            else if(args.Contains(ProgramArgs.PowerScheme))
            {
                string powerSchemeValue = GetStringValue(args, ProgramArgs.PowerScheme);
                settings.PowerScheme = new PowerSchemesManager().GetPowerSchemes().Where(powerScheme => powerScheme.FriendlyName.Contains(powerSchemeValue)).SingleOrDefault();
                if(settings.PowerScheme == null)
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

            if(args.Contains(ProgramArgs.CPUSensorIndex))
            {
                int index = GetIntValue(args, ProgramArgs.CPUSensorIndex);
                IEnumerable<CPUSensorCollection> sensors = new CPUSensorsManager().GetCPUSensors();
                if((index + 1) > sensors.Count())
                {
                    ShowUsage();
                    return null;
                }
                settings.SensorCollection = new CPUSensorsManager().GetCPUSensors().ElementAt(index);
            }
            else
            {
                settings.SensorCollection = new CPUSensorsManager().GetCPUSensors().FirstOrDefault();
            }

            return new TemperatureTargetedPowerMode(settings);
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
    }
}
