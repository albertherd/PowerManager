using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuTempClockerLib.UI
{
    public class UserInteractionHandler
    {
        private readonly MainForm _parentForm;
        private NotifyIcon _notifyIcon;

        private bool _hiddenTriggeredFromNotifyIcon = false;

        private MenuItem _showMenuItem;
        private MenuItem _hideMenuItem;
        private MenuItem _exitMenuItem;

        private MenuItem[] WhenVisibleMenuItems;
        private MenuItem[] WhenHiddenMenuItems;

        private DateTime LastBaloonPopShown;

        public UserInteractionHandler(MainForm parentForm)
        {
            _parentForm = parentForm;
            Initialize();
        }

        private void Initialize()
        {
            _showMenuItem = new MenuItem("Show", new EventHandler((s, e) => { _parentForm.Show(); }));
            _hideMenuItem = new MenuItem("Hide", new EventHandler(SetWindowHidden));
            _exitMenuItem = new MenuItem("Exit", new EventHandler((s, e) => { _parentForm.OnApplicationExit(); }));

            WhenVisibleMenuItems = new[] { _hideMenuItem, _exitMenuItem };
            WhenHiddenMenuItems = new[] { _showMenuItem, _exitMenuItem };

            LastBaloonPopShown = DateTime.MinValue;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = _parentForm.Icon;
            _notifyIcon.Visible = true;
            _notifyIcon.Text = _parentForm.Text;
            _notifyIcon.ContextMenu = new ContextMenu(WhenVisibleMenuItems);
            _notifyIcon.BalloonTipClicked += (s, e) => _parentForm.Show();
            _notifyIcon.DoubleClick += OnNotifyIconDoubleClick;
            
            _parentForm.VisibleChanged += OnVisibleChanged;
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            if (_parentForm.Visible)
                SetWindowHiddenImpl();
            else
                _parentForm.Show();
        }

        internal void OnPowerSettingChanged()
        {
            if (_parentForm.Visible)
                MessageBox.Show($"Power settings have been changed. Any custom power mode has been de-activated. Re-apply any power settings.", "Power Settings", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                _notifyIcon.ShowBalloonTip(/*ignored*/69, _parentForm.Text, $"Power settings have been changed. Any custom power mode has been de-activated. Re-apply any power settings.", ToolTipIcon.Info);
        }

        private void SetWindowHidden(object sender, EventArgs e)
        {
            SetWindowHiddenImpl();
        }

        private void SetWindowHiddenImpl()
        {
            _hiddenTriggeredFromNotifyIcon = true;
            _parentForm.Hide();
            _hiddenTriggeredFromNotifyIcon = false;
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (_parentForm.Visible)
                OnVisible();
            else
                OnHidden();
        }

        private void OnVisible()
        {
            _notifyIcon.ContextMenu = new ContextMenu(WhenVisibleMenuItems);
        }

        private void OnHidden()
        {
            if (!_hiddenTriggeredFromNotifyIcon)
                TryShowOnHiddenBaloonTip();
            _notifyIcon.ContextMenu = new ContextMenu(WhenHiddenMenuItems);
        }

        private void TryShowOnHiddenBaloonTip()
        {
            TimeSpan timeElapsedSinceLastShown = DateTime.Now - LastBaloonPopShown;
            if (timeElapsedSinceLastShown.TotalSeconds > 10)
            {
                _notifyIcon.ShowBalloonTip(/*ignored*/69, _parentForm.Text, $"{_parentForm.Text} is still running - click here to show.", ToolTipIcon.Info);
                LastBaloonPopShown = DateTime.Now;
            }
        }
    }
}
