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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.AxHost;

namespace ChatServer
{
    public partial class frmChatServer : Form
    {

        public static List<Session> ConnectedUsers;



        public frmChatServer()
        {
            InitializeComponent();
            InitiateOffllineUsers();
            ViewOnlineClients(Session.OnlineUsers,chkOnlineUsers);
            ConnectedUsers = new List<Session>();


        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            //flag = false;
            if (!Session.IsServer)
            {
                //btnStart.Text = "Stop Server";
                btnStart.Enabled = false;
                string starting = await Task.Run(() => getState("Starting ├#########┤", lblCurrentState));
                starting = await Task.Run(() => getState("Started . (*_*)", lblCurrentState));
                starting = await Task.Run(() => getState("Server Is Running (*_*)", lblCurrentState));

                await Task.Run(() => Start("Server"));
            }





        }
        public void getEnhancedState(Message _message, RichTextBox rtf)
        {
            Color colorSender = Color.FromArgb(253, 134, 70);
            Color colorReciver = Color.FromArgb(42, 61, 68);
            Color colorBroadCast = Color.FromArgb(240, 120, 44);
            Action action;
            bool checkBroadCast = (_message.msgType == MsgsTypes.BroadCasting) ? true : false;
            string _sender;
            if (checkBroadCast)

                _sender = $"Broadcasting Message from {_message.From}";
            else
                _sender = _message.From;

            action = () =>
            {
                if (_sender.ToLower() == "Server".ToLower())
                    rtf.SelectionColor = colorSender;
                else if(checkBroadCast)
                    rtf.SelectionColor = colorBroadCast;
                else
                    rtf.SelectionColor = colorReciver;
                rtf.SelectedText = Environment.NewLine + $"├{_sender}>>";
            };
            this.Invoke(action);
            Thread.Sleep(750);
            for (int i = 0; i < _message.CoreMsg.Length; i++)
            {
                Thread.Sleep(100);

                action = () =>
                {

                    rtf.SelectedText += $"{_message.CoreMsg[i]}";
                };
                this.Invoke(action);
            }
            action = () => rtf.SelectedText += $"\n";
            this.Invoke(action);


            Thread.Sleep(610);



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






        private async void Start(string userName)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 49300);
            showControls();
            tcpListener.Start();
            Session.IsServer = true;
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                Session newSession = new Session(tcpClient);

                newSession.MsgReceived += NewSession_MsgReceived;
                ConnectedUsers.Add(newSession);
            }
        }

        private async void NewSession_MsgReceived(object? sender, Message _message)
        {

            MsgsTypes type = _message.msgType;
            switch (type)
            {
                case MsgsTypes.Normal:
                    await Task.Run(() => getEnhancedState(_message, rtfMsgContent));
                    break;
                case MsgsTypes.BroadCasting:
                    await Task.Run(() => getEnhancedState(_message, rtfMsgContent));
                    SendToMultipleUsers(_message, ConnectedUsers);
                    break;

                case MsgsTypes.Authenticated:
                    await Task.Run(() => getEnhancedState(_message, rtfStateMsg));
                    string online = Session.OfflineUsers.Find(x => x.ToLower() == _message.From.ToLower());
                    Session.OfflineUsers.Remove(online);
                    Session.OnlineUsers.Add(online);
                    //Session online = new Session(_message.From);
                    //OnlineUsers.Add(online);
                    ViewOnlineClients(Session.OnlineUsers, chkOnlineUsers);
                    break;
                case MsgsTypes.Credinitials:
                case MsgsTypes.Error:
                case MsgsTypes.InValidCredinitials:
                case MsgsTypes.OnlineUser:
                case MsgsTypes.Unknown:
                default:
                    await Task.Run(() => getEnhancedState(_message, rtfStateMsg));
                    break;

            }
        }



        public static void ViewOnlineClients(List<string> OnlineUsers,CheckedListBox chklist)
        {
            chklist.Visible = false;
            Action action;
            chklist.Items.Clear();
            foreach (string onlineUser in OnlineUsers)
            {
                chklist.DisplayMember = "UserName";
                chklist.Items.Add(onlineUser);
            }

        }



        private void showControls()
        {
            Action action = () =>
            {
                label1.Visible = true;
                txtMessage.Visible = true;
                btnSendMsg.Visible = true;
                btnSendToAll.Visible = true;
                rtfMsgContent.Visible = true;
                lblStateMsgs.Visible = true;
                rtfStateMsg.Visible = true;

                checkOnlineUsers();


            };
            this.Invoke(action);
        }

        private void checkOnlineUsers()
        {
            lblOnlineClients.Visible = true;
            if (Session.OnlineUsers.Count == 0)
            {

                chkOnlineUsers.Visible = false;
                lblNoActiveUsers.Visible = true;
            }
            else
            {
                lblNoActiveUsers.Visible = false;
                chkOnlineUsers.Visible = true;
            }
        }

        private async void btnSendMsg_ClickAsync(object sender, EventArgs e)
        {

            string msg = txtMessage.Text;
            Message _message = new Message(msg, MsgsTypes.Normal, "Server", "ALL");
            SendToMultipleUsers(_message, ConnectedUsers);


            await Task.Run(() => getEnhancedState(_message, rtfMsgContent));


            txtMessage.Text = "";
        }
        private void btnSendToAll_Click(object sender, EventArgs e)
        {
            Message msg = new Message(txtMessage.Text, MsgsTypes.Normal, "Server", "ALL");
            SendToMultipleUsers(msg, ConnectedUsers);

        }
        private void SendToMultipleUsers(Message _message, List<Session> Sessions)
        {
            foreach (Session session in Sessions)
            {
                session.SendMsg(_message);
            }
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

        private void chkOnlineUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            ViewOnlineClients(Session.OnlineUsers, chkOnlineUsers);
        }
        public static List<string> GetUsers(List<string> CopyFrom)
        {
            List<string> users = new List<string>();
            foreach (string user in CopyFrom)
            {
                users.Add(user);
            }
            return users;
        }
        public static void InitiateOffllineUsers()
        {
            if (Session.OfflineUsers.Count <= 0)
            {
                Session.OfflineUsers = GetUsers(Session.RegisterdUsers);
            }
            return;
        }
    }

}


