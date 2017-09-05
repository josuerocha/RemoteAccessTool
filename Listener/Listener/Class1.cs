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
    static class ImageStreamNetwork
    {
        public static TcpListener tcpListener;
        public static Socket socketForServer;
        public static NetworkStream networkStream;

       public static void Cleanup()
        {
            networkStream.Close();
            socketForServer.Close();
        }


    }

    class Threads
    {
        public Thread th_ImageListen, th_StartListen, th_RunClient, th_shiftFlash, th_controlFlash, th_LMouseFlash, th_RMouseFlash,
        th_MMouseFlash, th_Remoting;
    }
}
