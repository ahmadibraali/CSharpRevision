using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class frmChatClient : Form
    {
        public frmChatClient()
        {
            InitializeComponent();
        }
        private void Connect()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1",49300);
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        
    }
}
