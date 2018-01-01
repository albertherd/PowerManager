using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using CpuTempClockerLib.Managers;

namespace CpuTempClockerLib
{
    public class CPUClockOrchestrator
    {
        private float TargetTemperature;
        private PowerType PowerWriteType;

        private readonly CPUReading _previousReading;
        private readonly CPUReading _currentReading;
        private readonly PowerScheme _powerScheme;
        private readonly CPUSensorCollection _cpuSensors;

        public CPUClockOrchestrator(CPUOrchestratorSettings cpuOrchestratorSettings)
        {
            EnsureCPUOrchestratorSettings(cpuOrchestratorSettings);

            TargetTemperature = cpuOrchestratorSettings.TargetCPUTemperature;
            PowerWriteType = cpuOrchestratorSettings.PowerWriteType;
            _powerScheme = cpuOrchestratorSettings.PowerScheme;
            _previousReading = new CPUReading(cpuOrchestratorSettings.ProcessorStateSettings);
            _currentReading = new CPUReading(cpuOrchestratorSettings.ProcessorStateSettings);
            _cpuSensors = cpuOrchestratorSettings.SensorCollection;
        }

        public CPUReading DoCycle()
        {
            SetCurrentCPUReadings();
            UpdateCPUClock();
            SetPreviousCPUReading();
            return _currentReading;
        }

        private void EnsureCPUOrchestratorSettings(CPUOrchestratorSettings cpuOrchestratorSettings)
        {
            if (cpuOrchestratorSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings));

            if (cpuOrchestratorSettings.PowerScheme == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings.PowerScheme));

            if (cpuOrchestratorSettings.ProcessorStateSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings.ProcessorStateSettings));
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
            float? temperature = _cpuSensors.GetTemperature();
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
