using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nano6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket sWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;//IPAddress.Parse(txtServer.Text);
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(textBox2.Text));
            sWatch.Bind(point);
            ShowMsg("************");
            sWatch.Listen(10);

            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start();
        }
        Socket sSend;
        void Listen(object o)
        {
            Socket sWatch = o as Socket;
            try
            {
                while (true)
                {
                    sSend = sWatch.Accept();
                    ShowMsg(sSend.RemoteEndPoint.ToString() + ":" + "OK");

                }
            }
            catch
            {}
        }
        void ShowMsg(string str)
        {
            textBox3.AppendText(str + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
