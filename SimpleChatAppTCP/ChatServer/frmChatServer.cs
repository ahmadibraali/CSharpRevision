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
                
                Thread.Sleep(4000);
                Task.Run(Start);
                var startedState = "Started . (*_*)";
                Thread.Sleep(1500);
                getState(startedState);
        }
        public void getState(string state)
        {
            
            Action empty = () =>
            lblCurrentState.Text = "";
            this.Invoke(empty);
            for (int i=0;i<state.Length;i++)
            {
                Action action = () => {
                    

                    lblCurrentState.Text += state[i];
                };
                this.Invoke(action);
                

            }
            Thread.Sleep(3000);

        }

        private async void Start()
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
