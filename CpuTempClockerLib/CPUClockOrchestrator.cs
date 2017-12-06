using CpuTempClockerLib.Models;
using CpuTempClockerLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public class CPUClockOrchestrator : IDisposable
    {
        private const int ProcessorStateIncrementsWhenNoFluctuation = 5; 

        private float TargetTemperature = 30;
        private PowerWriteType PowerWriteType = PowerWriteType.AC | PowerWriteType.DC;

        private CPUThermalManager _thermalManager = new CPUThermalManager();
        private CPUPowerManager _powerManager = new CPUPowerManager();
        private CPUReading _previousReading = new CPUReading();
        private CPUReading _currentReading = new CPUReading();


        public CPUClockOrchestrator(CpuOrchestratorSettings cpuOrchestratorSettings)
        {
            if (cpuOrchestratorSettings == null)
                throw new ArgumentException(nameof(cpuOrchestratorSettings));

            TargetTemperature = cpuOrchestratorSettings.TargetCPUTemperature;
            PowerWriteType = cpuOrchestratorSettings.PowerWriteType;
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
            _previousReading.TemperatureFluctuationType = _currentReading.TemperatureFluctuationType;
        }

        private void UpdateCPUClock()
        {
            if (_currentReading.TemperatureFluctuationType == TemperatureFluctuationType.None)
                return;
            
            _powerManager.SetCpuProcessorClockPercentage(PowerWriteType, _currentReading.ProcessorState);            
        }

        private void SetCurrentCPUReadings()
        {
            SetCurrentTemperature();
            SetCurrentProcessorState();
            SetCurrentTemperatureFluctuationType();
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
            if(_currentReading.TemperatureFluctuationType == TemperatureFluctuationType.None && _currentReading.Temperature < TargetTemperature)
            {
                return ProcessorStateIncrementsWhenNoFluctuation;
            }            
            float temperatureDelta = TargetTemperature - _currentReading.Temperature;
            return (int)((temperatureDelta * 100) / TargetTemperature);
        }

        private void SetCurrentTemperatureFluctuationType()
        {
            if (_currentReading.Temperature > _previousReading.Temperature)
            {
                _currentReading.TemperatureFluctuationType = TemperatureFluctuationType.Increased;
            }
            else if (_currentReading.Temperature < _previousReading.Temperature)
            {
                _currentReading.TemperatureFluctuationType = TemperatureFluctuationType.Decreased;
            }
            else
            {
                _currentReading.TemperatureFluctuationType = TemperatureFluctuationType.None;
            }
        }
    }
}
