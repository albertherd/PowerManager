using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpuTempClockerLib.Managers;

namespace CpuTempClockerLib
{
    public class TemperatureTargetedPowerMode
    {
        private readonly float TargetTemperature;
        private readonly PowerType PowerWriteType;
        private readonly CPUReading _previousReading;
        private readonly CPUReading _currentReading;
        private readonly PowerScheme _powerScheme;
        private readonly CPUSensorCollection _sensorCollection;

        public TemperatureTargetedPowerMode(TemperatureTargetedPowerModeSettings cpuOrchestratorSettings)
        {
            EnsureSettings(cpuOrchestratorSettings);

            TargetTemperature = cpuOrchestratorSettings.TargetCPUTemperature;
            PowerWriteType = cpuOrchestratorSettings.PowerWriteType;
            _powerScheme = cpuOrchestratorSettings.PowerScheme;
            _previousReading = new CPUReading(cpuOrchestratorSettings.ProcessorStateSettings);
            _currentReading = new CPUReading(cpuOrchestratorSettings.ProcessorStateSettings);
            _sensorCollection = cpuOrchestratorSettings.SensorCollection;
        }

        public CPUReading DoCycle()
        {
            SetCurrentCPUReadings();
            UpdateCPUClock();
            SetPreviousCPUReading();
            return _currentReading;
        }         

        private void EnsureSettings(TemperatureTargetedPowerModeSettings cpuOrchestratorSettings)
        {
            if (cpuOrchestratorSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings));

            if (cpuOrchestratorSettings.PowerScheme == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings.PowerScheme));

            if (cpuOrchestratorSettings.ProcessorStateSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings.ProcessorStateSettings));

            if (cpuOrchestratorSettings.SensorCollection == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings.SensorCollection));            
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

            _powerScheme.SetMaxCPUState(PowerWriteType, _currentReading.ProcessorState);
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
            float temperatureDelta = TargetTemperature - _currentReading.Temperature;
            return (int)((temperatureDelta * 100) / TargetTemperature);
        }
    }
}
