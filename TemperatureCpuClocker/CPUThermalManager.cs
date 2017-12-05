using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public class CPUThermalManager : IDisposable
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

            List<ISensor> sensors = _thermalSensors.Where(sensor => sensor.Name.Contains("Package")).ToList();
            if(!sensors.Any())
            {
                MainThermalSensor = _thermalSensors.FirstOrDefault();
            }
            if(sensors.Count == 1)
            {
                MainThermalSensor = sensors.First();
            }
            else if(sensors.Count > 1)
            {
                ISensor firstSensor = sensors.Where(sensor => sensor.Name.Contains("1")).FirstOrDefault();
                if(firstSensor != null)
                {
                    MainThermalSensor = firstSensor;
                }
                else
                {
                    MainThermalSensor = sensors.FirstOrDefault();
                }
            }            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _computer.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CPUThermalManagement() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
