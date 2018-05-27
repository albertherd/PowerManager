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
using CpuTempClockerLib.Enums;
using CpuTempClockerLib.NativeWappers;
using CpuTempClockerLib.PowerModes;
using CpuTempClockerLib.Factories;
using System.Drawing;

namespace CpuTempClockerLib.UI
{
    public partial class MainForm : Form
    {
        private ProcessorStatePowerMode _processorStatePowerMode;
        private TemperatureTargetedPowerMode _temperatureTargetedPowerMode;
        private CPUSensorCollection _cpuSensorCollection;
        private UserInteractionHandler _notifyIconHandler;
        private Func<Action>[] _tabActivationActions;
        private Action _onDectivateTabFunc;
        private bool _hasInitialized;
        private bool _isExiting;

        // Todo
        // Get the current max CPU setting to display in slider

        public MainForm()
        {
            InitializeComponent();
            SetupTabActivationsActions();
            SubscribeToPowerSchemeChanges(Handle);
            SetupPeriodicInformationPanel();
            SetupNotifyIcon();
            _hasInitialized = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == UMsg.WM_POWERBROADCAST && m.WParam.ToInt32() == WParam.PBT_POWERSETTINGCHANGE)
            {
                POWERBROADCAST_SETTING powerBroadcastSetting = (POWERBROADCAST_SETTING)m.GetLParam(typeof(POWERBROADCAST_SETTING));
                if (powerBroadcastSetting.PowerSetting == GUID_POWERSCHEME_PERSONALITY)
                {
                    OnPowerSettingChanged();
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(!_isExiting)
            {
                e.Cancel = true;
                this.Hide();
            }
            base.OnFormClosing(e);
        }

        internal void OnApplicationExit()
        {
            _isExiting = true;
            _onDectivateTabFunc();
            Application.Exit();
        }

        private void OnPowerSettingChanged()
        {
            if (_hasInitialized)
            {
                
                _notifyIconHandler.OnPowerSettingChanged();
            }
            DisposePowerModeAndActivateTab(PowerModeTabPages.SelectedIndex);
        }

        private void SubscribeToPowerSchemeChanges(IntPtr hwnd)
        {
            User32NativeWrapper.SubscribeToPowerSchemeChange(hwnd);
        }

        private void SetupPeriodicInformationPanel()
        {
            _cpuSensorCollection = CPUSensorsFactory.GetCPUZeroSensor();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (sender, e) => 
            {
                _cpuSensorCollection.PackageSensor.Hardware.Update();
                cpuPackageTemperatureLabelValue.Text = _cpuSensorCollection.PackageSensor.Value + "C";
            };
            timer.Start();
        }

        private void SetupNotifyIcon()
        {
            _notifyIconHandler = new UserInteractionHandler(this);
        }

        private void SetupTabActivationsActions()
        {
            _tabActivationActions = new Func<Action>[] { OnProcessorStateTabActivate, OnTemperatureTargetedTabTabActivate };
        }

        private void BtnSetMaxCPUState_Click(object sender, EventArgs e)
        {
            if (_processorStatePowerMode.SetMaximumProcessorState((int)maxCpuUsageNumeric.Value))
            {
                MessageBox.Show($"Maximum CPU state set to: {(int)maxCpuUsageNumeric.Value}", "Processor state set", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show($"There was a problem setting your Maximum CPU State: {(int)maxCpuUsageNumeric.Value}", "Error setting processor state", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnSetTargetCPUState_Click(object sender, EventArgs e)
        {
            if (!_temperatureTargetedPowerMode.IsRunning())
                EnableTemperatureTargetedPowerMode();
            else 
                DisableTemperatureTargetedPowerMode();
        }

        private void EnableTemperatureTargetedPowerMode()
        {
            _temperatureTargetedPowerMode.Start((int)TargetCpuTemperatureNumericUpDown.Value, (state) =>
            {
                lblCurrentMaxCPUUsagePercentage.Text = $"{state}%";
            });
            btnSetTargetCPUState.Text = "Stop";
        }

        private void DisableTemperatureTargetedPowerMode()
        {
            _temperatureTargetedPowerMode.Stop();
            btnSetTargetCPUState.Text = "Start";
        }

        private void TemperatureTargetModeTabPage_Selected(object sender, TabControlEventArgs e)
        {
            DisposePowerModeAndActivateTab(e.TabPageIndex);
        }

        private void DisposePowerModeAndActivateTab(int tabPageIndex)
        {
            _onDectivateTabFunc?.Invoke();
            _onDectivateTabFunc = _tabActivationActions[tabPageIndex]();
        }

        private Action OnProcessorStateTabActivate()
        {
            _processorStatePowerMode = new ProcessorStatePowerMode();
            maxCpuUsageNumeric.Value = _processorStatePowerMode.GetMaximumProcessorState();
            return OnProcessorStateTabDeactivate;
        }

        private void OnProcessorStateTabDeactivate()
        {
            if (_isExiting && persistUsageAfterExitingCheckBox.Checked)
                return;

            _processorStatePowerMode.Dispose();
        }

        private Action OnTemperatureTargetedTabTabActivate()
        {
            _temperatureTargetedPowerMode = new TemperatureTargetedPowerMode();
            lblCurrentMaxCPUUsagePercentage.Text = $"{_temperatureTargetedPowerMode.GetMaximumProcessorState()}%";
            return OnTemperatureTargetedTabDeActivate;
        }

        private void OnTemperatureTargetedTabDeActivate()
        {
            _temperatureTargetedPowerMode.Dispose();
        }
    }
}
