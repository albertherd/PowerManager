using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public class CPUThermalManager
    {
        private Computer _computer = new Computer() { CPUEnabled = true };
        private List<ISensor> _thermalSensors = new List<ISensor>();

        public List<ISensor> ThermalSensors => _thermalSensors;
        public ISensor MainThermalSensor { get; set; }

        public CPUThermalManager()
        {
            _computer.Open();

            _thermalSensors = _computer.Hardware
                .Where(currentHardware => currentHardware.HardwareType == HardwareType.CPU).SelectMany(currentHardware => currentHardware.Sensors)
                .Where(currentSensor => currentSensor.SensorType == SensorType.Temperature).ToList();
        
            SetMainThermalSensorHeuristically();
        }

        public float? GetTemperature()
        {
            MainThermalSensor.Hardware.Update();
            return MainThermalSensor.Value;
        }

        private void SetMainThermalSensorHeuristically()
        {
            if (_thermalSensors == null || !_thermalSensors.Any())
                return;

            List<ISensor> packageSensors = _thermalSensors.Where(sensor => sensor.Name.Contains("Package")).ToList();
            if(!packageSensors.Any())
            {
                MainThermalSensor = _thermalSensors.FirstOrDefault();
            }
            if(packageSensors.Count == 1)
            {
                MainThermalSensor = packageSensors.First();
            }
            else if(packageSensors.Count > 1)
            {
                ISensor firstSensor = packageSensors.Where(sensor => sensor.Name.Contains("1")).FirstOrDefault();
                if(firstSensor != null)
                {
                    MainThermalSensor = firstSensor;
                }
                else
                {
                    MainThermalSensor = packageSensors.FirstOrDefault();
                }
            }            
        }
    }
}
