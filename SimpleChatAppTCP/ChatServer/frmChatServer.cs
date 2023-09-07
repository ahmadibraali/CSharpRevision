using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ChatServer
{
    public partial class frmChatServer : Form
    {
        public frmChatServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            Task.Run(() =>
            {
                var stateRunning = "Starting......";
                foreach (var ch in stateRunning)
                {
                    lblCurrentState.Text += ch;
                    Task.Delay(200);
                }
            });

            Task.Run(Start);
            
            Task.Run(() =>
            {
                var stateStarted = "Started";
                foreach (var ch in stateStarted)
                {
                    lblCurrentState.Text += ch;
                    Task.Delay(200);
                }
            });

        }

        private void Start()
        {
            //IPAddress ip = new IPAddress(new byte[] {192,168,1,2 });
            //IPAddress ip= IPAddress.Parse("192.168.1.2");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = IPAddress.Parse("localhost");
            TcpListener tcpListener = new TcpListener(ip, 49223);
            Thread.Sleep(3000);
            tcpListener.Start();
            
        }
    }
}
