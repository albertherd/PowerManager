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
            this.temperatureTargetModePanel = new System.Windows.Forms.Panel();
            this.cpuPackageTemperatureLabelValue = new System.Windows.Forms.Label();
            this.cpuPackageTemperatureLabel = new System.Windows.Forms.Label();
            this.powerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSetTargetCPUState = new System.Windows.Forms.Button();
            this.TargetCpuTemperatureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TargetCpuTemperature = new System.Windows.Forms.Label();
            this.cpuUsageTargetModeTabPage = new System.Windows.Forms.TabPage();
            this.cpuUsageGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSetMaxCPUState = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maxCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TemperatureTargetModeTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.temperatureTargetModePanel.SuspendLayout();
            this.powerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).BeginInit();
            this.cpuUsageTargetModeTabPage.SuspendLayout();
            this.cpuUsageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // TemperatureTargetModeTabPage
            // 
            this.TemperatureTargetModeTabPage.Controls.Add(this.cpuUsageTargetModeTabPage);
            this.TemperatureTargetModeTabPage.Controls.Add(this.tabPage1);
            this.TemperatureTargetModeTabPage.Location = new System.Drawing.Point(5, 12);
            this.TemperatureTargetModeTabPage.Name = "TemperatureTargetModeTabPage";
            this.TemperatureTargetModeTabPage.SelectedIndex = 0;
            this.TemperatureTargetModeTabPage.Size = new System.Drawing.Size(295, 407);
            this.TemperatureTargetModeTabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.temperatureTargetModePanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temperature Target Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // temperatureTargetModePanel
            // 
            this.temperatureTargetModePanel.Controls.Add(this.label1);
            this.temperatureTargetModePanel.Controls.Add(this.powerSettingsGroupBox);
            this.temperatureTargetModePanel.Location = new System.Drawing.Point(15, 11);
            this.temperatureTargetModePanel.Name = "temperatureTargetModePanel";
            this.temperatureTargetModePanel.Size = new System.Drawing.Size(266, 339);
            this.temperatureTargetModePanel.TabIndex = 2;
            // 
            // cpuPackageTemperatureLabelValue
            // 
            this.cpuPackageTemperatureLabelValue.AutoSize = true;
            this.cpuPackageTemperatureLabelValue.Location = new System.Drawing.Point(156, 49);
            this.cpuPackageTemperatureLabelValue.Name = "cpuPackageTemperatureLabelValue";
            this.cpuPackageTemperatureLabelValue.Size = new System.Drawing.Size(0, 13);
            this.cpuPackageTemperatureLabelValue.TabIndex = 1;
            // 
            // cpuPackageTemperatureLabel
            // 
            this.cpuPackageTemperatureLabel.AutoSize = true;
            this.cpuPackageTemperatureLabel.Location = new System.Drawing.Point(6, 49);
            this.cpuPackageTemperatureLabel.Name = "cpuPackageTemperatureLabel";
            this.cpuPackageTemperatureLabel.Size = new System.Drawing.Size(144, 13);
            this.cpuPackageTemperatureLabel.TabIndex = 0;
            this.cpuPackageTemperatureLabel.Text = " CPU Package Temperature:";
            // 
            // powerSettingsGroupBox
            // 
            this.powerSettingsGroupBox.Controls.Add(this.cpuPackageTemperatureLabelValue);
            this.powerSettingsGroupBox.Controls.Add(this.btnSetTargetCPUState);
            this.powerSettingsGroupBox.Controls.Add(this.cpuPackageTemperatureLabel);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperatureNumericUpDown);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperature);
            this.powerSettingsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.powerSettingsGroupBox.Name = "powerSettingsGroupBox";
            this.powerSettingsGroupBox.Size = new System.Drawing.Size(258, 134);
            this.powerSettingsGroupBox.TabIndex = 2;
            this.powerSettingsGroupBox.TabStop = false;
            this.powerSettingsGroupBox.Text = "Temperature Target Mode";
            // 
            // btnSetTargetCPUState
            // 
            this.btnSetTargetCPUState.Location = new System.Drawing.Point(177, 94);
            this.btnSetTargetCPUState.Name = "btnSetTargetCPUState";
            this.btnSetTargetCPUState.Size = new System.Drawing.Size(75, 23);
            this.btnSetTargetCPUState.TabIndex = 1;
            this.btnSetTargetCPUState.Text = "Set";
            this.btnSetTargetCPUState.UseVisualStyleBackColor = true;
            this.btnSetTargetCPUState.Click += new System.EventHandler(this.btnSetTargetCPUState_Click);
            // 
            // TargetCpuTemperatureNumericUpDown
            // 
            this.TargetCpuTemperatureNumericUpDown.Location = new System.Drawing.Point(138, 16);
            this.TargetCpuTemperatureNumericUpDown.Name = "TargetCpuTemperatureNumericUpDown";
            this.TargetCpuTemperatureNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.TargetCpuTemperatureNumericUpDown.TabIndex = 4;
            this.TargetCpuTemperatureNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
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
            // cpuUsageTargetModeTabPage
            // 
            this.cpuUsageTargetModeTabPage.Controls.Add(this.cpuUsageGroupBox);
            this.cpuUsageTargetModeTabPage.Location = new System.Drawing.Point(4, 22);
            this.cpuUsageTargetModeTabPage.Name = "cpuUsageTargetModeTabPage";
            this.cpuUsageTargetModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cpuUsageTargetModeTabPage.Size = new System.Drawing.Size(287, 114);
            this.cpuUsageTargetModeTabPage.TabIndex = 1;
            this.cpuUsageTargetModeTabPage.Text = "CPU Usage Target Mode";
            this.cpuUsageTargetModeTabPage.UseVisualStyleBackColor = true;
            // 
            // cpuUsageGroupBox
            // 
            this.cpuUsageGroupBox.Controls.Add(this.btnSetMaxCPUState);
            this.cpuUsageGroupBox.Controls.Add(this.label2);
            this.cpuUsageGroupBox.Controls.Add(this.maxCpuUsageNumeric);
            this.cpuUsageGroupBox.Location = new System.Drawing.Point(6, 6);
            this.cpuUsageGroupBox.Name = "cpuUsageGroupBox";
            this.cpuUsageGroupBox.Size = new System.Drawing.Size(258, 74);
            this.cpuUsageGroupBox.TabIndex = 2;
            this.cpuUsageGroupBox.TabStop = false;
            this.cpuUsageGroupBox.Text = "CPU State Mode";
            // 
            // btnSetMaxCPUState
            // 
            this.btnSetMaxCPUState.Location = new System.Drawing.Point(177, 45);
            this.btnSetMaxCPUState.Name = "btnSetMaxCPUState";
            this.btnSetMaxCPUState.Size = new System.Drawing.Size(75, 23);
            this.btnSetMaxCPUState.TabIndex = 4;
            this.btnSetMaxCPUState.Text = "Set";
            this.btnSetMaxCPUState.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max CPU Usage";
            // 
            // maxCpuUsageNumeric
            // 
            this.maxCpuUsageNumeric.Location = new System.Drawing.Point(98, 23);
            this.maxCpuUsageNumeric.Name = "maxCpuUsageNumeric";
            this.maxCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.maxCpuUsageNumeric.TabIndex = 2;
            this.maxCpuUsageNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 479);
            this.Controls.Add(this.TemperatureTargetModeTabPage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.TemperatureTargetModeTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.temperatureTargetModePanel.ResumeLayout(false);
            this.temperatureTargetModePanel.PerformLayout();
            this.powerSettingsGroupBox.ResumeLayout(false);
            this.powerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).EndInit();
            this.cpuUsageTargetModeTabPage.ResumeLayout(false);
            this.cpuUsageGroupBox.ResumeLayout(false);
            this.cpuUsageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TemperatureTargetModeTabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage cpuUsageTargetModeTabPage;
        private System.Windows.Forms.GroupBox powerSettingsGroupBox;
        private System.Windows.Forms.Label TargetCpuTemperature;
        private System.Windows.Forms.NumericUpDown TargetCpuTemperatureNumericUpDown;
        private System.Windows.Forms.Panel temperatureTargetModePanel;
        private System.Windows.Forms.Button btnSetTargetCPUState;
        private System.Windows.Forms.Label cpuPackageTemperatureLabelValue;
        private System.Windows.Forms.Label cpuPackageTemperatureLabel;
        private System.Windows.Forms.GroupBox cpuUsageGroupBox;
        private System.Windows.Forms.Button btnSetMaxCPUState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxCpuUsageNumeric;
        private System.Windows.Forms.Label label1;
    }
}

