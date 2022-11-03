using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using AForge.Video;
using System.Threading;


namespace RoverControllerV2
{
    public partial class Form1 : Form
    {
        const int RoverPort = 5599;
        const int MaxLogLines = 5;
        public Form1()
        {
            InitializeComponent();
        }

        VideoStreamer vs;
        private void newStreaming(string ip,int port,string subpath= "stream") {
            
            vs = new VideoStreamer(ref pictureBox1,ip,port);
            Thread t = new Thread(new ThreadStart(vs.newStreaming));
            t.Start();
        }
        

        System.Timers.Timer t;
        System.Timers.Timer pingtime;
        SettingsForm settingsForm;
        public static string camip;
        public static string roverip;
        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer(500);
            pingtime = new System.Timers.Timer(1000);
            t.AutoReset = true;
            t.Elapsed += T_Elapsed1;
            pingtime.Elapsed += Pingtime_Elapsed1;
            logLbl.Parent = pictureBox1;
            loglblUpdateLocation();
            settingsForm = new SettingsForm();
            camip = CamIpTxt.Text.Trim();
            settingsForm.camip = camip;
            settingsForm.SetByURL("xclk?xclk=5");
            settingsForm.SetControler("framesize","8");
            settingsForm.SetControler("hmirror", "1");
            settingsForm.SetControler("vflip", "1");

        }

        private void loglblUpdateLocation() {
            logLbl.Left = pictureBox1.Width - logLbl.Width-1;
            logLbl.Top = 1;
        }

