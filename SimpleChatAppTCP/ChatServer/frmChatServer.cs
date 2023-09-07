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

        private async void btnStart_Click(object sender, EventArgs e)
        {

            string starting = await Task.Run(() => getState("Starting ├#########┤"));
            string started = await Task.Run(() => getState("Started . (*_*)"));
            Task.Run(Start);




        }
        public string getState(string state)
        {

            Action empty = () =>
            lblCurrentState.Text = "";
            this.Invoke(empty);
            Thread.Sleep(1500);
            for (int i = 0; i < state.Length; i++)
            {
                Thread.Sleep(250);
                Action action = () => lblCurrentState.Text += state[i];
                this.Invoke(action);
            }
            Thread.Sleep(1500);


            return state;
        }

        private async void Start()
        {
            //IPAddress ip = new IPAddress(new byte[] {192,168,1,2 });
            //IPAddress ip= IPAddress.Parse("192.168.1.2");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = IPAddress.Parse("localhost");
            TcpListener tcpListener = new TcpListener(ip, 49300);

            tcpListener.Start();
            TcpClient tcpCLient = await tcpListener.AcceptTcpClientAsync();
            string Connected = await Task.Run(() => getState($"Connected With One Client\n--------><---------\n" +
                $"{{Client Ip:{{{tcpCLient.Client.LocalEndPoint.AddressFamily}}}"));
        }


    }
}
