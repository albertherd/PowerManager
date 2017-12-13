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
    public class CPUClockOrchestrator
    {
        private float TargetTemperature;
        private PowerType PowerWriteType;

        private CPUThermalManager _thermalManager = new CPUThermalManager();
        private CPUReading _previousReading = new CPUReading();
        private CPUReading _currentReading = new CPUReading();

        private readonly PowerScheme _powerScheme;

        public CPUClockOrchestrator(CpuOrchestratorSettings cpuOrchestratorSettings)
        {
            if (cpuOrchestratorSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings));

            TargetTemperature = cpuOrchestratorSettings.TargetCPUTemperature;
            PowerWriteType = cpuOrchestratorSettings.PowerWriteType;
            _powerScheme = cpuOrchestratorSettings.PowerScheme;
        }

        public CPUReading DoCycle()
        {
            SetCurrentCPUReadings();
            UpdateCPUClock();
            SetPreviousCPUReading();
            return _currentReading;
        }

        public CPUReading SetMaxCpuClock(int percentage)
        {
            SetCurrentCPUReadings();
            UpdateCPUClock(percentage);
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

            _powerScheme.SetMaxCPUState(PowerWriteType, _currentReading.ProcessorState);
        }

        private void UpdateCPUClock(int percentage)
        {
            if (_currentReading.Temperature == _previousReading.Temperature)
                return;

            _powerScheme.SetMaxCPUState(PowerWriteType, percentage);
        }

        private void SetCurrentCPUReadings()
        {
            SetCurrentTemperature();
            SetCurrentProcessorState();
        }

        private void SetCurrentTemperature()
        {
            float? temperature = _thermalManager.GetTemperature();
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
