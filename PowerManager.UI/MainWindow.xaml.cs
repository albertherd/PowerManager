using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CpuTempClockerLib;
using CpuTempClockerLib.Managers;

namespace PowerManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CPUSensorCollection activeSensorCollections;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Init()
        {

        }

        private void SetSensorCollection()
        {
            activeSensorCollections = new CPUSensorsManager().GetCPUSensors().FirstOrDefault();
        }
    }
}
