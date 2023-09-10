using ChatServer;
using Microsoft.VisualBasic.ApplicationServices;
using System.CodeDom;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using System.Windows.Forms;


namespace ChatClient;


public partial class frmChatClient : Form
{
    StreamReader streamReader;
    StreamWriter streamWriter;
    public event EventHandler<ChatServer.Message> LoginMsg;
    public event EventHandler<ChatServer.Message> ClientReceivedMsg;



    public frmChatClient()
    {

        InitializeComponent();
        ChatServer.frmChatServer.InitiateOffllineUsers();
        ChatServer.frmChatServer.ViewOnlineClients(Session.OnlineUsers, chkOnlineUsers);


        //ViewOnlineClients(ChatServer.Session.OnlineUsers);


    }

    private async Task Connect(string UserName)
    {
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect("127.0.0.1", 49300);


        /// Network Stream as a channel to send or receive using it from/to client to/from server 
        NetworkStream networkStream = tcpClient.GetStream();

        streamReader = new StreamReader(networkStream);
        streamWriter = new StreamWriter(networkStream);
        streamWriter.AutoFlush = true;
        ChatServer.Message _Credit = new ChatServer.Message(UserName, MsgsTypes.Credinitials, UserName, "Server");
        sendMsgtoServer(_Credit);
        while (true)
        {
            string pack = await streamReader.ReadLineAsync();
            ChatServer.Message _receivedMsg = new ChatServer.Message(pack);
            ViewingMsg(_receivedMsg, rtfClientReceived, rtfStateMsg);
        }
    }


    private void ViewingMsg(ChatServer.Message receivedMsg, RichTextBox rtfClientReceived, RichTextBox rtfStateMsg)
    {
        switch (receivedMsg.msgType)
        {
            case MsgsTypes.Normal:
            case MsgsTypes.BroadCasting:
                getEnhancedState(receivedMsg, rtfClientReceived);
                break;
            default:
                getEnhancedState(receivedMsg, rtfStateMsg);
                break;
        }
    }

    private void ShowControls()
    {
        Action action = async () =>
        {
            label1.Visible = true;
            string Connected = await Task.Run(() => getState($"Trying To loging", lblClientState));

            Connected = await Task.Run(() => getState($"Hello {txtUserName.Text}", lblClientState));

            txtMessage.Visible = true;
            btnSendMsg.Visible = true;
            rtfClientReceived.Visible = true;
            lblReceived.Visible = true;
            rtfClientReceived.Visible = true;
            btnSendToAll.Visible = true;
        };
        this.Invoke(action);
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        string _username = txtUserName.Text.ToLower();
        string _password = txtUserPassword.Text.ToLower();
        //string _message = _username + "###" + _password;
        
       // if (ChatServer.Session.IsServer)
        //{
            Connect(_username);
            bool authenticated = CheckCredinitials(_username, _password);
            Action action;

            if (authenticated)
            {
                LoginState(_username, true);
                action = () =>
                {
                    txtUserPassword.Visible = false;
                    txtUserName.Enabled = false;
                    lblLoginState.Text = $"Hello , {_username}";
                    txtUserName.Visible = false;
                    lblLoginState.Visible = true;
                };
                this.Invoke(action);

                ShowControls();

            }
            else
            {
                LoginState(_username, false);
                txtUserPassword.Text = "";
                txtUserPassword.Focus();
                lblLoginState.Visible = true;
                lblLoginState.Text = "Try Again";
            }
        }
        /*else
        {
            label1.Visible = true;
            string s = await Task.Run(()=>getState($"Server Is Idle\nWait Till \nThe Server Runs\n\t\t(*____*)",lblClientState));
        }*/

    




    private void LoginState(string username, bool valid)
    {
        string _logState;
        string state;
        ChatServer.Message CredinitialMsg;
        MsgsTypes type;

        _logState = valid ? "had been Logged on Successfuly" : " trying to login with invalid credinitils";
        type = valid ? MsgsTypes.Authenticated : MsgsTypes.InValidCredinitials; ;


        state = username + ">>" + _logState;
        CredinitialMsg = new ChatServer.Message(state, type, username, "Server");
        sendMsgtoServer(CredinitialMsg);

    }

    private bool CheckCredinitials(string username, string password)
    {
        string s = ChatServer.Session.RegisterdUsers.Find(x => x.ToLower() == username.ToLower());
        if (s is not null && password == "123")
        {
            ChatServer.Session.OnlineUsers.Add(s);
            ChatServer.Session.OfflineUsers.Remove(s);
            return true;
        }
        else
            return false;
    }

    private async void sendMsgtoServer(ChatServer.Message _message)
    {
        streamWriter.WriteLine(_message.Packet);
    }

    private async void btnSendMsg_Click(object sender, EventArgs e)
    {
        string msg = txtMessage.Text;
        ChatServer.Message _message = new ChatServer.Message(msg, MsgsTypes.Normal, txtUserName.Text, "Server");
        sendMsgtoServer(_message);
        await Task.Run(() => getEnhancedState(_message, rtfClientReceived));
        txtMessage.Text = "";
    }
    private async void btnSendToAll_Click(object sender, EventArgs e)
    {
        string msg = txtMessage.Text;
        ChatServer.Message _message = new ChatServer.Message(msg, MsgsTypes.BroadCasting, txtUserName.Text, "All");
        sendMsgtoServer(_message);
        await Task.Run(() => getEnhancedState(_message, rtfClientReceived));

        txtMessage.Text = "";
    }


    public void getEnhancedState(ChatServer.Message _message, RichTextBox rtf)
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
                rtf.SelectionColor = colorReciver;
            else if (checkBroadCast)
                rtf.SelectionColor = colorBroadCast;
            else
                rtf.SelectionColor = colorSender;
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
        Thread.Sleep(1000);
        for (int i = 0; i < state.Length; i++)
        {
            Thread.Sleep(100);
            Action action = () => lbl.Text += state[i];
            this.Invoke(action);
        }
        Thread.Sleep(750);


        return state;
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
