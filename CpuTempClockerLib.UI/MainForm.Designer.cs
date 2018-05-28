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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PowerModeTabPages = new System.Windows.Forms.TabControl();
            this.cpuUsageTargetModeTabPage = new System.Windows.Forms.TabPage();
            this.cpuUsageGroupBox = new System.Windows.Forms.GroupBox();
            this.persistUsageAfterExitingCheckBox = new System.Windows.Forms.CheckBox();
            this.btnSetMaxCPUState = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maxCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.powerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.TargetCpuTemperatureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TargetCpuTemperature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentMaxCPUUsagePercentage = new System.Windows.Forms.Label();
            this.cpuPackageTemperatureLabelValue = new System.Windows.Forms.Label();
            this.cpuPackageTemperatureLabel = new System.Windows.Forms.Label();
            this.btnSetTargetCPUState = new System.Windows.Forms.Button();
            this.PowerModeTabPages.SuspendLayout();
            this.cpuUsageTargetModeTabPage.SuspendLayout();
            this.cpuUsageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.powerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PowerModeTabPages
            // 
            this.PowerModeTabPages.Controls.Add(this.cpuUsageTargetModeTabPage);
            this.PowerModeTabPages.Controls.Add(this.tabPage1);
            this.PowerModeTabPages.Location = new System.Drawing.Point(5, 4);
            this.PowerModeTabPages.Name = "PowerModeTabPages";
            this.PowerModeTabPages.SelectedIndex = 0;
            this.PowerModeTabPages.Size = new System.Drawing.Size(295, 173);
            this.PowerModeTabPages.TabIndex = 0;
            this.PowerModeTabPages.Selected += new System.Windows.Forms.TabControlEventHandler(this.TemperatureTargetModeTabPage_Selected);
            // 
            // cpuUsageTargetModeTabPage
            // 
            this.cpuUsageTargetModeTabPage.Controls.Add(this.cpuUsageGroupBox);
            this.cpuUsageTargetModeTabPage.Location = new System.Drawing.Point(4, 22);
            this.cpuUsageTargetModeTabPage.Name = "cpuUsageTargetModeTabPage";
            this.cpuUsageTargetModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cpuUsageTargetModeTabPage.Size = new System.Drawing.Size(287, 147);
            this.cpuUsageTargetModeTabPage.TabIndex = 1;
            this.cpuUsageTargetModeTabPage.Text = "CPU Usage Target Mode";
            this.cpuUsageTargetModeTabPage.UseVisualStyleBackColor = true;
            // 
            // cpuUsageGroupBox
            // 
            this.cpuUsageGroupBox.Controls.Add(this.persistUsageAfterExitingCheckBox);
            this.cpuUsageGroupBox.Controls.Add(this.btnSetMaxCPUState);
            this.cpuUsageGroupBox.Controls.Add(this.label2);
            this.cpuUsageGroupBox.Controls.Add(this.maxCpuUsageNumeric);
            this.cpuUsageGroupBox.Location = new System.Drawing.Point(6, 6);
            this.cpuUsageGroupBox.Name = "cpuUsageGroupBox";
            this.cpuUsageGroupBox.Size = new System.Drawing.Size(275, 135);
            this.cpuUsageGroupBox.TabIndex = 2;
            this.cpuUsageGroupBox.TabStop = false;
            this.cpuUsageGroupBox.Text = "CPU State Mode";
            // 
            // persistUsageAfterExitingCheckBox
            // 
            this.persistUsageAfterExitingCheckBox.AutoSize = true;
            this.persistUsageAfterExitingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.persistUsageAfterExitingCheckBox.Location = new System.Drawing.Point(6, 50);
            this.persistUsageAfterExitingCheckBox.Name = "persistUsageAfterExitingCheckBox";
            this.persistUsageAfterExitingCheckBox.Size = new System.Drawing.Size(146, 17);
            this.persistUsageAfterExitingCheckBox.TabIndex = 5;
            this.persistUsageAfterExitingCheckBox.Text = "Persist usage after exiting";
            this.persistUsageAfterExitingCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnSetMaxCPUState
            // 
            this.btnSetMaxCPUState.Location = new System.Drawing.Point(194, 106);
            this.btnSetMaxCPUState.Name = "btnSetMaxCPUState";
            this.btnSetMaxCPUState.Size = new System.Drawing.Size(75, 23);
            this.btnSetMaxCPUState.TabIndex = 4;
            this.btnSetMaxCPUState.Text = "Set";
            this.btnSetMaxCPUState.UseVisualStyleBackColor = true;
            this.btnSetMaxCPUState.Click += new System.EventHandler(this.BtnSetMaxCPUState_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max CPU Usage:";
            // 
            // maxCpuUsageNumeric
            // 
            this.maxCpuUsageNumeric.Location = new System.Drawing.Point(108, 23);
            this.maxCpuUsageNumeric.Name = "maxCpuUsageNumeric";
            this.maxCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.maxCpuUsageNumeric.TabIndex = 2;
            this.maxCpuUsageNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.powerSettingsGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temperature Target Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // powerSettingsGroupBox
            // 
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperatureNumericUpDown);
            this.powerSettingsGroupBox.Controls.Add(this.TargetCpuTemperature);
            this.powerSettingsGroupBox.Controls.Add(this.label1);
            this.powerSettingsGroupBox.Controls.Add(this.lblCurrentMaxCPUUsagePercentage);
            this.powerSettingsGroupBox.Controls.Add(this.cpuPackageTemperatureLabelValue);
            this.powerSettingsGroupBox.Controls.Add(this.cpuPackageTemperatureLabel);
            this.powerSettingsGroupBox.Controls.Add(this.btnSetTargetCPUState);
            this.powerSettingsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.powerSettingsGroupBox.Name = "powerSettingsGroupBox";
            this.powerSettingsGroupBox.Size = new System.Drawing.Size(275, 135);
            this.powerSettingsGroupBox.TabIndex = 2;
            this.powerSettingsGroupBox.TabStop = false;
            this.powerSettingsGroupBox.Text = "Temperature Target Mode";
            this.powerSettingsGroupBox.Enter += new System.EventHandler(this.powerSettingsGroupBox_Enter);
            // 
            // TargetCpuTemperatureNumericUpDown
            // 
            this.TargetCpuTemperatureNumericUpDown.Location = new System.Drawing.Point(138, 23);
            this.TargetCpuTemperatureNumericUpDown.Name = "TargetCpuTemperatureNumericUpDown";
            this.TargetCpuTemperatureNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.TargetCpuTemperatureNumericUpDown.TabIndex = 10;
            this.TargetCpuTemperatureNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // TargetCpuTemperature
            // 
            this.TargetCpuTemperature.AutoSize = true;
            this.TargetCpuTemperature.Location = new System.Drawing.Point(6, 25);
            this.TargetCpuTemperature.Name = "TargetCpuTemperature";
            this.TargetCpuTemperature.Size = new System.Drawing.Size(126, 13);
            this.TargetCpuTemperature.TabIndex = 7;
            this.TargetCpuTemperature.Text = "Target CPU Temperature";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Current Max CPU Usage:";
            // 
            // lblCurrentMaxCPUUsagePercentage
            // 
            this.lblCurrentMaxCPUUsagePercentage.AutoSize = true;
            this.lblCurrentMaxCPUUsagePercentage.Location = new System.Drawing.Point(162, 75);
            this.lblCurrentMaxCPUUsagePercentage.Name = "lblCurrentMaxCPUUsagePercentage";
            this.lblCurrentMaxCPUUsagePercentage.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentMaxCPUUsagePercentage.TabIndex = 15;
            // 
            // cpuPackageTemperatureLabelValue
            // 
            this.cpuPackageTemperatureLabelValue.AutoSize = true;
            this.cpuPackageTemperatureLabelValue.Location = new System.Drawing.Point(162, 50);
            this.cpuPackageTemperatureLabelValue.Name = "cpuPackageTemperatureLabelValue";
            this.cpuPackageTemperatureLabelValue.Size = new System.Drawing.Size(0, 13);
            this.cpuPackageTemperatureLabelValue.TabIndex = 13;
            // 
            // cpuPackageTemperatureLabel
            // 
            this.cpuPackageTemperatureLabel.AutoSize = true;
            this.cpuPackageTemperatureLabel.Location = new System.Drawing.Point(6, 50);
            this.cpuPackageTemperatureLabel.Name = "cpuPackageTemperatureLabel";
            this.cpuPackageTemperatureLabel.Size = new System.Drawing.Size(141, 13);
            this.cpuPackageTemperatureLabel.TabIndex = 12;
            this.cpuPackageTemperatureLabel.Text = "CPU Package Temperature:";
            // 
            // btnSetTargetCPUState
            // 
            this.btnSetTargetCPUState.Location = new System.Drawing.Point(194, 106);
            this.btnSetTargetCPUState.Name = "btnSetTargetCPUState";
            this.btnSetTargetCPUState.Size = new System.Drawing.Size(75, 23);
            this.btnSetTargetCPUState.TabIndex = 1;
            this.btnSetTargetCPUState.Text = "Start";
            this.btnSetTargetCPUState.UseVisualStyleBackColor = true;
            this.btnSetTargetCPUState.Click += new System.EventHandler(this.BtnSetTargetCPUState_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 179);
            this.Controls.Add(this.PowerModeTabPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CPU Usage Tweaker";
            this.PowerModeTabPages.ResumeLayout(false);
            this.cpuUsageTargetModeTabPage.ResumeLayout(false);
            this.cpuUsageGroupBox.ResumeLayout(false);
            this.cpuUsageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.powerSettingsGroupBox.ResumeLayout(false);
            this.powerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCpuTemperatureNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PowerModeTabPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage cpuUsageTargetModeTabPage;
        private System.Windows.Forms.GroupBox cpuUsageGroupBox;
        private System.Windows.Forms.Button btnSetMaxCPUState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxCpuUsageNumeric;
        private System.Windows.Forms.GroupBox powerSettingsGroupBox;
        private System.Windows.Forms.Button btnSetTargetCPUState;
        private System.Windows.Forms.CheckBox persistUsageAfterExitingCheckBox;
        private System.Windows.Forms.NumericUpDown TargetCpuTemperatureNumericUpDown;
        private System.Windows.Forms.Label TargetCpuTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentMaxCPUUsagePercentage;
        private System.Windows.Forms.Label cpuPackageTemperatureLabelValue;
        private System.Windows.Forms.Label cpuPackageTemperatureLabel;
    }
}

