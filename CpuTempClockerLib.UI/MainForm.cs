using CpuTempClockerLib.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpuTempClockerLib.Models;
using System.Windows.Threading;
using Microsoft.Win32;
using CpuTempClockerLib.Native.Constants.WindowProc;
using static CpuTempClockerLib.Native.User32;
using System.Runtime.InteropServices;

namespace CpuTempClockerLib.UI
{
    public partial class MainForm : Form
    {
        private Dictionary<PowerScheme, string> _powerSchemes;
        private Dictionary<CPUSensorCollection, string> _cpuSensorCollections;
        private PowerSchemesManager _powerSchemesManager = new PowerSchemesManager();

        public MainForm()
        {
            InitializeComponent();
            PopulatePowerSchemes();
            PopulateCPUSensors();
            SubscribeToPowerSchemeChanges(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == UMsg.WM_POWERBROADCAST && m.WParam.ToInt32() == WParam.PBT_POWERSETTINGCHANGE)
            {
                POWERBROADCAST_SETTING powerBroadcastSetting = (POWERBROADCAST_SETTING)m.GetLParam(typeof(POWERBROADCAST_SETTING));
                if (powerBroadcastSetting.PowerSetting == GUID_POWERSCHEME_PERSONALITY)
                {
                    SetPowerScheme();
                }
            }
            base.WndProc(ref m);
        }

        private void PopulateCPUSensors()
        {
            _cpuSensorCollections = new CPUSensorsManager().GetCPUSensors().ToDictionary(cpuSensor => cpuSensor, cpuSensor => cpuSensor.PackageSensor.Name);

            CPUSensorsComboBox.DataSource = new BindingSource(_cpuSensorCollections, null);
            CPUSensorsComboBox.ValueMember = "Key";
            CPUSensorsComboBox.DisplayMember = "Value";
            CPUSensorsComboBox.SelectedIndex = 0;
        }

        private void PopulatePowerSchemes()
        {
            List<PowerScheme> powerSchemes = _powerSchemesManager.GetPowerSchemes();
            _powerSchemes = powerSchemes.ToDictionary(powerScheme => powerScheme, powerScheme => powerScheme.FriendlyName);

            PowerSchemesComboBox.DataSource = new BindingSource(_powerSchemes, null);
            PowerSchemesComboBox.ValueMember = "Key";
            PowerSchemesComboBox.DisplayMember = "Value";
            PowerSchemesComboBox.SelectedItem = _powerSchemes.Where(powerScheme => powerScheme.Key.IsActive()).Select(powerScheme => powerScheme.Value).FirstOrDefault();
        }

        private void SubscribeToPowerSchemeChanges(IntPtr hwnd)
        {
            _powerSchemesManager.SubscribeToPowerSchemeChange(hwnd);
        }

        private void SetPowerScheme()
        {
            string activePowerScheme = _powerSchemes.Where(powerScheme => powerScheme.Key.IsActive()).Select(powerScheme => powerScheme.Value).FirstOrDefault();
            ActivePowerSchemeValueLabel.Text = activePowerScheme;
            PowerSchemesComboBox.SelectedItem = activePowerScheme;
        }
    }
}
