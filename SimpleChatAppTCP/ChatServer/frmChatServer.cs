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
        StreamReader streamReader;
        StreamWriter streamWriter;
        public frmChatServer()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {


            if (btnStart.Text == "Start Server")
            {
                //flag = false;
                btnStart.Text = "Stop Server";
                string starting = await Task.Run(() => getState("Starting ├#########┤", lblCurrentState));
                string started = await Task.Run(() => getState("Started . (*_*)", lblCurrentState));

                await Task.Run(() => Start(false));
            }
            else
            {
                // flag = true;
                await Task.Run(() => Start(true));
                //flag = false;

            }



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

        private TcpListener initListener()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = null;
            tcpListener = new TcpListener(ip, 49300);

            return tcpListener;
        }

        public void showControls()
        {
            //label1.Visible = false;
            Action action = () =>
            {
                lblStatus.Visible = true;
                lblCurrentState.Visible = true;
                //lblMsgContent.Visible = false;
            };
            this.Invoke(action);
        }


        private async void Start(bool flagRunner)
        {
            TcpListener tcpListener = initListener();
            showControls();



            if (!flagRunner)
            {
                tcpListener.Stop();

                tcpListener.Start();
                /// to Accept client to connects to the server .
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();


                /// Network Stream as a channel to send or receive using it from/to client to/from server 
                string Connected = await Task.Run(() => getState($"Connected With One Client\n-------------><-------------", lblCurrentState));
                NetworkStream networkStream = tcpClient.GetStream();
                /// (BinaryReader & BinaryWriter)  Same as (StreamReader & StreamWriter)

                //BinaryReader binaryReader = new BinaryReader(networkStream);
                //BinaryWriter binaryWriter = new BinaryWriter(networkStream);
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);

                while (true)
                {
                    string msg = await streamReader.ReadLineAsync();
                    Action action = () =>
                    {
                        label1.Visible = true;
                        txtMessage.Visible = true;
                        btnSendMsg.Visible = true;
                    };
                    this.Invoke(action);
                    //Connected = await Task.Run(() => getState($"Client is Sending a Message ", lblCurrentState));
                    string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfMsgContent, true));

                }

            }
            else
            {
                //tcpListener.Stop();
                Action action = () =>
                {
                    btnStart.Text = "Start Server";
                    label1.Visible = false;
                    lblStatus.Visible = true;
                    lblCurrentState.Text = "Terminated Connection";

                };
                this.Invoke(action);
                tcpListener.Stop();

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



        private async void btnSendMsg_ClickAsync(object sender, EventArgs e)
        {
            streamWriter.AutoFlush = true;
            string msg = txtMessage.Text;
            streamWriter.WriteLine(msg);
            string content = await Task.Run(() => getEnhancedState($"\"{msg}\"", rtfMsgContent, false));

            txtMessage.Text = "";
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


