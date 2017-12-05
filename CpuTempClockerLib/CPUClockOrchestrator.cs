using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib
{
    public class CPUClockOrchestrator
    {
        private const float TargetTemperature = 48;

        private const int PowerManagementIncrements = 5;

        private CPUThermalManager _thermalManager;
        private CPUPowerManager _powerManager;
        private CPUReading _previousReading = new CPUReading();
        private CPUReading _currentReading = new CPUReading();

        public CPUClockOrchestrator(CPUThermalManager thermalManager, CPUPowerManager powerManager)
        {
            _thermalManager = thermalManager;
            _powerManager = powerManager;
        }

        public void DoCycle()
        {
            SetCurrentCpuReading();
            CalculateNextCpuPowerTarget();
            if (_currentReading.Temperature != _previousReading.Temperature)
            {
                _powerManager.SetCpuProcessorClockPercentage(_currentReading.ProcessorState);
                Console.WriteLine($"{_currentReading.Temperature}");
            }
            SetPreviousCpuReading();
        }

        private void SetCurrentCpuReading()
        {
            float? temperature = _thermalManager.GetTemperature();
            if (temperature.HasValue)
                _currentReading.Temperature = temperature.Value;
        }

        private void SetPreviousCpuReading()
        {
            _previousReading.ProcessorState = _currentReading.ProcessorState;
            _previousReading.Temperature = _currentReading.Temperature;
        }

        private void CalculateNextCpuPowerTarget()
        {
            if(_currentReading.Temperature < TargetTemperature)
            {
                _currentReading.ProcessorState += PowerManagementIncrements;
            }
            else if(_currentReading.Temperature > TargetTemperature)
            {
                _currentReading.ProcessorState -= PowerManagementIncrements;
            }
        }
    }
}
