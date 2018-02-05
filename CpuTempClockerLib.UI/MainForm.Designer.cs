namespace CpuTempClockerLib.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TemperatureTargetModeTabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SetButton = new System.Windows.Forms.Button();
            this.temperatureTargetModePanel = new System.Windows.Forms.Panel();
            this.CurrentReadingGroupBox = new System.Windows.Forms.GroupBox();
            this.currentCpuTemperatureLabelValue = new System.Windows.Forms.Label();
            this.cpuTemperatureLabel = new System.Windows.Forms.Label();
            this.ActivePowerSchemeValueLabel = new System.Windows.Forms.Label();
            this.ActivePowerSchemeLabel = new System.Windows.Forms.Label();
            this.powerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dontAllowCpuToGoOverThreshold = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PowerSchemesComboBox = new System.Windows.Forms.ComboBox();
            this.maxCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.TargetCpuTemperatureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.TargetCpuTemperature = new System.Windows.Forms.Label();
            this.PowerSchemeLabel = new System.Windows.Forms.Label();
            this.cpuUsageTargetModeTabPage = new System.Windows.Forms.TabPage();
            this.powerTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.dcPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.acPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.TemperatureTargetModeTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.temperatureTargetModePanel.SuspendLayout();
            this.CurrentReadingGroupBox.SuspendLayout();
            this.powerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).BeginInit();
            this.cpuUsageTargetModeTabPage.SuspendLayout();
            this.powerTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TemperatureTargetModeTabPage
            // 
            this.TemperatureTargetModeTabPage.Controls.Add(this.tabPage1);
            this.TemperatureTargetModeTabPage.Controls.Add(this.cpuUsageTargetModeTabPage);
            this.TemperatureTargetModeTabPage.Location = new System.Drawing.Point(12, 12);
            this.TemperatureTargetModeTabPage.Name = "TemperatureTargetModeTabPage";
            this.TemperatureTargetModeTabPage.SelectedIndex = 0;
            this.TemperatureTargetModeTabPage.Size = new System.Drawing.Size(355, 446);
            this.TemperatureTargetModeTabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.temperatureTargetModePanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(347, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temperature Target Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(214, 169);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 5;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // temperatureTargetModePanel
            // 
            this.temperatureTargetModePanel.Controls.Add(this.CurrentReadingGroupBox);
            this.temperatureTargetModePanel.Controls.Add(this.powerSettingsGroupBox);
            this.temperatureTargetModePanel.Location = new System.Drawing.Point(15, 11);
            this.temperatureTargetModePanel.Name = "temperatureTargetModePanel";
            this.temperatureTargetModePanel.Size = new System.Drawing.Size(313, 355);
            this.temperatureTargetModePanel.TabIndex = 2;
            // 
            // CurrentReadingGroupBox
            // 
            this.CurrentReadingGroupBox.Controls.Add(this.currentCpuTemperatureLabelValue);
            this.CurrentReadingGroupBox.Controls.Add(this.cpuTemperatureLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.ActivePowerSchemeValueLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.ActivePowerSchemeLabel);
            this.CurrentReadingGroupBox.Location = new System.Drawing.Point(5, 228);
            this.CurrentReadingGroupBox.Name = "CurrentReadingGroupBox";
            this.CurrentReadingGroupBox.Size = new System.Drawing.Size(295, 100);
            this.CurrentReadingGroupBox.TabIndex = 4;
            this.CurrentReadingGroupBox.TabStop = false;
            this.CurrentReadingGroupBox.Text = "Current Readings";
            // 
            // currentCpuTemperatureLabelValue
            // 
            this.currentCpuTemperatureLabelValue.AutoSize = true;
            this.currentCpuTemperatureLabelValue.Location = new System.Drawing.Point(156, 41);
            this.currentCpuTemperatureLabelValue.Name = "currentCpuTemperatureLabelValue";
            this.currentCpuTemperatureLabelValue.Size = new System.Drawing.Size(0, 13);
            this.currentCpuTemperatureLabelValue.TabIndex = 6;
            // 
            // cpuTemperatureLabel
            // 
            this.cpuTemperatureLabel.AutoSize = true;
            this.cpuTemperatureLabel.Location = new System.Drawing.Point(6, 41);
            this.cpuTemperatureLabel.Name = "cpuTemperatureLabel";
            this.cpuTemperatureLabel.Size = new System.Drawing.Size(129, 13);
            this.cpuTemperatureLabel.TabIndex = 1;
            this.cpuTemperatureLabel.Text = "Current CPU Temperature";
            // 
            // ActivePowerSchemeValueLabel
            // 
            this.ActivePowerSchemeValueLabel.AutoSize = true;
            this.ActivePowerSchemeValueLabel.Location = new System.Drawing.Point(128, 16);
            this.ActivePowerSchemeValueLabel.Name = "ActivePowerSchemeValueLabel";
            this.ActivePowerSchemeValueLabel.Size = new System.Drawing.Size(0, 13);
            this.ActivePowerSchemeValueLabel.TabIndex = 4;
            // 
            // ActivePowerSchemeLabel
            // 
            this.ActivePowerSchemeLabel.AutoSize = true;
            this.ActivePowerSchemeLabel.Location = new System.Drawing.Point(6, 16);
            this.ActivePowerSchemeLabel.Name = "ActivePowerSchemeLabel";
            this.ActivePowerSchemeLabel.Size = new System.Drawing.Size(112, 13);
            this.ActivePowerSchemeLabel.TabIndex = 1;
            this.ActivePowerSchemeLabel.Text = "Active Power Scheme";
            // 
            // powerSettingsGroupBox
            // 
            this.powerSettingsGroupBox.Controls.Add(this.SetButton);
            this.powerSettingsGroupBox.Controls.Add(this.label3);
            this.powerSettingsGroupBox.Controls.Add(this.dontAllowCpuToGoOverThreshold);
            this.powerSettingsGroupBox.Controls.Add(this.label1);
            this.powerSettingsGroupBox.Controls.Add(this.label2);
            this.powerSettingsGroupBox.Controls.Add(this.PowerSchemesComboBox);
            this.powerSettingsGroupBox.Controls.Add(this.maxCpuUsageNumeric);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperatureNumericUpDown);
            this.powerSettingsGroupBox.Controls.Add(this.minCpuUsageNumeric);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperature);
            this.powerSettingsGroupBox.Controls.Add(this.PowerSchemeLabel);
            this.powerSettingsGroupBox.Location = new System.Drawing.Point(5, 14);
            this.powerSettingsGroupBox.Name = "powerSettingsGroupBox";
            this.powerSettingsGroupBox.Size = new System.Drawing.Size(295, 208);
            this.powerSettingsGroupBox.TabIndex = 2;
            this.powerSettingsGroupBox.TabStop = false;
            this.powerSettingsGroupBox.Text = "Power Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // dontAllowCpuToGoOverThreshold
            // 
            this.dontAllowCpuToGoOverThreshold.AutoSize = true;
            this.dontAllowCpuToGoOverThreshold.Location = new System.Drawing.Point(9, 110);
            this.dontAllowCpuToGoOverThreshold.Name = "dontAllowCpuToGoOverThreshold";
            this.dontAllowCpuToGoOverThreshold.Size = new System.Drawing.Size(200, 17);
            this.dontAllowCpuToGoOverThreshold.TabIndex = 5;
            this.dontAllowCpuToGoOverThreshold.Text = "Don\'t allow CPU to go over threshold";
            this.dontAllowCpuToGoOverThreshold.UseVisualStyleBackColor = true;
            this.dontAllowCpuToGoOverThreshold.CheckedChanged += new System.EventHandler(this.dontAllowCpuToGoOverThreshold_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max CPU Usage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max CPU Usage";
            // 
            // PowerSchemesComboBox
            // 
            this.PowerSchemesComboBox.FormattingEnabled = true;
            this.PowerSchemesComboBox.Location = new System.Drawing.Point(137, 24);
            this.PowerSchemesComboBox.Name = "PowerSchemesComboBox";
            this.PowerSchemesComboBox.Size = new System.Drawing.Size(152, 21);
            this.PowerSchemesComboBox.TabIndex = 3;
            this.PowerSchemesComboBox.SelectedIndexChanged += new System.EventHandler(this.PowerSchemesComboBox_SelectedIndexChanged);
            // 
            // maxCpuUsageNumeric
            // 
            this.maxCpuUsageNumeric.Location = new System.Drawing.Point(137, 79);
            this.maxCpuUsageNumeric.Name = "maxCpuUsageNumeric";
            this.maxCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.maxCpuUsageNumeric.TabIndex = 2;
            this.maxCpuUsageNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxCpuUsageNumeric.ValueChanged += new System.EventHandler(this.maxCpuUsageNumeric_ValueChanged);
            // 
            // TargetCpuTemperatureNumericUpDown
            // 
            this.TargetCpuTemperatureNumericUpDown.Enabled = false;
            this.TargetCpuTemperatureNumericUpDown.Location = new System.Drawing.Point(137, 139);
            this.TargetCpuTemperatureNumericUpDown.Name = "TargetCpuTemperatureNumericUpDown";
            this.TargetCpuTemperatureNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.TargetCpuTemperatureNumericUpDown.TabIndex = 4;
            this.TargetCpuTemperatureNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // minCpuUsageNumeric
            // 
            this.minCpuUsageNumeric.Location = new System.Drawing.Point(137, 53);
            this.minCpuUsageNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minCpuUsageNumeric.Name = "minCpuUsageNumeric";
            this.minCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.minCpuUsageNumeric.TabIndex = 0;
            this.minCpuUsageNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minCpuUsageNumeric.ValueChanged += new System.EventHandler(this.minCpuUsageNumeric_ValueChanged);
            // 
            // TargetCpuTemperature
            // 
            this.TargetCpuTemperature.AutoSize = true;
            this.TargetCpuTemperature.Location = new System.Drawing.Point(6, 141);
            this.TargetCpuTemperature.Name = "TargetCpuTemperature";
            this.TargetCpuTemperature.Size = new System.Drawing.Size(126, 13);
            this.TargetCpuTemperature.TabIndex = 0;
            this.TargetCpuTemperature.Text = "Target CPU Temperature";
            // 
            // PowerSchemeLabel
            // 
            this.PowerSchemeLabel.AutoSize = true;
            this.PowerSchemeLabel.Location = new System.Drawing.Point(6, 27);
            this.PowerSchemeLabel.Name = "PowerSchemeLabel";
            this.PowerSchemeLabel.Size = new System.Drawing.Size(79, 13);
            this.PowerSchemeLabel.TabIndex = 1;
            this.PowerSchemeLabel.Text = "Power Scheme";
            // 
            // cpuUsageTargetModeTabPage
            // 
            this.cpuUsageTargetModeTabPage.Controls.Add(this.powerTypeGroupBox);
            this.cpuUsageTargetModeTabPage.Location = new System.Drawing.Point(4, 22);
            this.cpuUsageTargetModeTabPage.Name = "cpuUsageTargetModeTabPage";
            this.cpuUsageTargetModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cpuUsageTargetModeTabPage.Size = new System.Drawing.Size(347, 420);
            this.cpuUsageTargetModeTabPage.TabIndex = 1;
            this.cpuUsageTargetModeTabPage.Text = "CPU Usage Target Mode";
            this.cpuUsageTargetModeTabPage.UseVisualStyleBackColor = true;
            // 
            // powerTypeGroupBox
            // 
            this.powerTypeGroupBox.Controls.Add(this.dcPowerModeCheckBox);
            this.powerTypeGroupBox.Controls.Add(this.acPowerModeCheckBox);
            this.powerTypeGroupBox.Location = new System.Drawing.Point(6, 6);
            this.powerTypeGroupBox.Name = "powerTypeGroupBox";
            this.powerTypeGroupBox.Size = new System.Drawing.Size(258, 74);
            this.powerTypeGroupBox.TabIndex = 1;
            this.powerTypeGroupBox.TabStop = false;
            this.powerTypeGroupBox.Text = "Power Types ";
            // 
            // dcPowerModeCheckBox
            // 
            this.dcPowerModeCheckBox.AutoSize = true;
            this.dcPowerModeCheckBox.Location = new System.Drawing.Point(6, 46);
            this.dcPowerModeCheckBox.Name = "dcPowerModeCheckBox";
            this.dcPowerModeCheckBox.Size = new System.Drawing.Size(113, 17);
            this.dcPowerModeCheckBox.TabIndex = 1;
            this.dcPowerModeCheckBox.Text = "Battery Mode (DC)";
            this.dcPowerModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // acPowerModeCheckBox
            // 
            this.acPowerModeCheckBox.AutoSize = true;
            this.acPowerModeCheckBox.Location = new System.Drawing.Point(6, 18);
            this.acPowerModeCheckBox.Name = "acPowerModeCheckBox";
            this.acPowerModeCheckBox.Size = new System.Drawing.Size(100, 17);
            this.acPowerModeCheckBox.TabIndex = 0;
            this.acPowerModeCheckBox.Text = "Plugged In (AC)";
            this.acPowerModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 470);
            this.Controls.Add(this.TemperatureTargetModeTabPage);
            this.Name = "MainForm";
            this.Text = "CPU Clock Controller";
            this.TemperatureTargetModeTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.temperatureTargetModePanel.ResumeLayout(false);
            this.CurrentReadingGroupBox.ResumeLayout(false);
            this.CurrentReadingGroupBox.PerformLayout();
            this.powerSettingsGroupBox.ResumeLayout(false);
            this.powerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).EndInit();
            this.cpuUsageTargetModeTabPage.ResumeLayout(false);
            this.powerTypeGroupBox.ResumeLayout(false);
            this.powerTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TemperatureTargetModeTabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage cpuUsageTargetModeTabPage;
        private System.Windows.Forms.NumericUpDown maxCpuUsageNumeric;
        private System.Windows.Forms.NumericUpDown minCpuUsageNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox powerSettingsGroupBox;
        private System.Windows.Forms.Label PowerSchemeLabel;
        private System.Windows.Forms.Label TargetCpuTemperature;
        private System.Windows.Forms.NumericUpDown TargetCpuTemperatureNumericUpDown;
        private System.Windows.Forms.ComboBox PowerSchemesComboBox;
        private System.Windows.Forms.GroupBox CurrentReadingGroupBox;
        private System.Windows.Forms.Label ActivePowerSchemeValueLabel;
        private System.Windows.Forms.Label ActivePowerSchemeLabel;
        private System.Windows.Forms.Panel temperatureTargetModePanel;
        private System.Windows.Forms.GroupBox powerTypeGroupBox;
        private System.Windows.Forms.CheckBox dcPowerModeCheckBox;
        private System.Windows.Forms.CheckBox acPowerModeCheckBox;
        private System.Windows.Forms.Label cpuTemperatureLabel;
        private System.Windows.Forms.Label currentCpuTemperatureLabelValue;
        private System.Windows.Forms.CheckBox dontAllowCpuToGoOverThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SetButton;
    }
}

