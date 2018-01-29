using CpuTempClockerLib.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CpuTempClockerLib.Models;
using CpuTempClockerLib.Native.Constants.WindowProc;
using static CpuTempClockerLib.Native.User32;
using System.Threading;

namespace CpuTempClockerLib.UI
{
    public partial class MainForm : Form
    {
        private List<PowerScheme> _powerSchemes;
        private PowerScheme _activePowerScheme;
        private Dictionary<CPUSensorCollection, string> _cpuSensorCollections;
        private PowerSchemesManager _powerSchemesManager = new PowerSchemesManager();
        private TemperatureTargetedPowerMode temperatureTargetedPowerMode;
        private System.Windows.Forms.Timer temperatureTargetedPowerModeCycleTimer;

        public MainForm()
        {
            InitializeComponent();
            SetCycleTimer();
            SetupPowerSchemeDropdown();
            SetupCpuStateInfo(_activePowerScheme);
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

        private void SetCycleTimer()
        {
            temperatureTargetedPowerModeCycleTimer = new System.Windows.Forms.Timer();
            temperatureTargetedPowerModeCycleTimer.Interval = 200;
            temperatureTargetedPowerModeCycleTimer.Tick += CycleTimer_Tick;
        }

        private void PopulateCPUSensors()
        {
            _cpuSensorCollections = new CPUSensorsManager().GetCPUSensors().ToDictionary(cpuSensor => cpuSensor, cpuSensor => cpuSensor.PackageSensor.Name);

            CPUSensorsComboBox.DataSource = new BindingSource(_cpuSensorCollections, null);
            CPUSensorsComboBox.ValueMember = "Key";
            CPUSensorsComboBox.DisplayMember = "Value";
            CPUSensorsComboBox.SelectedIndex = 0;
        }

        private void SetupPowerSchemeDropdown()
        {
            _powerSchemes = _powerSchemesManager.GetPowerSchemes();
            _activePowerScheme = _powerSchemes.Where(powerScheme => powerScheme.IsActive()).FirstOrDefault();

            PowerSchemesComboBox.DataSource = new BindingSource(_powerSchemes, null);
            PowerSchemesComboBox.ValueMember = "Guid";
            PowerSchemesComboBox.DisplayMember = "FriendlyName";
            PowerSchemesComboBox.SelectedItem = _activePowerScheme.FriendlyName;
        }

        private void SetupCpuStateInfo(PowerScheme powerScheme)
        {
            CPUStates cpuStates = powerScheme.GetCPUStates();
            if (cpuStates.IsOnAcPower)
            {
                minCpuUsageNumeric.Value = cpuStates.AcMinPowerIndex;
                maxCpuUsageNumeric.Value = cpuStates.AcMaxPowerIndex;
            }
            else if (cpuStates.IsOnDcPower)
            {
                minCpuUsageNumeric.Value = cpuStates.DcMinPowerIndex;
                maxCpuUsageNumeric.Value = cpuStates.DcMaxPowerIndex;
            }
            else
            {
                throw new Exception("Cannot decide whether on AC or DC.");
            }
        }

        private void SubscribeToPowerSchemeChanges(IntPtr hwnd)
        {
            _powerSchemesManager.SubscribeToPowerSchemeChange(hwnd);
        }

        private void SetPowerScheme()
        {
            _activePowerScheme = _powerSchemes.Where(powerScheme => powerScheme.IsActive()).FirstOrDefault();
            ActivePowerSchemeValueLabel.Text = _activePowerScheme.FriendlyName;
        }

        private void TemperatureTargetModeToggleButton_Click(object sender, EventArgs e)
        {
            if (temperatureTargetedPowerMode == null)
                EnableTemperatureTargetMode();
            else
                DisableTemperatureTargetMode();
        }

        private void EnableTemperatureTargetMode()
        {
            temperatureTargetedPowerMode = new TemperatureTargetedPowerMode(new TemperatureTargetedPowerModeSettings
            {
                PowerScheme = _activePowerScheme,
                PowerWriteType = Enums.PowerType.AC | Enums.PowerType.DC,
                ProcessorStateSettings = new ProcessorStateSettings(Convert.ToInt32(minCpuUsageNumeric.Value), Convert.ToInt32(maxCpuUsageNumeric.Value)),
                SensorCollection = _cpuSensorCollections.ElementAt(0).Key,
                TargetCPUTemperature = Convert.ToInt32(TargetCpuTemperatureNumericUpDown.Value)
            });

            temperatureTargetedPowerModeCycleTimer.Start();
            TemperatureTargetModeToggleButton.Text = "Stop";
            temperatureTargetModePanel.Enabled = false;
        }

        private void DisableTemperatureTargetMode()
        {
            temperatureTargetModePanel.Enabled = true;
            TemperatureTargetModeToggleButton.Text = "Start";
            temperatureTargetedPowerModeCycleTimer.Stop();
            temperatureTargetedPowerMode = null;
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            temperatureTargetedPowerMode.DoCycle();
        }

        private void PowerSchemesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupCpuStateInfo(PowerSchemesComboBox.SelectedValue);
        }
    }
}
