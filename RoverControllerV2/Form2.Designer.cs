namespace RoverControllerV2
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ResolutionCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FPS_num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.QualityTrackBar = new System.Windows.Forms.TrackBar();
            this.BrightnessTrackbar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.ContrastTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.SaturationTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.SpecialEffectCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AWB = new System.Windows.Forms.CheckBox();
            this.AWB_Gain_CheckBox = new System.Windows.Forms.CheckBox();
            this.WB_Combo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AEC_SENSOR_CheckBox = new System.Windows.Forms.CheckBox();
            this.ExposureTrackBar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.AEC_DSP_CheckBox = new System.Windows.Forms.CheckBox();
            this.AE_LevelTrackBar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.AGC_CheckBox = new System.Windows.Forms.CheckBox();
            this.GainTrackBar = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.GainCeilingTrackBar = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.BPC_CheckBox = new System.Windows.Forms.CheckBox();
            this.WPC_CheckBox = new System.Windows.Forms.CheckBox();
            this.RawGMA_CheckBox = new System.Windows.Forms.CheckBox();
            this.LensCorrectionCheckBox = new System.Windows.Forms.CheckBox();
            this.H_MirrorCheckBox = new System.Windows.Forms.CheckBox();
            this.V_FlipCheckBox = new System.Windows.Forms.CheckBox();
            this.DCW_CheckBox = new System.Windows.Forms.CheckBox();
            this.ColorBarCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExposureTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AE_LevelTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GainTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GainCeilingTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution :";
            // 
            // ResolutionCombo
            // 
            this.ResolutionCombo.FormattingEnabled = true;
            this.ResolutionCombo.Items.AddRange(new object[] {
            "UXGA(1600x1200)",
            "SXGA(1280x1024)",
            "HD(1280x720)",
            "XGA(1024x768)",
            "SVGA(800x600)",
            "VGA(640x480)",
            "HVGA(480x320)",
            "CIF(400x296)",
            "QVGA(320x240)",
            "240x240",
            "HQVGA(240x176) ",
            "QCIF(176x144)",
            "QQVGA(160x120)",
            "96x96"});
            this.ResolutionCombo.Location = new System.Drawing.Point(96, 17);
            this.ResolutionCombo.Name = "ResolutionCombo";
            this.ResolutionCombo.Size = new System.Drawing.Size(121, 21);
            this.ResolutionCombo.TabIndex = 1;
            this.ResolutionCombo.SelectedIndexChanged += new System.EventHandler(this.ResolutionCombo_SelectedIndexChanged);
            this.ResolutionCombo.SelectedValueChanged += new System.EventHandler(this.ResolutionCombo_SelectedValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 740);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frame Rate :";
            // 
            // FPS_num
            // 
            this.FPS_num.Location = new System.Drawing.Point(96, 44);
            this.FPS_num.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FPS_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_num.Name = "FPS_num";
            this.FPS_num.Size = new System.Drawing.Size(120, 20);
            this.FPS_num.TabIndex = 5;
            this.FPS_num.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.FPS_num.ValueChanged += new System.EventHandler(this.FPS_num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quality :";
            // 
            // QualityTrackBar
            // 
            this.QualityTrackBar.Location = new System.Drawing.Point(96, 73);
            this.QualityTrackBar.Maximum = 63;
            this.QualityTrackBar.Minimum = 4;
            this.QualityTrackBar.Name = "QualityTrackBar";
            this.QualityTrackBar.Size = new System.Drawing.Size(121, 45);
            this.QualityTrackBar.TabIndex = 7;
            this.QualityTrackBar.Value = 4;
            this.QualityTrackBar.ValueChanged += new System.EventHandler(this.QualityTrackBar_ValueChanged);
            // 
            // BrightnessTrackbar
            // 
            this.BrightnessTrackbar.Location = new System.Drawing.Point(95, 124);
            this.BrightnessTrackbar.Maximum = 2;
            this.BrightnessTrackbar.Minimum = -2;
            this.BrightnessTrackbar.Name = "BrightnessTrackbar";
            this.BrightnessTrackbar.Size = new System.Drawing.Size(121, 45);
            this.BrightnessTrackbar.TabIndex = 9;
            this.BrightnessTrackbar.ValueChanged += new System.EventHandler(this.BrightnessTrackbar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Brightness :";
            // 
            // ContrastTrackBar
            // 
            this.ContrastTrackBar.Location = new System.Drawing.Point(95, 175);
            this.ContrastTrackBar.Maximum = 2;
            this.ContrastTrackBar.Minimum = -2;
            this.ContrastTrackBar.Name = "ContrastTrackBar";
            this.ContrastTrackBar.Size = new System.Drawing.Size(121, 45);
            this.ContrastTrackBar.TabIndex = 11;
            this.ContrastTrackBar.ValueChanged += new System.EventHandler(this.ContrastTrackBar_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contrast :";
            // 
            // SaturationTrackBar
            // 
            this.SaturationTrackBar.Location = new System.Drawing.Point(95, 226);
            this.SaturationTrackBar.Maximum = 2;
            this.SaturationTrackBar.Minimum = -2;
            this.SaturationTrackBar.Name = "SaturationTrackBar";
            this.SaturationTrackBar.Size = new System.Drawing.Size(121, 45);
            this.SaturationTrackBar.TabIndex = 13;
            this.SaturationTrackBar.ValueChanged += new System.EventHandler(this.SaturationTrackBar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saturation :";
            // 
            // SpecialEffectCombo
            // 
            this.SpecialEffectCombo.FormattingEnabled = true;
            this.SpecialEffectCombo.Items.AddRange(new object[] {
            "No Effect             ",
            "Negative",
            "Grayscale                       ",
            "Red Tint",
            "Green Tint                     ",
            "Blue Tint",
            "Sepia"});
            this.SpecialEffectCombo.Location = new System.Drawing.Point(96, 276);
            this.SpecialEffectCombo.Name = "SpecialEffectCombo";
            this.SpecialEffectCombo.Size = new System.Drawing.Size(121, 21);
            this.SpecialEffectCombo.TabIndex = 15;
            this.SpecialEffectCombo.SelectedIndexChanged += new System.EventHandler(this.SpecialEffectCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Special Effect :";
            // 
            // AWB
            // 
            this.AWB.AutoSize = true;
            this.AWB.Location = new System.Drawing.Point(15, 313);
            this.AWB.Name = "AWB";
            this.AWB.Size = new System.Drawing.Size(51, 17);
            this.AWB.TabIndex = 17;
            this.AWB.Text = "AWB";
            this.AWB.UseVisualStyleBackColor = true;
            this.AWB.CheckedChanged += new System.EventHandler(this.AWB_CheckedChanged);
            // 
            // AWB_Gain_CheckBox
            // 
            this.AWB_Gain_CheckBox.AutoSize = true;
            this.AWB_Gain_CheckBox.Location = new System.Drawing.Point(15, 336);
            this.AWB_Gain_CheckBox.Name = "AWB_Gain_CheckBox";
            this.AWB_Gain_CheckBox.Size = new System.Drawing.Size(76, 17);
            this.AWB_Gain_CheckBox.TabIndex = 18;
            this.AWB_Gain_CheckBox.Text = "AWB Gain";
            this.AWB_Gain_CheckBox.UseVisualStyleBackColor = true;
            this.AWB_Gain_CheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // WB_Combo
            // 
            this.WB_Combo.Enabled = false;
            this.WB_Combo.FormattingEnabled = true;
            this.WB_Combo.Items.AddRange(new object[] {
            "Auto",
            "Sunny",
            "Cloudy",
            "Office",
            "Home"});
            this.WB_Combo.Location = new System.Drawing.Point(197, 334);
            this.WB_Combo.Name = "WB_Combo";
            this.WB_Combo.Size = new System.Drawing.Size(121, 21);
            this.WB_Combo.TabIndex = 20;
            this.WB_Combo.SelectedIndexChanged += new System.EventHandler(this.WB_Combo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(130, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "WB Mode :";
            // 
            // AEC_SENSOR_CheckBox
            // 
            this.AEC_SENSOR_CheckBox.AutoSize = true;
            this.AEC_SENSOR_CheckBox.Location = new System.Drawing.Point(12, 380);
            this.AEC_SENSOR_CheckBox.Name = "AEC_SENSOR_CheckBox";
            this.AEC_SENSOR_CheckBox.Size = new System.Drawing.Size(95, 17);
            this.AEC_SENSOR_CheckBox.TabIndex = 21;
            this.AEC_SENSOR_CheckBox.Text = "AEC SENSOR";
            this.AEC_SENSOR_CheckBox.UseVisualStyleBackColor = true;
            this.AEC_SENSOR_CheckBox.CheckedChanged += new System.EventHandler(this.AEC_SENSOR_CheckBox_CheckedChanged);
            // 
            // ExposureTrackBar
            // 
            this.ExposureTrackBar.Location = new System.Drawing.Point(197, 375);
            this.ExposureTrackBar.Maximum = 1200;
            this.ExposureTrackBar.Name = "ExposureTrackBar";
            this.ExposureTrackBar.Size = new System.Drawing.Size(121, 45);
            this.ExposureTrackBar.TabIndex = 22;
            this.ExposureTrackBar.ValueChanged += new System.EventHandler(this.ExposureTrackBar_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Exposure :";
            // 
            // AEC_DSP_CheckBox
            // 
            this.AEC_DSP_CheckBox.AutoSize = true;
            this.AEC_DSP_CheckBox.Location = new System.Drawing.Point(12, 423);
            this.AEC_DSP_CheckBox.Name = "AEC_DSP_CheckBox";
            this.AEC_DSP_CheckBox.Size = new System.Drawing.Size(72, 17);
            this.AEC_DSP_CheckBox.TabIndex = 24;
            this.AEC_DSP_CheckBox.Text = "AEC DSP";
            this.AEC_DSP_CheckBox.UseVisualStyleBackColor = true;
            this.AEC_DSP_CheckBox.CheckedChanged += new System.EventHandler(this.AEC_DSP_CheckBox_CheckedChanged);
            // 
            // AE_LevelTrackBar
            // 
            this.AE_LevelTrackBar.Location = new System.Drawing.Point(95, 452);
            this.AE_LevelTrackBar.Maximum = 2;
            this.AE_LevelTrackBar.Minimum = -2;
            this.AE_LevelTrackBar.Name = "AE_LevelTrackBar";
            this.AE_LevelTrackBar.Size = new System.Drawing.Size(121, 45);
            this.AE_LevelTrackBar.TabIndex = 26;
            this.AE_LevelTrackBar.ValueChanged += new System.EventHandler(this.AE_LevelTrackBar_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "AE Level :";
            // 
            // AGC_CheckBox
            // 
            this.AGC_CheckBox.AutoSize = true;
            this.AGC_CheckBox.Location = new System.Drawing.Point(12, 504);
            this.AGC_CheckBox.Name = "AGC_CheckBox";
            this.AGC_CheckBox.Size = new System.Drawing.Size(48, 17);
            this.AGC_CheckBox.TabIndex = 27;
            this.AGC_CheckBox.Text = "AGC";
            this.AGC_CheckBox.UseVisualStyleBackColor = true;
            this.AGC_CheckBox.CheckedChanged += new System.EventHandler(this.AGC_CheckBox_CheckedChanged);
            // 
            // GainTrackBar
            // 
            this.GainTrackBar.Location = new System.Drawing.Point(197, 504);
            this.GainTrackBar.Maximum = 30;
            this.GainTrackBar.Name = "GainTrackBar";
            this.GainTrackBar.Size = new System.Drawing.Size(121, 45);
            this.GainTrackBar.TabIndex = 29;
            this.GainTrackBar.ValueChanged += new System.EventHandler(this.GainTrackBar_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 508);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Gain :";
            // 
            // GainCeilingTrackBar
            // 
            this.GainCeilingTrackBar.Enabled = false;
            this.GainCeilingTrackBar.Location = new System.Drawing.Point(197, 555);
            this.GainCeilingTrackBar.Maximum = 6;
            this.GainCeilingTrackBar.Name = "GainCeilingTrackBar";
            this.GainCeilingTrackBar.Size = new System.Drawing.Size(121, 45);
            this.GainCeilingTrackBar.TabIndex = 31;
            this.GainCeilingTrackBar.ValueChanged += new System.EventHandler(this.GainCeilingTrackBar_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(130, 559);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Gain Ceiling :";
            // 
            // BPC_CheckBox
            // 
            this.BPC_CheckBox.AutoSize = true;
            this.BPC_CheckBox.Location = new System.Drawing.Point(12, 619);
            this.BPC_CheckBox.Name = "BPC_CheckBox";
            this.BPC_CheckBox.Size = new System.Drawing.Size(47, 17);
            this.BPC_CheckBox.TabIndex = 32;
            this.BPC_CheckBox.Text = "BPC";
            this.BPC_CheckBox.UseVisualStyleBackColor = true;
            this.BPC_CheckBox.CheckedChanged += new System.EventHandler(this.BPC_CheckBox_CheckedChanged);
            // 
            // WPC_CheckBox
            // 
            this.WPC_CheckBox.AutoSize = true;
            this.WPC_CheckBox.Location = new System.Drawing.Point(12, 642);
            this.WPC_CheckBox.Name = "WPC_CheckBox";
            this.WPC_CheckBox.Size = new System.Drawing.Size(51, 17);
            this.WPC_CheckBox.TabIndex = 33;
            this.WPC_CheckBox.Text = "WPC";
            this.WPC_CheckBox.UseVisualStyleBackColor = true;
            this.WPC_CheckBox.CheckedChanged += new System.EventHandler(this.WPC_CheckBox_CheckedChanged);
            // 
            // RawGMA_CheckBox
            // 
            this.RawGMA_CheckBox.AutoSize = true;
            this.RawGMA_CheckBox.Location = new System.Drawing.Point(12, 665);
            this.RawGMA_CheckBox.Name = "RawGMA_CheckBox";
            this.RawGMA_CheckBox.Size = new System.Drawing.Size(75, 17);
            this.RawGMA_CheckBox.TabIndex = 34;
            this.RawGMA_CheckBox.Text = "Raw GMA";
            this.RawGMA_CheckBox.UseVisualStyleBackColor = true;
            this.RawGMA_CheckBox.CheckedChanged += new System.EventHandler(this.RawGMA_CheckBox_CheckedChanged);
            // 
            // LensCorrectionCheckBox
            // 
            this.LensCorrectionCheckBox.AutoSize = true;
            this.LensCorrectionCheckBox.Location = new System.Drawing.Point(12, 688);
            this.LensCorrectionCheckBox.Name = "LensCorrectionCheckBox";
            this.LensCorrectionCheckBox.Size = new System.Drawing.Size(100, 17);
            this.LensCorrectionCheckBox.TabIndex = 35;
            this.LensCorrectionCheckBox.Text = "Lens Correction";
            this.LensCorrectionCheckBox.UseVisualStyleBackColor = true;
            this.LensCorrectionCheckBox.CheckedChanged += new System.EventHandler(this.LensCorrectionCheckBox_CheckedChanged);
            // 
            // H_MirrorCheckBox
            // 
            this.H_MirrorCheckBox.AutoSize = true;
            this.H_MirrorCheckBox.Location = new System.Drawing.Point(133, 619);
            this.H_MirrorCheckBox.Name = "H_MirrorCheckBox";
            this.H_MirrorCheckBox.Size = new System.Drawing.Size(63, 17);
            this.H_MirrorCheckBox.TabIndex = 36;
            this.H_MirrorCheckBox.Text = "H-Mirror";
            this.H_MirrorCheckBox.UseVisualStyleBackColor = true;
            this.H_MirrorCheckBox.CheckedChanged += new System.EventHandler(this.H_MirrorCheckBox_CheckedChanged);
            // 
            // V_FlipCheckBox
            // 
            this.V_FlipCheckBox.AutoSize = true;
            this.V_FlipCheckBox.Location = new System.Drawing.Point(133, 642);
            this.V_FlipCheckBox.Name = "V_FlipCheckBox";
            this.V_FlipCheckBox.Size = new System.Drawing.Size(52, 17);
            this.V_FlipCheckBox.TabIndex = 37;
            this.V_FlipCheckBox.Text = "V-Flip";
            this.V_FlipCheckBox.UseVisualStyleBackColor = true;
            this.V_FlipCheckBox.CheckedChanged += new System.EventHandler(this.V_FlipCheckBox_CheckedChanged);
            // 
            // DCW_CheckBox
            // 
            this.DCW_CheckBox.AutoSize = true;
            this.DCW_CheckBox.Location = new System.Drawing.Point(133, 665);
            this.DCW_CheckBox.Name = "DCW_CheckBox";
            this.DCW_CheckBox.Size = new System.Drawing.Size(125, 17);
            this.DCW_CheckBox.TabIndex = 38;
            this.DCW_CheckBox.Text = "DCW (Downsize EN)";
            this.DCW_CheckBox.UseVisualStyleBackColor = true;
            this.DCW_CheckBox.CheckedChanged += new System.EventHandler(this.DCW_CheckBox_CheckedChanged);
            // 
            // ColorBarCheckBox
            // 
            this.ColorBarCheckBox.AutoSize = true;
            this.ColorBarCheckBox.Location = new System.Drawing.Point(133, 688);
            this.ColorBarCheckBox.Name = "ColorBarCheckBox";
            this.ColorBarCheckBox.Size = new System.Drawing.Size(69, 17);
            this.ColorBarCheckBox.TabIndex = 39;
            this.ColorBarCheckBox.Text = "Color Bar";
            this.ColorBarCheckBox.UseVisualStyleBackColor = true;
            this.ColorBarCheckBox.CheckedChanged += new System.EventHandler(this.ColorBarCheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 775);
            this.Controls.Add(this.ColorBarCheckBox);
            this.Controls.Add(this.DCW_CheckBox);
            this.Controls.Add(this.V_FlipCheckBox);
            this.Controls.Add(this.H_MirrorCheckBox);
            this.Controls.Add(this.LensCorrectionCheckBox);
            this.Controls.Add(this.RawGMA_CheckBox);
            this.Controls.Add(this.WPC_CheckBox);
            this.Controls.Add(this.BPC_CheckBox);
            this.Controls.Add(this.GainCeilingTrackBar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GainTrackBar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AGC_CheckBox);
            this.Controls.Add(this.AE_LevelTrackBar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AEC_DSP_CheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ExposureTrackBar);
            this.Controls.Add(this.AEC_SENSOR_CheckBox);
            this.Controls.Add(this.WB_Combo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AWB_Gain_CheckBox);
            this.Controls.Add(this.AWB);
            this.Controls.Add(this.SpecialEffectCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaturationTrackBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ContrastTrackBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BrightnessTrackbar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QualityTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FPS_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResolutionCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FPS_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExposureTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AE_LevelTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GainTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GainCeilingTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ResolutionCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown FPS_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar QualityTrackBar;
        private System.Windows.Forms.TrackBar BrightnessTrackbar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar ContrastTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar SaturationTrackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SpecialEffectCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox AWB;
        private System.Windows.Forms.CheckBox AWB_Gain_CheckBox;
        private System.Windows.Forms.ComboBox WB_Combo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox AEC_SENSOR_CheckBox;
        private System.Windows.Forms.TrackBar ExposureTrackBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox AEC_DSP_CheckBox;
        private System.Windows.Forms.TrackBar AE_LevelTrackBar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox AGC_CheckBox;
        private System.Windows.Forms.TrackBar GainTrackBar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar GainCeilingTrackBar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox BPC_CheckBox;
        private System.Windows.Forms.CheckBox WPC_CheckBox;
        private System.Windows.Forms.CheckBox RawGMA_CheckBox;
        private System.Windows.Forms.CheckBox LensCorrectionCheckBox;
        private System.Windows.Forms.CheckBox H_MirrorCheckBox;
        private System.Windows.Forms.CheckBox V_FlipCheckBox;
        private System.Windows.Forms.CheckBox DCW_CheckBox;
        private System.Windows.Forms.CheckBox ColorBarCheckBox;
    }
}