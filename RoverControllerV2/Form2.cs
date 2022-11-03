using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.Json;


namespace RoverControllerV2
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        public class Status
        {
            public int _0xd3 { get; set; }
            public int _0x111 { get; set; }
            public int _0x132 { get; set; }
            public int xclk { get; set; }
            public int pixformat { get; set; }
            public int framesize { get; set; }
            public int quality { get; set; }
            public int brightness { get; set; }
            public int contrast { get; set; }
            public int saturation { get; set; }
            public int sharpness { get; set; }
            public int special_effect { get; set; }
            public int wb_mode { get; set; }
            public int awb { get; set; }
            public int awb_gain { get; set; }
            public int aec { get; set; }
            public int aec2 { get; set; }
            public int ae_level { get; set; }
            public int aec_value { get; set; }
            public int agc { get; set; }
            public int agc_gain { get; set; }
            public int gainceiling { get; set; }
            public int bpc { get; set; }
            public int wpc { get; set; }
            public int raw_gma { get; set; }
            public int lenc { get; set; }
            public int hmirror { get; set; }
            public int dcw { get; set; }
            public int colorbar { get; set; }
            public int led_intensity { get; set; }
            public int face_detect { get; set; }
        }

        public bool SetControler(string control, string value)
    {
        bool issuccess = false;

        try
        {
            WebRequest request = WebRequest.Create($"http://{camip}/control?var={control}&val={value}");
            request.Method = "GET";
            using (WebResponse res = request.GetResponse())
            {
                issuccess = true;
            }
        }
        catch
        {
            issuccess = false;
        }
        return issuccess;
    }

        public bool SetByURL(string url)
        {
            bool issuccess = false;

            try
            {
                WebRequest request = WebRequest.Create($"http://{camip}/{url}");
                request.Method = "GET";
                using (WebResponse res = request.GetResponse())
                {
                    issuccess = true;
                }
            }
            catch
            {
                issuccess = false;
            }
            return issuccess;
        }

        private string GetStatus()
    {
        string result = "";

        try
        {
            WebRequest request = WebRequest.Create($"http://{camip}/status");
            request.Method = "GET";
            using (WebResponse res = request.GetResponse())
            {
                System.IO.Stream stream = res.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                result = sr.ReadToEnd();

            }
        }
        catch
        {
            result = null;
        }
        return result;
    }


        public string camip;
        Status stateus; //temp
    private void SettingsForm_Load(object sender, EventArgs e)
    {
            camip = Form1.camip;

            string res = GetStatus();
             stateus = JsonSerializer.Deserialize<Status>(res);

            ResolutionCombo.SelectedIndex = stateus.framesize;
        SpecialEffectCombo.SelectedIndex = stateus.special_effect;
        WB_Combo.SelectedIndex = stateus.wb_mode;
            FPS_num.Value = stateus.xclk;
            QualityTrackBar.Value = stateus.quality;
            BrightnessTrackbar.Value = stateus.brightness;
            ContrastTrackBar.Value = stateus.contrast;
            SaturationTrackBar.Value = stateus.saturation;
            AWB.Checked = 0<stateus.awb;
            AWB_Gain_CheckBox.Checked = 0<stateus.awb_gain;
            AEC_SENSOR_CheckBox.Checked = 0 < stateus.aec;
            ExposureTrackBar.Value = stateus.aec_value;
            AEC_DSP_CheckBox.Checked = 0 < stateus.aec2;
            AE_LevelTrackBar.Value = stateus.ae_level;
            AGC_CheckBox.Checked = 0 < stateus.agc;
            GainTrackBar.Value = stateus.agc_gain;
            if (stateus.gainceiling < 6)
            {
                GainCeilingTrackBar.Value = stateus.gainceiling;
            }
            else 
            {
                GainCeilingTrackBar.Value = 6; 
            }
            BPC_CheckBox.Checked = 0<stateus.bpc;
            WPC_CheckBox.Checked = 0<stateus.wpc;
            RawGMA_CheckBox.Checked = 0 < stateus.raw_gma;
            LensCorrectionCheckBox.Checked = 0 < stateus.lenc;
            H_MirrorCheckBox.Checked = 0 < stateus.hmirror;
            V_FlipCheckBox.Checked = true;
            DCW_CheckBox.Checked = 0 < stateus.dcw;
            ColorBarCheckBox.Checked = 0 < stateus.colorbar;


    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (AWB_Gain_CheckBox.Checked)
        {
            WB_Combo.Enabled = true;
        }
        else
        {
            WB_Combo.Enabled = false;
        }
            SetControler("awb_gain", (Convert.ToInt16(AWB_Gain_CheckBox.Checked)).ToString());
        }

    private void AEC_SENSOR_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (AEC_SENSOR_CheckBox.Checked)
        {
            ExposureTrackBar.Enabled = false;
        }
        else
        {
            ExposureTrackBar.Enabled = true;
        }
            SetControler("aec", (Convert.ToInt16(AEC_SENSOR_CheckBox.Checked)).ToString());
        }

    private void AGC_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (AGC_CheckBox.Checked)
        {
            GainCeilingTrackBar.Enabled = true;
            GainTrackBar.Enabled = false;
        }
        else
        {
            GainCeilingTrackBar.Enabled = false;
            GainTrackBar.Enabled = true;
        }
            SetControler("agc", (Convert.ToInt16(AGC_CheckBox.Checked)).ToString());
        }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

        private void ResolutionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            SetControler("framesize",(13-ResolutionCombo.SelectedIndex).ToString());
        }

        private void FPS_num_ValueChanged(object sender, EventArgs e)
        {
            SetByURL($"xclk?xclk={((int)FPS_num.Value).ToString()}");
        }

        private void QualityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("quality",QualityTrackBar.Value.ToString());
        }

        private void BrightnessTrackbar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("brightness", BrightnessTrackbar.Value.ToString());
        }

        private void ContrastTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("contrast", ContrastTrackBar.Value.ToString());
        }

        private void SaturationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("saturation", SaturationTrackBar.Value.ToString());
        }

        private void SpecialEffectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControler("special_effect", SpecialEffectCombo.SelectedIndex.ToString());
        }

        private void AWB_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("awb", (Convert.ToInt16(AWB.Checked)).ToString());
        }

        private void WB_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControler("wb_mode",WB_Combo.SelectedIndex.ToString());
        }

        private void ExposureTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("aec_value", ExposureTrackBar.Value.ToString());

        }

        private void AEC_DSP_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("aec2", (Convert.ToInt16(AEC_DSP_CheckBox.Checked)).ToString());
        }

        private void AE_LevelTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("ae_level", AE_LevelTrackBar.Value.ToString());
        }

        private void GainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("agc_gain", GainTrackBar.Value.ToString());
        }

        private void GainCeilingTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetControler("gainceiling", GainTrackBar.Value.ToString());

        }

        private void BPC_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("bpc", (Convert.ToInt16(BPC_CheckBox.Checked)).ToString());
        }

        private void WPC_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("wpc", (Convert.ToInt16(WPC_CheckBox.Checked)).ToString());
        }

        private void RawGMA_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("raw_gma", (Convert.ToInt16(RawGMA_CheckBox.Checked)).ToString());
        }

        private void LensCorrectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("lenc", (Convert.ToInt16(LensCorrectionCheckBox.Checked)).ToString());
        }

        private void H_MirrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("hmirror", (Convert.ToInt16(H_MirrorCheckBox.Checked)).ToString());
        }

        private void V_FlipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("vflip", (Convert.ToInt16(V_FlipCheckBox.Checked)).ToString());
        }

        private void DCW_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("dcw", (Convert.ToInt16(DCW_CheckBox.Checked)).ToString());
        }

        private void ColorBarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetControler("colorbar", (Convert.ToInt16(ColorBarCheckBox.Checked)).ToString());
        }

        private void ResolutionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
