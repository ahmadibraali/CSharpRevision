namespace ChatClient
{
    partial class frmChatClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Label();
            txtMessage = new TextBox();
            btnSendMsg = new Label();
            label1 = new Label();
            lblClientState = new Label();
            lblReceived = new Label();
            rtfClientReceived = new RichTextBox();
            lblTitle = new Label();
            txtUserName = new TextBox();
            txtUserPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lblOnlineClients = new Label();
            btnSendToAll = new Label();
            btnDisconnect = new Label();
            chkOnlineUsers = new CheckedListBox();
            lblNoActiveUsers = new Label();
            lblLoginState = new Label();
            label4 = new Label();
            rtfStateMsg = new RichTextBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(215, 114, 60);
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnConnect.ForeColor = Color.FromArgb(42, 61, 68);
            btnConnect.Location = new Point(724, 114);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(193, 32);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.TextAlign = ContentAlignment.MiddleCenter;
            btnConnect.Click += btnConnect_Click;
            btnConnect.MouseEnter += btnStart_MouseEnter;
            btnConnect.MouseLeave += btnStart_MouseLeave;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtMessage.Location = new Point(213, 562);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(290, 76);
            txtMessage.TabIndex = 2;
            txtMessage.Visible = false;
            // 
            // btnSendMsg
            // 
            btnSendMsg.AutoSize = true;
            btnSendMsg.BackColor = Color.FromArgb(215, 114, 60);
            btnSendMsg.Cursor = Cursors.Hand;
            btnSendMsg.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendMsg.ForeColor = Color.FromArgb(42, 61, 68);
            btnSendMsg.Location = new Point(213, 672);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(106, 24);
            btnSendMsg.TabIndex = 3;
            btnSendMsg.Text = "Send Msg";
            btnSendMsg.Visible = false;
            btnSendMsg.Click += btnSendMsg_Click;
            btnSendMsg.MouseEnter += btnStart_MouseEnter;
            btnSendMsg.MouseLeave += btnStart_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(42, 61, 68);
            label1.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(215, 114, 60);
            label1.Location = new Point(25, 65);
            label1.Name = "label1";
            label1.Size = new Size(202, 24);
            label1.TabIndex = 4;
            label1.Text = "Current State : ";
            label1.Visible = false;
            // 
            // lblClientState
            // 
            lblClientState.AutoSize = true;
            lblClientState.BackColor = Color.Transparent;
            lblClientState.Font = new Font("FiraCode Nerd Font Propo", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClientState.ForeColor = Color.FromArgb(215, 114, 60);
            lblClientState.Location = new Point(253, 65);
            lblClientState.Name = "lblClientState";
            lblClientState.Size = new Size(0, 19);
            lblClientState.TabIndex = 5;
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.BackColor = Color.FromArgb(42, 61, 68);
            lblReceived.BorderStyle = BorderStyle.Fixed3D;
            lblReceived.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblReceived.ForeColor = Color.FromArgb(215, 114, 60);
            lblReceived.Location = new Point(25, 351);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(132, 26);
            lblReceived.TabIndex = 6;
            lblReceived.Text = "Message : ";
            lblReceived.Visible = false;
            // 
            // rtfClientReceived
            // 
            rtfClientReceived.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            rtfClientReceived.Location = new Point(213, 188);
            rtfClientReceived.Margin = new Padding(2);
            rtfClientReceived.Name = "rtfClientReceived";
            rtfClientReceived.ReadOnly = true;
            rtfClientReceived.Size = new Size(290, 343);
            rtfClientReceived.TabIndex = 8;
            rtfClientReceived.Text = "";
            rtfClientReceived.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(215, 114, 60);
            lblTitle.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(42, 61, 68);
            lblTitle.Location = new Point(317, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 26);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Client Side";
            lblTitle.MouseEnter += btnStart_MouseEnter;
            lblTitle.MouseLeave += btnStart_MouseLeave;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtUserName.Location = new Point(724, 23);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(193, 34);
            txtUserName.TabIndex = 10;
            // 
            // txtUserPassword
            // 
            txtUserPassword.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtUserPassword.Location = new Point(724, 65);
            txtUserPassword.Multiline = true;
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.PasswordChar = '*';
            txtUserPassword.Size = new Size(193, 34);
            txtUserPassword.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(42, 61, 68);
            label2.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(590, 26);
            label2.Name = "label2";
            label2.Size = new Size(130, 24);
            label2.TabIndex = 12;
            label2.Text = "UserName :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(42, 61, 68);
            label3.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(590, 68);
            label3.Name = "label3";
            label3.Size = new Size(130, 24);
            label3.TabIndex = 13;
            label3.Text = "Password :";
            // 
            // lblOnlineClients
            // 
            lblOnlineClients.AutoSize = true;
            lblOnlineClients.BackColor = Color.FromArgb(42, 61, 68);
            lblOnlineClients.BorderStyle = BorderStyle.Fixed3D;
            lblOnlineClients.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblOnlineClients.Location = new Point(724, 197);
            lblOnlineClients.Name = "lblOnlineClients";
            lblOnlineClients.Size = new Size(204, 26);
            lblOnlineClients.TabIndex = 14;
            lblOnlineClients.Text = "Online Clients :";
            lblOnlineClients.Visible = false;
            // 
            // btnSendToAll
            // 
            btnSendToAll.AutoSize = true;
            btnSendToAll.BackColor = Color.FromArgb(215, 114, 60);
            btnSendToAll.Cursor = Cursors.Hand;
            btnSendToAll.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendToAll.ForeColor = Color.FromArgb(42, 61, 68);
            btnSendToAll.Location = new Point(361, 672);
            btnSendToAll.Name = "btnSendToAll";
            btnSendToAll.Size = new Size(142, 24);
            btnSendToAll.TabIndex = 15;
            btnSendToAll.Text = "Send To All";
            btnSendToAll.Visible = false;
            btnSendToAll.Click += btnSendToAll_Click;
            btnSendToAll.MouseEnter += btnStart_MouseEnter;
            btnSendToAll.MouseLeave += btnStart_MouseLeave;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.FromArgb(215, 114, 60);
            btnDisconnect.Cursor = Cursors.Hand;
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDisconnect.ForeColor = Color.FromArgb(42, 61, 68);
            btnDisconnect.Location = new Point(724, 146);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(193, 32);
            btnDisconnect.TabIndex = 17;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.TextAlign = ContentAlignment.MiddleCenter;
            btnDisconnect.Visible = false;
            btnDisconnect.MouseEnter += btnStart_MouseEnter;
            btnDisconnect.MouseLeave += btnStart_MouseLeave;
            // 
            // chkOnlineUsers
            // 
            chkOnlineUsers.ForeColor = Color.Green;
            chkOnlineUsers.FormattingEnabled = true;
            chkOnlineUsers.Location = new Point(724, 245);
            chkOnlineUsers.Name = "chkOnlineUsers";
            chkOnlineUsers.Size = new Size(215, 254);
            chkOnlineUsers.TabIndex = 18;
            chkOnlineUsers.Visible = false;
            // 
            // lblNoActiveUsers
            // 
            lblNoActiveUsers.BackColor = Color.Transparent;
            lblNoActiveUsers.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblNoActiveUsers.ForeColor = Color.FromArgb(215, 114, 60);
            lblNoActiveUsers.Location = new Point(724, 296);
            lblNoActiveUsers.Name = "lblNoActiveUsers";
            lblNoActiveUsers.Size = new Size(215, 109);
            lblNoActiveUsers.TabIndex = 22;
            lblNoActiveUsers.Text = "No Active Users";
            lblNoActiveUsers.TextAlign = ContentAlignment.MiddleCenter;
            lblNoActiveUsers.Visible = false;
            // 
            // lblLoginState
            // 
            lblLoginState.BackColor = Color.Transparent;
            lblLoginState.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoginState.ForeColor = Color.FromArgb(215, 114, 60);
            lblLoginState.Location = new Point(717, 92);
            lblLoginState.Name = "lblLoginState";
            lblLoginState.Size = new Size(211, 22);
            lblLoginState.TabIndex = 23;
            lblLoginState.Text = "Login State";
            lblLoginState.TextAlign = ContentAlignment.MiddleCenter;
            lblLoginState.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(42, 61, 68);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(724, 527);
            label4.Name = "label4";
            label4.Size = new Size(204, 26);
            label4.TabIndex = 24;
            label4.Text = "State Messages :";
            label4.Visible = false;
            // 
            // rtfStateMsg
            // 
            rtfStateMsg.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            rtfStateMsg.Location = new Point(704, 576);
            rtfStateMsg.Margin = new Padding(2);
            rtfStateMsg.Name = "rtfStateMsg";
            rtfStateMsg.ReadOnly = true;
            rtfStateMsg.Size = new Size(249, 176);
            rtfStateMsg.TabIndex = 25;
            rtfStateMsg.Text = "";
            rtfStateMsg.Visible = false;
            // 
            // frmChatClient
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 61, 68);
            BackgroundImage = Properties.Resources.New_Project;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 799);
            Controls.Add(rtfStateMsg);
            Controls.Add(label4);
            Controls.Add(lblLoginState);
            Controls.Add(lblNoActiveUsers);
            Controls.Add(chkOnlineUsers);
            Controls.Add(btnDisconnect);
            Controls.Add(btnSendToAll);
            Controls.Add(lblOnlineClients);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUserPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblTitle);
            Controls.Add(rtfClientReceived);
            Controls.Add(lblReceived);
            Controls.Add(lblClientState);
            Controls.Add(label1);
            Controls.Add(btnSendMsg);
            Controls.Add(txtMessage);
            Controls.Add(btnConnect);
            DoubleBuffered = true;
            Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(215, 114, 60);
            Margin = new Padding(5, 3, 5, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChatClient";
            Text = "Chat Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label btnConnect;
        private TextBox txtMessage;
        private Label btnSendMsg;
        private Label label1;
        private Label lblClientState;
        private Label lblReceived;
        private RichTextBox rtfClientReceived;
        private Label lblTitle;
        private TextBox txtUserName;
        private TextBox txtUserPassword;
        private Label label2;
        private Label label3;
        private Label lblOnlineClients;
        private Label btnSendToAll;
        private Label btnDisconnect;
        private CheckedListBox chkOnlineUsers;
        private Label lblNoActiveUsers;
        private Label lblLoginState;
        private Label label4;
        private RichTextBox rtfStateMsg;
    }
}