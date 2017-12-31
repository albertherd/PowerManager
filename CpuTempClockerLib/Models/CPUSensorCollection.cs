using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Managers
{
    public class CPUSensorCollection
    {
        private List<ISensor> _thermalSensors = new List<ISensor>();

        public List<ISensor> ThermalSensors => _thermalSensors;
        public ISensor PackageSensor { get; set; }

        internal CPUSensorCollection(IHardware hardware)
        {
            _thermalSensors = hardware.Sensors
                .Where(currentSensor => currentSensor.SensorType == SensorType.Temperature).ToList();
        }

        public float? GetTemperature()
        {
            PackageSensor.Hardware.Update();
            return PackageSensor.Value;
        }

        public void SetThermalPackageSensor(int sensorId)
        {
            if (sensorId < -1)
                throw new ArgumentException(nameof(sensorId));

            if (sensorId + 1 > ThermalSensors.Count)
                throw new ArgumentOutOfRangeException(nameof(sensorId));

            PackageSensor = ThermalSensors.ElementAt(sensorId);
        }


        private void SetMainThermalSensorHeuristically()
        {
            if (_thermalSensors == null || !_thermalSensors.Any())
                return;

            List<ISensor> packageSensors = _thermalSensors.Where(sensor => sensor.Name.Contains("Package")).ToList();
            if (!packageSensors.Any())
            {
                PackageSensor = _thermalSensors.FirstOrDefault();
            }
            if (packageSensors.Count == 1)
            {
                PackageSensor = packageSensors.First();
            }
            else if (packageSensors.Count > 1)
            {
                ISensor firstSensor = packageSensors.Where(sensor => sensor.Name.Contains("1")).FirstOrDefault();
                if (firstSensor != null)
                {
                    PackageSensor = firstSensor;
                }
                else
                {
                    PackageSensor = packageSensors.FirstOrDefault();
                }
            }
        }
    }
}
