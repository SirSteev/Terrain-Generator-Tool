using System.Drawing;

namespace ImageModificationTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbxMain = new System.Windows.Forms.PictureBox();
            this.btnNoise = new System.Windows.Forms.Button();
            this.frequencyUpDown = new System.Windows.Forms.NumericUpDown();
            this.octaveUpDown = new System.Windows.Forms.NumericUpDown();
            this.lacunarityUpDown = new System.Windows.Forms.NumericUpDown();
            this.persistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.amplitudeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonColorMap = new System.Windows.Forms.RadioButton();
            this.radioButtonBlackWhiteMap = new System.Windows.Forms.RadioButton();
            this.waterWeatherBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonWaterTableMap = new System.Windows.Forms.RadioButton();
            this.useSeedCheckBox = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.randomSeedBtn = new System.Windows.Forms.Button();
            this.seedUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mapHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.mapWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.flattenPolesBtn = new System.Windows.Forms.Button();
            this.seamlessMeridianBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nudWeatheringDroplets = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.waterTableUpDown = new System.Windows.Forms.NumericUpDown();
            this.DrapMapBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.octaveUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lacunarityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persistanceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seedUpDown)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthUpDown)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeatheringDroplets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTableUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxMain
            // 
            this.pbxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxMain.Image = ((System.Drawing.Image)(resources.GetObject("pbxMain.Image")));
            this.pbxMain.Location = new System.Drawing.Point(12, 12);
            this.pbxMain.Name = "pbxMain";
            this.pbxMain.Size = new System.Drawing.Size(800, 500);
            this.pbxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMain.TabIndex = 0;
            this.pbxMain.TabStop = false;
            // 
            // btnNoise
            // 
            this.btnNoise.Location = new System.Drawing.Point(3, 208);
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(59, 23);
            this.btnNoise.TabIndex = 1;
            this.btnNoise.Text = "Generate Noise";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // frequencyUpDown
            // 
            this.frequencyUpDown.DecimalPlaces = 1;
            this.frequencyUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.frequencyUpDown.Location = new System.Drawing.Point(7, 19);
            this.frequencyUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frequencyUpDown.Name = "frequencyUpDown";
            this.frequencyUpDown.Size = new System.Drawing.Size(53, 20);
            this.frequencyUpDown.TabIndex = 4;
            this.frequencyUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // octaveUpDown
            // 
            this.octaveUpDown.Location = new System.Drawing.Point(7, 61);
            this.octaveUpDown.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.octaveUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.octaveUpDown.Name = "octaveUpDown";
            this.octaveUpDown.Size = new System.Drawing.Size(53, 20);
            this.octaveUpDown.TabIndex = 5;
            this.octaveUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lacunarityUpDown
            // 
            this.lacunarityUpDown.DecimalPlaces = 1;
            this.lacunarityUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lacunarityUpDown.Location = new System.Drawing.Point(7, 103);
            this.lacunarityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lacunarityUpDown.Name = "lacunarityUpDown";
            this.lacunarityUpDown.Size = new System.Drawing.Size(53, 20);
            this.lacunarityUpDown.TabIndex = 6;
            this.lacunarityUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // persistanceUpDown
            // 
            this.persistanceUpDown.DecimalPlaces = 1;
            this.persistanceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.persistanceUpDown.Location = new System.Drawing.Point(6, 142);
            this.persistanceUpDown.Name = "persistanceUpDown";
            this.persistanceUpDown.Size = new System.Drawing.Size(54, 20);
            this.persistanceUpDown.TabIndex = 7;
            this.persistanceUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Frequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Octave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lacunarity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Persistance";
            // 
            // amplitudeUpDown
            // 
            this.amplitudeUpDown.Location = new System.Drawing.Point(6, 182);
            this.amplitudeUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.amplitudeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amplitudeUpDown.Name = "amplitudeUpDown";
            this.amplitudeUpDown.Size = new System.Drawing.Size(54, 20);
            this.amplitudeUpDown.TabIndex = 12;
            this.amplitudeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Amplitude";
            // 
            // radioButtonColorMap
            // 
            this.radioButtonColorMap.AutoSize = true;
            this.radioButtonColorMap.Checked = true;
            this.radioButtonColorMap.Location = new System.Drawing.Point(3, 3);
            this.radioButtonColorMap.Name = "radioButtonColorMap";
            this.radioButtonColorMap.Size = new System.Drawing.Size(107, 17);
            this.radioButtonColorMap.TabIndex = 14;
            this.radioButtonColorMap.TabStop = true;
            this.radioButtonColorMap.Text = "Color Height Map";
            this.radioButtonColorMap.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlackWhiteMap
            // 
            this.radioButtonBlackWhiteMap.AutoSize = true;
            this.radioButtonBlackWhiteMap.Location = new System.Drawing.Point(2, 24);
            this.radioButtonBlackWhiteMap.Name = "radioButtonBlackWhiteMap";
            this.radioButtonBlackWhiteMap.Size = new System.Drawing.Size(162, 17);
            this.radioButtonBlackWhiteMap.TabIndex = 15;
            this.radioButtonBlackWhiteMap.Text = "Black and White Height Map";
            this.radioButtonBlackWhiteMap.UseVisualStyleBackColor = true;
            // 
            // waterWeatherBtn
            // 
            this.waterWeatherBtn.Enabled = false;
            this.waterWeatherBtn.Location = new System.Drawing.Point(6, 42);
            this.waterWeatherBtn.Name = "waterWeatherBtn";
            this.waterWeatherBtn.Size = new System.Drawing.Size(158, 23);
            this.waterWeatherBtn.TabIndex = 16;
            this.waterWeatherBtn.Text = "Water Weathering/Erosion";
            this.waterWeatherBtn.UseVisualStyleBackColor = true;
            this.waterWeatherBtn.Click += new System.EventHandler(this.waterWeatherBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1004, 489);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.amplitudeUpDown);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.frequencyUpDown);
            this.panel1.Controls.Add(this.octaveUpDown);
            this.panel1.Controls.Add(this.lacunarityUpDown);
            this.panel1.Controls.Add(this.persistanceUpDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNoise);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(818, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 237);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButtonWaterTableMap);
            this.panel2.Controls.Add(this.radioButtonColorMap);
            this.panel2.Controls.Add(this.radioButtonBlackWhiteMap);
            this.panel2.Location = new System.Drawing.Point(900, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 72);
            this.panel2.TabIndex = 19;
            // 
            // radioButtonWaterTableMap
            // 
            this.radioButtonWaterTableMap.AutoSize = true;
            this.radioButtonWaterTableMap.Location = new System.Drawing.Point(0, 46);
            this.radioButtonWaterTableMap.Name = "radioButtonWaterTableMap";
            this.radioButtonWaterTableMap.Size = new System.Drawing.Size(142, 17);
            this.radioButtonWaterTableMap.TabIndex = 16;
            this.radioButtonWaterTableMap.Text = "Water Table Height Map";
            this.radioButtonWaterTableMap.UseVisualStyleBackColor = true;
            // 
            // useSeedCheckBox
            // 
            this.useSeedCheckBox.AutoSize = true;
            this.useSeedCheckBox.Checked = true;
            this.useSeedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSeedCheckBox.Location = new System.Drawing.Point(3, 3);
            this.useSeedCheckBox.Name = "useSeedCheckBox";
            this.useSeedCheckBox.Size = new System.Drawing.Size(73, 17);
            this.useSeedCheckBox.TabIndex = 20;
            this.useSeedCheckBox.Text = "Use Seed";
            this.useSeedCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.randomSeedBtn);
            this.panel3.Controls.Add(this.seedUpDown);
            this.panel3.Controls.Add(this.useSeedCheckBox);
            this.panel3.Location = new System.Drawing.Point(900, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 45);
            this.panel3.TabIndex = 21;
            // 
            // randomSeedBtn
            // 
            this.randomSeedBtn.Location = new System.Drawing.Point(129, 16);
            this.randomSeedBtn.Name = "randomSeedBtn";
            this.randomSeedBtn.Size = new System.Drawing.Size(75, 23);
            this.randomSeedBtn.TabIndex = 21;
            this.randomSeedBtn.Text = "Random";
            this.randomSeedBtn.UseVisualStyleBackColor = true;
            this.randomSeedBtn.Click += new System.EventHandler(this.randomSeedBtn_Click);
            // 
            // seedUpDown
            // 
            this.seedUpDown.Location = new System.Drawing.Point(3, 19);
            this.seedUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.seedUpDown.Name = "seedUpDown";
            this.seedUpDown.Size = new System.Drawing.Size(120, 20);
            this.seedUpDown.TabIndex = 0;
            this.seedUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.mapHeightUpDown);
            this.panel4.Controls.Add(this.mapWidthUpDown);
            this.panel4.Location = new System.Drawing.Point(900, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(137, 81);
            this.panel4.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Map Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Map Width";
            // 
            // mapHeightUpDown
            // 
            this.mapHeightUpDown.Location = new System.Drawing.Point(6, 55);
            this.mapHeightUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.mapHeightUpDown.Name = "mapHeightUpDown";
            this.mapHeightUpDown.Size = new System.Drawing.Size(120, 20);
            this.mapHeightUpDown.TabIndex = 1;
            // 
            // mapWidthUpDown
            // 
            this.mapWidthUpDown.Location = new System.Drawing.Point(6, 16);
            this.mapWidthUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.mapWidthUpDown.Name = "mapWidthUpDown";
            this.mapWidthUpDown.Size = new System.Drawing.Size(120, 20);
            this.mapWidthUpDown.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(826, 489);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 23;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // flattenPolesBtn
            // 
            this.flattenPolesBtn.Enabled = false;
            this.flattenPolesBtn.Location = new System.Drawing.Point(3, 32);
            this.flattenPolesBtn.Name = "flattenPolesBtn";
            this.flattenPolesBtn.Size = new System.Drawing.Size(76, 23);
            this.flattenPolesBtn.TabIndex = 24;
            this.flattenPolesBtn.Text = "Flatten Poles";
            this.flattenPolesBtn.UseVisualStyleBackColor = true;
            this.flattenPolesBtn.Click += new System.EventHandler(this.flattenPolesBtn_Click);
            // 
            // seamlessMeridianBtn
            // 
            this.seamlessMeridianBtn.Enabled = false;
            this.seamlessMeridianBtn.Location = new System.Drawing.Point(3, 3);
            this.seamlessMeridianBtn.Name = "seamlessMeridianBtn";
            this.seamlessMeridianBtn.Size = new System.Drawing.Size(137, 23);
            this.seamlessMeridianBtn.TabIndex = 25;
            this.seamlessMeridianBtn.Text = "Seamless Meridian";
            this.seamlessMeridianBtn.UseVisualStyleBackColor = true;
            this.seamlessMeridianBtn.Click += new System.EventHandler(this.seamlessMeridianBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.seamlessMeridianBtn);
            this.panel5.Controls.Add(this.flattenPolesBtn);
            this.panel5.Location = new System.Drawing.Point(816, 304);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(147, 61);
            this.panel5.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.nudWeatheringDroplets);
            this.panel6.Controls.Add(this.waterWeatherBtn);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(877, 391);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(174, 71);
            this.panel6.TabIndex = 27;
            // 
            // nudWeatheringDroplets
            // 
            this.nudWeatheringDroplets.Location = new System.Drawing.Point(6, 16);
            this.nudWeatheringDroplets.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudWeatheringDroplets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeatheringDroplets.Name = "nudWeatheringDroplets";
            this.nudWeatheringDroplets.Size = new System.Drawing.Size(54, 20);
            this.nudWeatheringDroplets.TabIndex = 14;
            this.nudWeatheringDroplets.Value = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Number of Droplets";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(818, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Noise Controls";
            // 
            // waterTableUpDown
            // 
            this.waterTableUpDown.DecimalPlaces = 2;
            this.waterTableUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.waterTableUpDown.Location = new System.Drawing.Point(903, 278);
            this.waterTableUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waterTableUpDown.Name = "waterTableUpDown";
            this.waterTableUpDown.Size = new System.Drawing.Size(120, 20);
            this.waterTableUpDown.TabIndex = 29;
            this.waterTableUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            // 
            // DrapMapBtn
            // 
            this.DrapMapBtn.Location = new System.Drawing.Point(907, 489);
            this.DrapMapBtn.Name = "DrapMapBtn";
            this.DrapMapBtn.Size = new System.Drawing.Size(75, 23);
            this.DrapMapBtn.TabIndex = 30;
            this.DrapMapBtn.Text = "Draw Map";
            this.DrapMapBtn.UseVisualStyleBackColor = true;
            this.DrapMapBtn.Click += new System.EventHandler(this.DrapMapBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(900, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Water Table Height";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 527);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DrapMapBtn);
            this.Controls.Add(this.waterTableUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pbxMain);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.octaveUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lacunarityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persistanceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seedUpDown)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthUpDown)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeatheringDroplets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTableUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxMain;
        private System.Windows.Forms.Button btnNoise;
        private System.Windows.Forms.NumericUpDown frequencyUpDown;
        private System.Windows.Forms.NumericUpDown octaveUpDown;
        private System.Windows.Forms.NumericUpDown lacunarityUpDown;
        private System.Windows.Forms.NumericUpDown persistanceUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown amplitudeUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonColorMap;
        private System.Windows.Forms.RadioButton radioButtonBlackWhiteMap;
        private System.Windows.Forms.Button waterWeatherBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox useSeedCheckBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown seedUpDown;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown mapWidthUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown mapHeightUpDown;
        private System.Windows.Forms.Button randomSeedBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button flattenPolesBtn;
        private System.Windows.Forms.Button seamlessMeridianBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown waterTableUpDown;
        private System.Windows.Forms.Button DrapMapBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButtonWaterTableMap;
        private System.Windows.Forms.NumericUpDown nudWeatheringDroplets;
        private System.Windows.Forms.Label label10;
    }
}

