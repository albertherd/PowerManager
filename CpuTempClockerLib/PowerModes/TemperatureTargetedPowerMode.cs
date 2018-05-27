using CpuTempClockerLib.Models;
using System;
using CpuTempClockerLib.Managers;
using CpuTempClockerLib.PowerModes;
using CpuTempClockerLib.Factories;
using System.Windows.Forms;

namespace CpuTempClockerLib.PowerModes
{
    public class TemperatureTargetedPowerMode : ProcessorStatePowerMode
    {
        private CPUReading _previousReading;
        private CPUReading _currentReading;
        private readonly CPUSensorCollection _sensorCollection;

        private readonly Timer _timer;
        private Action<int> _onTick;
        
        private float _targetTemperature;

        public TemperatureTargetedPowerMode()
        {
            _previousReading = new CPUReading();
            _currentReading = new CPUReading();
            _sensorCollection = CPUSensorsFactory.GetCPUZeroSensor();

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += (sender, e) => { DoCycle(); _onTick(_currentReading.ProcessorState); };
        }

        public void Start(int targetTemperature, Action<int> onTick)
        {
            _targetTemperature = targetTemperature;
            _timer.Start();
            _onTick = onTick;
        }

        public void Stop()
        {
            _timer.Stop();
            _previousReading = new CPUReading();
            _currentReading = new CPUReading();
            ResetCPUStates();
            _onTick(_powerScheme.GetMaxCPUState());
        }

        public bool IsRunning()
        {
            return _timer.Enabled;
        }

        public CPUReading DoCycle()
        {
            SetCurrentCPUReadings();
            UpdateCPUClock();
            SetPreviousCPUReading();
            return _currentReading;
        }         

        private void SetPreviousCPUReading()
        {
            _previousReading.ProcessorState = _currentReading.ProcessorState;
            _previousReading.Temperature = _currentReading.Temperature;
        }

        private void UpdateCPUClock()
        {
            if (_currentReading.Temperature == _previousReading.Temperature)
                return;

           SetMaximumProcessorState(_currentReading.ProcessorState);
        }

        private void SetCurrentCPUReadings()
        {
            SetCurrentTemperature();
            SetCurrentProcessorState();
        }

        private void SetCurrentTemperature()
        {
            float? temperature = _sensorCollection.GetTemperature();
            if (temperature.HasValue)
                _currentReading.Temperature = temperature.Value;
        }

        private void SetCurrentProcessorState()
        {
            int temperturePercentageDelta = GetTemperatureDeltaPercentage();
            _currentReading.ProcessorState += temperturePercentageDelta;
        }

        private int GetTemperatureDeltaPercentage()
        {
            float temperatureDelta = _targetTemperature - _currentReading.Temperature;
            return (int)((temperatureDelta * 100) / _targetTemperature);
        }
    }
}