        bool _TimeOut = true;
        private void T_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            _TimeOut = true;
        }

        private void Pingtime_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            updatePin(RoverCon.ping);
        }

        delegate void PinlblUpdateCallback(long _ping);
        private void updatePin(long _ping)
        {
            if (this.Pinlbl.InvokeRequired)
            {
                PinlblUpdateCallback dele = new PinlblUpdateCallback(updatePin);
                this.Invoke(dele, new object[] { _ping });
            }
            else
            {
                this.Pinlbl.Text = "Ping : " + _ping.ToString();
            }
        }


        

        private bool IsConnectBtn = true;
        EstablishConnection RoverCon;
        private void button1_Click(object sender, EventArgs e)
        {

            if (IsConnectBtn)
            {
                Cursor.Current = Cursors.WaitCursor;
                WriteLog("Establishing Connection with Rover...");
                RoverCon = new EstablishConnection(RoverIpTxt.Text, RoverPort);
                Cursor.Current = Cursors.Default;
                if (RoverCon.isConnected)
                {
                    WriteLog("Connected to Rover.");
                    CamIpTxt.Enabled = false;
                    RoverIpTxt.Enabled = false;
                    Statelbl.Text = "State : Connected";
                    ConBtn.Text = "Disconnect";
                    ConBtn.ForeColor = Color.LightCoral;
                    IsConnectBtn = false;
                    try {
                        if (vs == null)
                        {
                            newStreaming(CamIpTxt.Text.Trim(), 81);
                        }

                        if(vs!=null){
                            WriteLog("Starting video streaming");
                            if (!vs.IsRunning())
                            {
                                vs.Start();
                            }
                            else
                            {
                                WriteLog("Video Streaming is already running.\nRestarting service");
                            }
                        }
                    }
                    catch
                    {
                        WriteLog("Cannot start video streaming.");
                    }
                    pingtime.Start();

                }
                else
                {
                    WriteLog("Failed to Connect to the Rover.");
                }
            }
            else
            {
                RoverCon.isConnected = false;
                WriteLog("Disconnected From Rover.");
                ConBtn.Text = "Connect";
                ConBtn.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                IsConnectBtn = true;
                CamIpTxt.Enabled = true;
                RoverIpTxt.Enabled = true;
                Statelbl.Text = "State : Not Connected";
                pingtime.Stop();
                Pinlbl.Text = "Ping : -";
                if (vs != null)
                {
                    if (vs.IsRunning() && vs.isConnectedToCam)
                    {
                        vs.Stop();
                        WriteLog("Video streaming Stoped");
                    }
                    vs.isConnectedToCam = false;
                }
                RoverCon.CloseConnection();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void WriteLog(string msg)
        {
            msg = msg.Trim();
            string cl = logLbl.Text;
            cl = cl.TrimEnd();
            List<string> lines = cl.Split('\n').ToList();
            lines.Add(msg);
            if (lines.Count() > MaxLogLines)
            {
                string temp = "";
                for (int i = 0; i < MaxLogLines - 1; i++)
                {
                    temp += lines[i + 1] + "\n";
                }
                logLbl.Text = temp;
            }
            logLbl.Text += msg + "\n";
            Application.DoEvents();
        }

        int previousKeyCode = 0;
        private void RoverControllerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (RoverCon != null)
            {
                if (RoverCon.isConnected && (e.KeyValue != previousKeyCode || _TimeOut))
                {
                    _TimeOut = false;
                    t.Start();
                    switch (e.KeyData.ToString())
                    {
                        case "W":
                            WriteLog("Sending \"RoverF\" command.");
                            RoverCon.SendCmd("RoverF");
                            break;
                        case "S":
                            WriteLog("Sending \"RoverB\" command.");
                            RoverCon.SendCmd("RoverB");
                            break;
                        case "A":
                            WriteLog("Sending \"RoverL\" command.");
                            RoverCon.SendCmd("RoverL");
                            break;
                        case "D":
                            WriteLog("Sending \"RoverR\" command.");
                            RoverCon.SendCmd("RoverR");
                            break;
                        case "ShiftKey, Shift":
                            WriteLog("Increase Speed.");
                            roverGearSet(true);
                            break;
                        case "ControlKey, Control":
                            WriteLog("Decrease Speed.");
                            roverGearSet(false);
                            break;
                        case "Q":
                            WriteLog("Sending \"CamU\" command.");
                            RoverCon.SendCmd("CamU");
                            break;
                        case "Z":
                            WriteLog("Sending \"CamD\" command.");
                            RoverCon.SendCmd("CamD");
                            break;
                        case "E":
                            WriteLog("Sending \"CamL\" command.");
                            RoverCon.SendCmd("CamL");
                            break;
                        case "R":
                            WriteLog("Sending \"CamR\" command.");
                            RoverCon.SendCmd("CamR");
                            break;
                    }
                    previousKeyCode = e.KeyValue;
                }
            }
        }

        private void roverGearSet(bool increase)
        {
            if (increase)
            {
                if (trackBar1.Value >= 3)
                {
                    WriteLog("Running on Maximum Speed.");
                }
                else
                {
                    trackBar1.Value += 1;
                }
            }
            else
            {
                if (trackBar1.Value <= 1)
                {
                    WriteLog("Running on Minimum Speed.");
                }
                else
                {
                    trackBar1.Value -= 1;
                }
            }
        }

        private void RoverControllerForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (RoverCon != null)
            {
                if (RoverCon.isConnected)
                {
                    WriteLog("Sending \"RoverStop\" command.");
                    RoverCon.SendCmd("RoverStop");
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            string stemp = "Gear=" + trackBar1.Value.ToString();
            RoverCon.SendCmd(stemp);
            WriteLog($"Sending \"{stemp}\" command.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            settingsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vs != null) {
                if (vs.isConnectedToCam) {
                vs.Stop();
                }
                
            }
            if (RoverCon != null) {
                if (RoverCon.isConnected) {
                    RoverCon.CloseConnection();
                }
            }
            
        }
    }

    public class EstablishConnection
    {
        public Socket sok = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public bool isConnected = false;
        public long ping = 999999999999999999;
        public string ip = null;
        System.Timers.Timer pingTimer;
        public EstablishConnection(string _ip, int port)
        {
            if (validateProperties(_ip, port))
            {

                try
                {
                    sok.Connect(_ip, port);
                    isConnected = true;
                    ip = _ip;
                    pingTimer = new System.Timers.Timer(1000);
                    pingTimer.Elapsed += PingTimer_Elapsed1;
                    pingTimer.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Check IP address and Port again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PingTimer_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool pingable = false;
            Ping pinger = null;


            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip);
                pingable = reply.Status == IPStatus.Success;
                ping = reply.RoundtripTime;
            }
            catch (PingException)
            {
                Console.WriteLine("ping error");
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
        }

        

        public void SendCmd(string cmd)
        {
            if (sok.Connected)
            {
                byte[] snd = Encoding.ASCII.GetBytes(cmd + "\n");
                sok.Send(snd, 0, snd.Length, SocketFlags.None);
            }
            else
            {
                isConnected = false;
                MessageBox.Show("Connection Broke", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateProperties(string SIp, int port)
        {
            IPAddress ip;
            bool IPvalidity = IPAddress.TryParse(SIp, out ip);
            bool PortValidity;
            PortValidity = (port >= 0 && port <= 65536);
            return PortValidity && IPvalidity;
        }

        public void CloseConnection()
        {
            pingTimer.Stop();
            if (sok.Connected)
            {
                sok.Disconnect(false);
            }
            else
            {
                MessageBox.Show("Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class VideoStreamer {
        private PictureBox picbox;
        private string ip;
        private int port;
        public VideoStreamer(ref PictureBox  p,string Ip, int Port) {
            picbox = p;
            ip = Ip;
            port = Port;
        }
        MJPEGStream videoStream;
        
        public void newStreaming()
        {
            videoStream = new MJPEGStream($"http://{ip}:{port.ToString()}/stream");
            videoStream.NewFrame += VideoStream_NewFrame;
        }

        public bool IsRunning() {
            return videoStream.IsRunning;
        }

        public void Start() {
            videoStream.Start();
        }

        public void Stop()
        {
            videoStream.Stop();
        }
        private void VideoStream_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        public bool isConnectedToCam = false;
        private void VideoStream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                isConnectedToCam = true;
                Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
                picbox.Image = bmp;
            }
            catch
            {

            }
        }

    }
}



