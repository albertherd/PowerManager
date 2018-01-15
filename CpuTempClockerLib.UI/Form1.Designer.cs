namespace CpuTempClockerLib.UI
{
    partial class Form1
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
            this.temperatureTargetModeTabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.powerTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.dcPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.acPowerModeCheckBox = new System.Windows.Forms.CheckBox();
            this.cpuUsageTargetModeTabPage = new System.Windows.Forms.TabPage();
            this.cpuUsageGroupBox = new System.Windows.Forms.GroupBox();
            this.minCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxCpuUsageNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.temperatureTargetModeTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.powerTypeGroupBox.SuspendLayout();
            this.cpuUsageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // temperatureTargetModeTabPage
            // 
            this.temperatureTargetModeTabPage.Controls.Add(this.tabPage1);
            this.temperatureTargetModeTabPage.Controls.Add(this.cpuUsageTargetModeTabPage);
            this.temperatureTargetModeTabPage.Location = new System.Drawing.Point(12, 12);
            this.temperatureTargetModeTabPage.Name = "temperatureTargetModeTabPage";
            this.temperatureTargetModeTabPage.SelectedIndex = 0;
            this.temperatureTargetModeTabPage.Size = new System.Drawing.Size(617, 376);
            this.temperatureTargetModeTabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.cpuUsageGroupBox);
            this.tabPage1.Controls.Add(this.powerTypeGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(609, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Temperature Target Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // powerTypeGroupBox
            // 
            this.powerTypeGroupBox.Controls.Add(this.dcPowerModeCheckBox);
            this.powerTypeGroupBox.Controls.Add(this.acPowerModeCheckBox);
            this.powerTypeGroupBox.Location = new System.Drawing.Point(15, 20);
            this.powerTypeGroupBox.Name = "powerTypeGroupBox";
            this.powerTypeGroupBox.Size = new System.Drawing.Size(146, 74);
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
            this.cpuUsageTargetModeTabPage.Size = new System.Drawing.Size(609, 350);
            this.cpuUsageTargetModeTabPage.TabIndex = 1;
            this.cpuUsageTargetModeTabPage.Text = "CPU Usage Target Mode";
            this.cpuUsageTargetModeTabPage.UseVisualStyleBackColor = true;
            // 
            // cpuUsageGroupBox
            // 
            this.cpuUsageGroupBox.Controls.Add(this.label1);
            this.cpuUsageGroupBox.Controls.Add(this.label2);
            this.cpuUsageGroupBox.Controls.Add(this.maxCpuUsageNumeric);
            this.cpuUsageGroupBox.Controls.Add(this.minCpuUsageNumeric);
            this.cpuUsageGroupBox.Location = new System.Drawing.Point(15, 110);
            this.cpuUsageGroupBox.Name = "cpuUsageGroupBox";
            this.cpuUsageGroupBox.Size = new System.Drawing.Size(146, 74);
            this.cpuUsageGroupBox.TabIndex = 1;
            this.cpuUsageGroupBox.TabStop = false;
            this.cpuUsageGroupBox.Text = "CPU Usage";
            // 
            // minCpuUsageNumeric
            // 
            this.minCpuUsageNumeric.Location = new System.Drawing.Point(96, 17);
            this.minCpuUsageNumeric.Name = "minCpuUsageNumeric";
            this.minCpuUsageNumeric.Size = new System.Drawing.Size(44, 20);
            this.minCpuUsageNumeric.TabIndex = 0;
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(339, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 400);
            this.Controls.Add(this.temperatureTargetModeTabPage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.temperatureTargetModeTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.powerTypeGroupBox.ResumeLayout(false);
            this.powerTypeGroupBox.PerformLayout();
            this.cpuUsageGroupBox.ResumeLayout(false);
            this.cpuUsageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minCpuUsageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCpuUsageNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl temperatureTargetModeTabPage;
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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

