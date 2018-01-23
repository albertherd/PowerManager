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
            this.TemperatureTargetModeToggleButton = new System.Windows.Forms.Button();
            this.powerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.CPUSensorsComboBox = new System.Windows.Forms.ComboBox();
            this.PowerSchemesComboBox = new System.Windows.Forms.ComboBox();
            this.TargetCpuTemperatureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PowerSchemeLabel = new System.Windows.Forms.Label();
            this.TargetCpuTemperature = new System.Windows.Forms.Label();
            this.cpuUsageGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.minCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.powerTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.dcPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.acPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.cpuUsageTargetModeTabPage = new System.Windows.Forms.TabPage();
            this.CurrentReadingGroupBox = new System.Windows.Forms.GroupBox();
            this.ActivePowerSchemeLabel = new System.Windows.Forms.Label();
            this.AcMaxCpuLabel = new System.Windows.Forms.Label();
            this.DcMaxCpuLabel = new System.Windows.Forms.Label();
            this.ActivePowerSchemeValueLabel = new System.Windows.Forms.Label();
            this.MaxCpuAcValueLabel = new System.Windows.Forms.Label();
            this.MaxCpuDcValueLabel = new System.Windows.Forms.Label();
            this.TemperatureTargetModeTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.powerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).BeginInit();
            this.cpuUsageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).BeginInit();
            this.powerTypeGroupBox.SuspendLayout();
            this.CurrentReadingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TemperatureTargetModeTabPage
            // 
            this.TemperatureTargetModeTabPage.Controls.Add(this.tabPage1);
            this.TemperatureTargetModeTabPage.Controls.Add(this.cpuUsageTargetModeTabPage);
            this.TemperatureTargetModeTabPage.Location = new System.Drawing.Point(12, 12);
            this.TemperatureTargetModeTabPage.Name = "TemperatureTargetModeTabPage";
            this.TemperatureTargetModeTabPage.SelectedIndex = 0;
            this.TemperatureTargetModeTabPage.Size = new System.Drawing.Size(295, 460);
            this.TemperatureTargetModeTabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CurrentReadingGroupBox);
            this.tabPage1.Controls.Add(this.TemperatureTargetModeToggleButton);
            this.tabPage1.Controls.Add(this.powerSettingsGroupBox);
            this.tabPage1.Controls.Add(this.cpuUsageGroupBox);
            this.tabPage1.Controls.Add(this.powerTypeGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temperature Target Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TemperatureTargetModeToggleButton
            // 
            this.TemperatureTargetModeToggleButton.Location = new System.Drawing.Point(198, 398);
            this.TemperatureTargetModeToggleButton.Name = "TemperatureTargetModeToggleButton";
            this.TemperatureTargetModeToggleButton.Size = new System.Drawing.Size(75, 23);
            this.TemperatureTargetModeToggleButton.TabIndex = 3;
            this.TemperatureTargetModeToggleButton.Text = "Start";
            this.TemperatureTargetModeToggleButton.UseVisualStyleBackColor = true;
            // 
            // powerSettingsGroupBox
            // 
            this.powerSettingsGroupBox.Controls.Add(this.CPUSensorsComboBox);
            this.powerSettingsGroupBox.Controls.Add(this.PowerSchemesComboBox);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperatureNumericUpDown);
            this.powerSettingsGroupBox.Controls.Add(this.label5);
            this.powerSettingsGroupBox.Controls.Add(this.PowerSchemeLabel);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperature);
            this.powerSettingsGroupBox.Location = new System.Drawing.Point(15, 180);
            this.powerSettingsGroupBox.Name = "powerSettingsGroupBox";
            this.powerSettingsGroupBox.Size = new System.Drawing.Size(258, 106);
            this.powerSettingsGroupBox.TabIndex = 2;
            this.powerSettingsGroupBox.TabStop = false;
            this.powerSettingsGroupBox.Text = "Power Settings";
            // 
            // CPUSensorsComboBox
            // 
            this.CPUSensorsComboBox.FormattingEnabled = true;
            this.CPUSensorsComboBox.Location = new System.Drawing.Point(131, 75);
            this.CPUSensorsComboBox.Name = "CPUSensorsComboBox";
            this.CPUSensorsComboBox.Size = new System.Drawing.Size(121, 21);
            this.CPUSensorsComboBox.TabIndex = 4;
            // 
            // PowerSchemesComboBox
            // 
            this.PowerSchemesComboBox.FormattingEnabled = true;
            this.PowerSchemesComboBox.Location = new System.Drawing.Point(131, 45);
            this.PowerSchemesComboBox.Name = "PowerSchemesComboBox";
            this.PowerSchemesComboBox.Size = new System.Drawing.Size(121, 21);
            this.PowerSchemesComboBox.TabIndex = 3;
            // 
            // TargetCpuTemperatureNumericUpDown
            // 
            this.TargetCpuTemperatureNumericUpDown.Location = new System.Drawing.Point(131, 16);
            this.TargetCpuTemperatureNumericUpDown.Name = "TargetCpuTemperatureNumericUpDown";
            this.TargetCpuTemperatureNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.TargetCpuTemperatureNumericUpDown.TabIndex = 4;
            this.TargetCpuTemperatureNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "CPU Sensor";
            // 
            // PowerSchemeLabel
            // 
            this.PowerSchemeLabel.AutoSize = true;
            this.PowerSchemeLabel.Location = new System.Drawing.Point(6, 48);
            this.PowerSchemeLabel.Name = "PowerSchemeLabel";
            this.PowerSchemeLabel.Size = new System.Drawing.Size(79, 13);
            this.PowerSchemeLabel.TabIndex = 1;
            this.PowerSchemeLabel.Text = "Power Scheme";
            // 
            // TargetCpuTemperature
            // 
            this.TargetCpuTemperature.AutoSize = true;
            this.TargetCpuTemperature.Location = new System.Drawing.Point(6, 18);
            this.TargetCpuTemperature.Name = "TargetCpuTemperature";
            this.TargetCpuTemperature.Size = new System.Drawing.Size(126, 13);
            this.TargetCpuTemperature.TabIndex = 0;
            this.TargetCpuTemperature.Text = "Target CPU Temperature";
            // 
            // cpuUsageGroupBox
            // 
            this.cpuUsageGroupBox.Controls.Add(this.label1);
            this.cpuUsageGroupBox.Controls.Add(this.label2);
            this.cpuUsageGroupBox.Controls.Add(this.maxCpuUsageNumeric);
            this.cpuUsageGroupBox.Controls.Add(this.minCpuUsageNumeric);
            this.cpuUsageGroupBox.Location = new System.Drawing.Point(15, 100);
            this.cpuUsageGroupBox.Name = "cpuUsageGroupBox";
            this.cpuUsageGroupBox.Size = new System.Drawing.Size(258, 74);
            this.cpuUsageGroupBox.TabIndex = 1;
            this.cpuUsageGroupBox.TabStop = false;
            this.cpuUsageGroupBox.Text = "CPU Usage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max CPU Usage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max CPU Usage";
            // 
            // maxCpuUsageNumeric
            // 
            this.maxCpuUsageNumeric.Location = new System.Drawing.Point(96, 43);
            this.maxCpuUsageNumeric.Name = "maxCpuUsageNumeric";
            this.maxCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.maxCpuUsageNumeric.TabIndex = 2;
            this.maxCpuUsageNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // minCpuUsageNumeric
            // 
            this.minCpuUsageNumeric.Location = new System.Drawing.Point(96, 17);
            this.minCpuUsageNumeric.Name = "minCpuUsageNumeric";
            this.minCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.minCpuUsageNumeric.TabIndex = 0;
            // 
            // powerTypeGroupBox
            // 
            this.powerTypeGroupBox.Controls.Add(this.dcPowerModeCheckBox);
            this.powerTypeGroupBox.Controls.Add(this.acPowerModeCheckBox);
            this.powerTypeGroupBox.Location = new System.Drawing.Point(15, 20);
            this.powerTypeGroupBox.Name = "powerTypeGroupBox";
            this.powerTypeGroupBox.Size = new System.Drawing.Size(258, 74);
            this.powerTypeGroupBox.TabIndex = 0;
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
            // cpuUsageTargetModeTabPage
            // 
            this.cpuUsageTargetModeTabPage.Location = new System.Drawing.Point(4, 22);
            this.cpuUsageTargetModeTabPage.Name = "cpuUsageTargetModeTabPage";
            this.cpuUsageTargetModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cpuUsageTargetModeTabPage.Size = new System.Drawing.Size(287, 350);
            this.cpuUsageTargetModeTabPage.TabIndex = 1;
            this.cpuUsageTargetModeTabPage.Text = "CPU Usage Target Mode";
            this.cpuUsageTargetModeTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentReadingGroupBox
            // 
            this.CurrentReadingGroupBox.Controls.Add(this.MaxCpuDcValueLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.MaxCpuAcValueLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.ActivePowerSchemeValueLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.DcMaxCpuLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.AcMaxCpuLabel);
            this.CurrentReadingGroupBox.Controls.Add(this.ActivePowerSchemeLabel);
            this.CurrentReadingGroupBox.Location = new System.Drawing.Point(15, 292);
            this.CurrentReadingGroupBox.Name = "CurrentReadingGroupBox";
            this.CurrentReadingGroupBox.Size = new System.Drawing.Size(258, 100);
            this.CurrentReadingGroupBox.TabIndex = 4;
            this.CurrentReadingGroupBox.TabStop = false;
            this.CurrentReadingGroupBox.Text = "Current Readings";
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
            // AcMaxCpuLabel
            // 
            this.AcMaxCpuLabel.AutoSize = true;
            this.AcMaxCpuLabel.Location = new System.Drawing.Point(6, 41);
            this.AcMaxCpuLabel.Name = "AcMaxCpuLabel";
            this.AcMaxCpuLabel.Size = new System.Drawing.Size(101, 13);
            this.AcMaxCpuLabel.TabIndex = 2;
            this.AcMaxCpuLabel.Text = "Max CPU on AC (%)";
            // 
            // DcMaxCpuLabel
            // 
            this.DcMaxCpuLabel.AutoSize = true;
            this.DcMaxCpuLabel.Location = new System.Drawing.Point(6, 70);
            this.DcMaxCpuLabel.Name = "DcMaxCpuLabel";
            this.DcMaxCpuLabel.Size = new System.Drawing.Size(102, 13);
            this.DcMaxCpuLabel.TabIndex = 3;
            this.DcMaxCpuLabel.Text = "Max CPU on DC (%)";
            // 
            // ActivePowerSchemeValueLabel
            // 
            this.ActivePowerSchemeValueLabel.AutoSize = true;
            this.ActivePowerSchemeValueLabel.Location = new System.Drawing.Point(128, 16);
            this.ActivePowerSchemeValueLabel.Name = "ActivePowerSchemeValueLabel";
            this.ActivePowerSchemeValueLabel.Size = new System.Drawing.Size(0, 13);
            this.ActivePowerSchemeValueLabel.TabIndex = 4;
            // 
            // MaxCpuAcValueLabel
            // 
            this.MaxCpuAcValueLabel.AutoSize = true;
            this.MaxCpuAcValueLabel.Location = new System.Drawing.Point(128, 41);
            this.MaxCpuAcValueLabel.Name = "MaxCpuAcValueLabel";
            this.MaxCpuAcValueLabel.Size = new System.Drawing.Size(0, 13);
            this.MaxCpuAcValueLabel.TabIndex = 5;
            // 
            // MaxCpuDcValueLabel
            // 
            this.MaxCpuDcValueLabel.AutoSize = true;
            this.MaxCpuDcValueLabel.Location = new System.Drawing.Point(128, 70);
            this.MaxCpuDcValueLabel.Name = "MaxCpuDcValueLabel";
            this.MaxCpuDcValueLabel.Size = new System.Drawing.Size(0, 13);
            this.MaxCpuDcValueLabel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 474);
            this.Controls.Add(this.TemperatureTargetModeTabPage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.TemperatureTargetModeTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.powerSettingsGroupBox.ResumeLayout(false);
            this.powerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).EndInit();
            this.cpuUsageGroupBox.ResumeLayout(false);
            this.cpuUsageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).EndInit();
            this.powerTypeGroupBox.ResumeLayout(false);
            this.powerTypeGroupBox.PerformLayout();
            this.CurrentReadingGroupBox.ResumeLayout(false);
            this.CurrentReadingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TemperatureTargetModeTabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox powerTypeGroupBox;
        private System.Windows.Forms.TabPage cpuUsageTargetModeTabPage;
        private System.Windows.Forms.CheckBox dcPowerModeCheckBox;
        private System.Windows.Forms.CheckBox acPowerModeCheckBox;
        private System.Windows.Forms.GroupBox cpuUsageGroupBox;
        private System.Windows.Forms.NumericUpDown maxCpuUsageNumeric;
        private System.Windows.Forms.NumericUpDown minCpuUsageNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox powerSettingsGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PowerSchemeLabel;
        private System.Windows.Forms.Label TargetCpuTemperature;
        private System.Windows.Forms.NumericUpDown TargetCpuTemperatureNumericUpDown;
        private System.Windows.Forms.Button TemperatureTargetModeToggleButton;
        private System.Windows.Forms.ComboBox CPUSensorsComboBox;
        private System.Windows.Forms.ComboBox PowerSchemesComboBox;
        private System.Windows.Forms.GroupBox CurrentReadingGroupBox;
        private System.Windows.Forms.Label MaxCpuDcValueLabel;
        private System.Windows.Forms.Label MaxCpuAcValueLabel;
        private System.Windows.Forms.Label ActivePowerSchemeValueLabel;
        private System.Windows.Forms.Label DcMaxCpuLabel;
        private System.Windows.Forms.Label AcMaxCpuLabel;
        private System.Windows.Forms.Label ActivePowerSchemeLabel;
    }
}

