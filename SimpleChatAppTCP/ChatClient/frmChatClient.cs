using ChatServer;
using System.Net.Sockets;
namespace ChatClient;


public partial class frmChatClient : Form
{
    StreamReader streamReader;
    StreamWriter streamWriter;

    public frmChatClient()
    {
        
        
        CopyClientList(Client.onlineUsers, UnsignedClients);

        InitializeComponent();
        DisplayUsers(chkOnlineUsers, UnsignedClients);
    }
    private void DisplayUsers(CheckedListBox chkLst, List<string> onlineClients)
    {
        chkLst.Items.Clear();
        foreach (var item in onlineClients)
        {
            chkLst.DisplayMember = "Name";
            chkLst.Items.Add(item);
        }
    }

    private void CopyClientList(List<string> clients, List<string> unsignedClients)
    {
        foreach (var client in clients)
        {
            unsignedClients.Add(client);
        }
    }

    List<string> UnsignedClients = new List<string>();

    private async Task ConnectAsync(string credinitials)
    {
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect("127.0.0.1", 49300);
        /// Network Stream as a channel to send or receive using it from/to client to/from server 
        NetworkStream networkStream = tcpClient.GetStream();
        Action action = async () =>
        {
            label1.Visible = true;
            string Connected = await Task.Run(() => getState($"Trying To loging", lblClientState));

            txtMessage.Visible = true;
            btnSendMsg.Visible = true;
            rtfClientReceived.Visible = true;
            lblReceived.Visible = true;
            rtfClientReceived.Visible = true;
        };
        this.Invoke(action);

        streamReader = new StreamReader(networkStream);
        streamWriter = new StreamWriter(networkStream);
        streamWriter.AutoFlush = true;

        streamWriter.WriteLine(credinitials);

        /// After Doing that we have to Push Message to Server Side using Flush() Method
        //streamWriter.Flush();
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        string username = txtUserName.Text.ToLower();
        string password = txtUserPassword.Text.ToLower();
        string credinitials = $"###{username}#{password}###";

        ConnectAsync(credinitials);
        while (true)
        {
            string msg = await streamReader.ReadLineAsync();
            if (msg.StartsWith("$$$") && msg.EndsWith("$$$"))
            {
                if (msg == "$$$Login Successfully$$$")
                {

                    string Connected = await Task.Run(() => getState($"Login Approved\n├------(Hello ,{username.ToUpper()})------┤", lblClientState));


                    txtUserName.Visible = false;
                    txtUserName.Enabled = false;
                    txtUserPassword.Visible = false;
                    btnConnect.Visible = false;
                    btnDisconnect.Visible = true;
                    chkOnlineUsers.Visible = true;
                    lblOnlineClients.Visible = true;


                    sendMsgtoServer($"#ONLINE#{username.ToUpper()}#ONLINE#");

                }
                else if (msg == "$$$Try Again$$$")
                {
                    lblClientState.Text = "Invalid Credinitials >> Try Again";

                    txtUserName.Focus();
                }
                else if (msg.StartsWith($"#ONLINE#"))
                {

                    Client.onlineUsers.Add(msg[8..]);
                    DisplayUsers(chkOnlineUsers, Client.onlineUsers);


                }


            }
            else
            {
                string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfClientReceived, true));
            }






        }
    }

    private async void sendMsgtoServer(string msg)
    {
        streamWriter.WriteLine(msg);
    }

    private async void btnSendMsg_Click(object sender, EventArgs e)
    {
        string msg = txtMessage.Text;
        sendMsgtoServer(msg);
        string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfClientReceived, false));

        txtMessage.Text = "";

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
                lbl.SelectedText = Environment.NewLine + $"├Server :-->";
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
                lbl.SelectedText = Environment.NewLine + $"├Client :--> ";
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
