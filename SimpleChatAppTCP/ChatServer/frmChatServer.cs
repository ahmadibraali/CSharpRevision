using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ChatServer
{
    public partial class frmChatServer : Form
    {
        List<Client> clients;
        List<string> onlineClients;
        public frmChatServer()
        {
            InitializeComponent();

            clients = new List<Client>();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {



            //flag = false;
            btnStart.Text = "Stop Server";
            string starting = await Task.Run(() => getState("Starting ├#########┤", lblCurrentState));
            string started = await Task.Run(() => getState("Started . (*_*)", lblCurrentState));

            await Task.Run(Start);





        }
        public string getEnhancedState(string state, RichTextBox lbl, bool to)
        {

            Color colorSender = Color.FromArgb(253, 134, 70);
            Color colorReciver = Color.FromArgb(42, 61, 68);
            Action action;


            if (to)
            {

                action = () =>
                {
                    lbl.SelectionColor = colorSender;
                    lbl.SelectedText = Environment.NewLine + $"├Client :-->";
                };
                this.Invoke(action);
                goto stage;

            }
            else
            {
                action = () =>
                {
                    //lbl.TextAlign=ContentAlignment.TopRight;
                    lbl.SelectionColor = colorReciver;
                    lbl.SelectedText = Environment.NewLine + $"├Server :--> ";
                };
                this.Invoke(action);

            }
        stage:
            Thread.Sleep(750);
            for (int i = 0; i < state.Length; i++)
            {
                Thread.Sleep(100);
                //string old = state[i]+"\n"; 

                action = () =>
                {
                    //lbl.SelectionColor = colorSender;

                    lbl.SelectedText += $"{state[i]}";
                };
                this.Invoke(action);
            }
            action = () => lbl.SelectedText += $"\n";
            this.Invoke(action);


            Thread.Sleep(1000);


            return state;
        }
        public string getState(string state, Label lbl)
        {

            Action empty = () =>
            lbl.Text = "";
            this.Invoke(empty);
            Thread.Sleep(1500);
            for (int i = 0; i < state.Length; i++)
            {
                Thread.Sleep(100);
                Action action = () => lbl.Text += state[i];
                this.Invoke(action);
            }
            Thread.Sleep(1000);


            return state;
        }






        private async void Start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 49300);
            showControls();
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                //string Connected = await Task.Run(() => getState($"Connected With One Client\n-------------><-------------", lblCurrentState));

                Client client = new Client(tcpClient);


                client.MsgReceived += Client_MsgReceived;
                clients.Add(client);
                //onlineClients.Add(onlineUsers);
                //ViewOnlineClients(onlineClients);
            }
        }

        private void ViewOnlineClients(List<string> onlineClients)
        {
            foreach (string onlineClient in onlineClients)
            {
                comboboxOnline.DisplayMember = "Name";
                comboboxOnline.Items.Add(onlineClient);
            }
        }

        private async void Client_MsgReceived(object? sender, string msg)
        {

            /*if (msg.StartsWith("#ONLINE#") && msg.EndsWith("#ONLINE#"))
                 {
                 var user = msg[8..^8];
                 onlineClients.Add(user);
                 Action action = () => 
                 {
                     foreach(var user in onlineClients)
                     {
                         chkOnlineClients.DisplayMember = "Name";
                         chkOnlineClients.Items.Add(user);
                     }
                 };
                 this.Invoke(action);


             }*/

            string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfMsgContent, true));




        }

        private void showControls()
        {
            Action action = () =>
            {
                label1.Visible = true;
                txtMessage.Visible = true;
                btnSendMsg.Visible = true;
                rtfMsgContent.Visible = true;
                lblOnlineClients.Visible = true;

            };
            this.Invoke(action);
        }
        private async void btnSendMsg_ClickAsync(object sender, EventArgs e)
        {

            string msg = txtMessage.Text;
            foreach (Client client in clients)
            {
                client.SendMsg(msg);
            }
            string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfMsgContent, false));

            txtMessage.Text = "";
        }
        private void btnMouseEnterLeave(object c, bool enter)
        {
            Action action = () =>
            {
                Control control = c as Control;
                if (!enter)
                    control.BackColor = Color.FromArgb(215, 114, 60);
                else
                    control.BackColor = Color.FromArgb(253, 134, 70);

            };
            this.Invoke(action);
        }
        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnMouseEnterLeave(sender, true);
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnMouseEnterLeave(sender, false);

        }


    }

}


