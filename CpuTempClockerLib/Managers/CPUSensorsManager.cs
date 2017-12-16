using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempClockerLib.Managers
{
    public class CPUSensorsManager
    {
        private Computer _computer = new Computer() { CPUEnabled = true };
        private List<CPUSensorCollection> _cpuSensorsCollection = new List<CPUSensorCollection>();

        public IEnumerable<CPUSensorCollection> GetCPUSensors()
        {
            if (_cpuSensorsCollection != null)
                return new List<CPUSensorCollection>(_cpuSensorsCollection);

            IEnumerable<IHardware> cpuHardwares = _computer.Hardware.Where(hardware => hardware.HardwareType == HardwareType.CPU);
            foreach(IHardware cpuHardware in cpuHardwares)
            {
                _cpuSensorsCollection.Add(new CPUSensorCollection(cpuHardware));
            }

            return new List<CPUSensorCollection>(_cpuSensorsCollection);
        }
    }
}
