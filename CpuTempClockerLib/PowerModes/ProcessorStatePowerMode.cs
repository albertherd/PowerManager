using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpuTempClockerLib.Enums;
using CpuTempClockerLib.Factories;
using CpuTempClockerLib.Models;

namespace CpuTempClockerLib.PowerModes
{
    public class ProcessorStatePowerMode : IDisposable
    {
        private bool _disposed = false;
        private int _originalMaxCPUStateSet;
        private int _originalMinCPUStateSet;
        protected PowerScheme _powerScheme;

        public ProcessorStatePowerMode()
        {
            _powerScheme = PowerSchemesFactory.GetActivePowerScheme();
            _originalMaxCPUStateSet = _powerScheme.GetMaxCPUState();
            _originalMinCPUStateSet = _powerScheme.GetMinCPUState();
        }

        public bool SetMaximumProcessorState(int percentage)
        {
            return _powerScheme.SetMaxCPUState(percentage);
        }

        public int GetMaximumProcessorState()
        {
            return _powerScheme.GetMaxCPUState();
        }

        public void ResetCPUStates()
        {
            _powerScheme.ResetCPUStates();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _powerScheme.Dispose();
            }

            _disposed = true;
        }
    }
}
