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
        StreamReader streamReader;
        StreamWriter streamWriter;

        public frmChatClient()
        {
            InitializeComponent();
        }
        private async Task ConnectAsync()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 49300);
            /// Network Stream as a channel to send or receive using it from/to client to/from server 
            NetworkStream networkStream = tcpClient.GetStream();
            Action action = async () =>
            {
                label1.Visible = true;
                string Connected = await Task.Run(() => getState($"Connected Successfully ", lblClientState));

                txtMessage.Visible = true;
                btnSendMsg.Visible = true;
                rtfClientReceived.Visible = true;
                lblReceived.Visible = true;
                rtfClientReceived.Visible = true;
            };
            this.Invoke(action);
            /// (BinaryReader & BinaryWriter)  Same as (StreamReader & StreamWriter)
            //BinaryReader binaryReader = new BinaryReader(networkStream);
            //BinaryWriter binaryWriter = new BinaryWriter(networkStream);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            //// send a string to network stream using streamWriter
            streamWriter.AutoFlush = true;
            while (true)
            {
                string msg = await streamReader.ReadLineAsync();

                string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfClientReceived, true));

            }

            /// After Doing that we have to Push Message to Server Side using Flush() Method
            //streamWriter.Flush();
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectAsync();
        }

        private async void btnSendMsg_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text;
            streamWriter.WriteLine(msg);
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
}
