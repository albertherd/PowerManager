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
using CpuTempClockerLib.PowerModes;

namespace CpuTempClockerLib.UI
{
    public partial class MainForm : Form
    {
        private CPUSensorCollection _cpuSensorCollection;
        private List<PowerScheme> _powerSchemes;
        private PowerScheme _activePowerScheme;
        private PowerSchemesManager _powerSchemesManager = new PowerSchemesManager();
        private TemperatureTargetedPowerMode _temperatureTargetedPowerMode;
        private CpuUsageTargetedPowerMode _cpuUsageTargetedPowerMode;
        private CPUStates _activePowerSchemeCpuStates;
        private System.Windows.Forms.Timer _temperatureTargetedPowerModeCycleTimer, _infoPanelUpdaterTimer;

        public MainForm()
        {
            InitializeComponent();
            SetCycleTimer();
            SetupPowerSchemeDropdown();
            SetupCpuStateInfo(_activePowerScheme);
            PopulateCPUSensors();
            SubscribeToPowerSchemeChanges(Handle);
            SetupInfoPanelUpdater();
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
            _temperatureTargetedPowerModeCycleTimer = new System.Windows.Forms.Timer();
            _temperatureTargetedPowerModeCycleTimer.Interval = 200;
            _temperatureTargetedPowerModeCycleTimer.Tick += CycleTimer_Tick;
        }

        private void PopulateCPUSensors()
        {
            _cpuSensorCollection = new CPUSensorsManager().GetCPUSensors().FirstOrDefault();
        }

        private void SetupPowerSchemeDropdown()
        {
            _powerSchemes = _powerSchemesManager.GetPowerSchemes();
            _activePowerScheme = _powerSchemes.Where(powerScheme => powerScheme.IsActive()).FirstOrDefault();

            PowerSchemesComboBox.DataSource = new BindingSource(_powerSchemes, null);
            PowerSchemesComboBox.DisplayMember = "FriendlyName";
            PowerSchemesComboBox.SelectedItem = _activePowerScheme;
        }

        private void SetupCpuStateInfo(PowerScheme powerScheme)
        {
            _activePowerSchemeCpuStates = powerScheme.GetCPUStates();
            if (_activePowerSchemeCpuStates.IsOnAcPower)
            {
                minCpuUsageNumeric.Value = _activePowerSchemeCpuStates.AcMinPowerIndex;
                maxCpuUsageNumeric.Value = _activePowerSchemeCpuStates.AcMaxPowerIndex;
            }
            else if (_activePowerSchemeCpuStates.IsOnDcPower)
            {
                minCpuUsageNumeric.Value = _activePowerSchemeCpuStates.DcMinPowerIndex;
                maxCpuUsageNumeric.Value = _activePowerSchemeCpuStates.DcMaxPowerIndex;
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

        private void SetupInfoPanelUpdater()
        {
            _infoPanelUpdaterTimer = new System.Windows.Forms.Timer();
            _infoPanelUpdaterTimer.Interval = 1000;
            _infoPanelUpdaterTimer.Tick += _infoPanelUpdaterTimer_Tick;
            _infoPanelUpdaterTimer.Start();
        }

        private void _infoPanelUpdaterTimer_Tick(object sender, EventArgs e)
        {
            currentCpuTemperatureLabelValue.Text = _cpuSensorCollection.PackageSensor.Value.ToString() + " C";
        }

        private void SetPowerScheme()
        {
            _activePowerScheme = _powerSchemes.Where(powerScheme => powerScheme.IsActive()).FirstOrDefault();
            ActivePowerSchemeValueLabel.Text = _activePowerScheme.FriendlyName;
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if (dontAllowCpuToGoOverThreshold.Enabled)
            {
                ToggleTemperatureTargetMode();
            }
            else
            {
                ToggleCpuStatesTargetMode();
            }
        }

        private void ToggleCpuStatesTargetMode()
        {
            if (_cpuUsageTargetedPowerMode == null)
                _cpuUsageTargetedPowerMode = new CpuUsageTargetedPowerMode(_activePowerScheme);

            _cpuUsageTargetedPowerMode.SetCPUStates(_activePowerSchemeCpuStates);
        }

        private void ToggleTemperatureTargetMode()
        {
            if (_temperatureTargetedPowerMode == null)
                EnableTemperatureTargetMode();
            else
                DisableTemperatureTargetMode();
        }

        private void EnableTemperatureTargetMode()
        {
            _temperatureTargetedPowerMode = new TemperatureTargetedPowerMode(new TemperatureTargetedPowerModeSettings
            {
                PowerScheme = _activePowerScheme,
                PowerWriteType = Enums.PowerType.AC | Enums.PowerType.DC,
                ProcessorStateSettings = new ProcessorStateSettings(Convert.ToInt32(minCpuUsageNumeric.Value), Convert.ToInt32(maxCpuUsageNumeric.Value)),
                SensorCollection = _cpuSensorCollection,
                TargetCPUTemperature = Convert.ToInt32(TargetCpuTemperatureNumericUpDown.Value)
            });

            _temperatureTargetedPowerModeCycleTimer.Start();
        }

        private void DisableTemperatureTargetMode()
        {
            _temperatureTargetedPowerModeCycleTimer.Stop();
            _temperatureTargetedPowerMode = null;
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            _temperatureTargetedPowerMode.DoCycle();
        }

        private void dontAllowCpuToGoOverThreshold_CheckedChanged(object sender, EventArgs e)
        {
            TargetCpuTemperatureNumericUpDown.Enabled = dontAllowCpuToGoOverThreshold.Checked;
        }

        private void minCpuUsageNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (_activePowerSchemeCpuStates.IsOnAcPower)
            {
                 _activePowerSchemeCpuStates.AcMinPowerIndex = (int)minCpuUsageNumeric.Value;
            }
            else if (_activePowerSchemeCpuStates.IsOnDcPower)
            {
                 _activePowerSchemeCpuStates.DcMinPowerIndex = (int)minCpuUsageNumeric.Value;
            }
        }

        private void maxCpuUsageNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (_activePowerSchemeCpuStates.IsOnAcPower)
            {
                _activePowerSchemeCpuStates.AcMaxPowerIndex = (int)maxCpuUsageNumeric.Value;
            }
            else if (_activePowerSchemeCpuStates.IsOnDcPower)
            {
                _activePowerSchemeCpuStates.DcMaxPowerIndex = (int)maxCpuUsageNumeric.Value;
            }
        }

        private void PowerSchemesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupCpuStateInfo((PowerScheme)PowerSchemesComboBox.SelectedItem);
        }
    }
}
