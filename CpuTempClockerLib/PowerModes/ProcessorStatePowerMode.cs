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
        protected PowerScheme _powerScheme;

        public ProcessorStatePowerMode()
        {
            _powerScheme = PowerSchemesFactory.GetActivePowerScheme() ?? throw new InvalidOperationException("Could not determine the active power scheme");
        }

        public bool SetMaximumProcessorState(int percentage)
        {
            return _powerScheme.SetMaxCPUState(percentage);
        }

        public int GetMaximumProcessorState()
        {
            return _powerScheme.GetMaxCPUState();
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
