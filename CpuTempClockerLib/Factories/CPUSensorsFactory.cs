using CpuTempClockerLib.Managers;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace CpuTempClockerLib.Factories
{
    public class CPUSensorsFactory
    {
        private static Computer _computer = new Computer() { CPUEnabled = true };
        private static List<CPUSensorCollection> _cpuSensorsCollection = new List<CPUSensorCollection>();

        public static IEnumerable<CPUSensorCollection> GetCPUSensors()
        {
            if (_cpuSensorsCollection != null && _cpuSensorsCollection.Any())
                return new List<CPUSensorCollection>(_cpuSensorsCollection);

            _computer.Open();
            IEnumerable<IHardware> cpuHardwares = _computer.Hardware.Where(hardware => hardware.HardwareType == HardwareType.CPU);
            foreach(IHardware cpuHardware in cpuHardwares)
            {
                _cpuSensorsCollection.Add(new CPUSensorCollection(cpuHardware));
            }

            return new List<CPUSensorCollection>(_cpuSensorsCollection);
        }

        public static CPUSensorCollection GetCPUZeroSensor()
        {
            return GetCPUSensors().FirstOrDefault();
        }
    }
}
