namespace ChatServer
{
    partial class frmChatServer
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
            lblStatus = new Label();
            lblCurrentState = new Label();
            btnStart = new Label();
            label1 = new Label();
            btnSendMsg = new Label();
            txtMessage = new TextBox();
            lblTitle = new Label();
            rtfMsgContent = new RichTextBox();
            lblOnlineClients = new Label();
            btnSendToAll = new Label();
            comboboxOnline = new ComboBox();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.FromArgb(42, 61, 68);
            lblStatus.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(215, 114, 60);
            lblStatus.Location = new Point(25, 65);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(202, 24);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Current State : ";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentState
            // 
            lblCurrentState.AutoSize = true;
            lblCurrentState.BackColor = Color.Transparent;
            lblCurrentState.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentState.ForeColor = Color.FromArgb(215, 114, 60);
            lblCurrentState.Location = new Point(293, 65);
            lblCurrentState.Name = "lblCurrentState";
            lblCurrentState.Size = new Size(58, 24);
            lblCurrentState.TabIndex = 2;
            lblCurrentState.Text = "Idle";
            lblCurrentState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStart.BackColor = Color.FromArgb(215, 114, 60);
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.FromArgb(42, 61, 68);
            btnStart.Location = new Point(724, 9);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(193, 32);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start Server";
            btnStart.TextAlign = ContentAlignment.MiddleCenter;
            btnStart.Click += btnStart_Click;
            btnStart.MouseEnter += btnStart_MouseEnter;
            btnStart.MouseLeave += btnStart_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(42, 61, 68);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(215, 114, 60);
            label1.Location = new Point(25, 351);
            label1.Name = "label1";
            label1.Size = new Size(132, 26);
            label1.TabIndex = 4;
            label1.Text = "Message : ";
            label1.Visible = false;
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
            btnSendMsg.TabIndex = 7;
            btnSendMsg.Text = "Send Msg";
            btnSendMsg.TextAlign = ContentAlignment.MiddleCenter;
            btnSendMsg.Visible = false;
            btnSendMsg.Click += btnSendMsg_ClickAsync;
            btnSendMsg.MouseEnter += btnStart_MouseEnter;
            btnSendMsg.MouseLeave += btnStart_MouseLeave;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtMessage.Location = new Point(213, 562);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(290, 76);
            txtMessage.TabIndex = 6;
            txtMessage.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(215, 114, 60);
            lblTitle.Font = new Font("FiraCode Nerd Font Propo", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(42, 61, 68);
            lblTitle.Location = new Point(317, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 32);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Server Side";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseEnter += btnStart_MouseEnter;
            lblTitle.MouseLeave += btnStart_MouseLeave;
            // 
            // rtfMsgContent
            // 
            rtfMsgContent.BackColor = SystemColors.ControlLightLight;
            rtfMsgContent.Font = new Font("FiraCode Nerd Font Propo", 7.2F, FontStyle.Bold, GraphicsUnit.Point);
            rtfMsgContent.Location = new Point(213, 188);
            rtfMsgContent.Name = "rtfMsgContent";
            rtfMsgContent.ReadOnly = true;
            rtfMsgContent.Size = new Size(290, 343);
            rtfMsgContent.TabIndex = 9;
            rtfMsgContent.Text = "";
            rtfMsgContent.Visible = false;
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
            lblOnlineClients.TabIndex = 17;
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
            btnSendToAll.TabIndex = 19;
            btnSendToAll.Text = "Send To All";
            btnSendToAll.Visible = false;
            // 
            // comboboxOnline
            // 
            comboboxOnline.DropDownStyle = ComboBoxStyle.Simple;
            comboboxOnline.FormattingEnabled = true;
            comboboxOnline.Location = new Point(724, 243);
            comboboxOnline.Name = "comboboxOnline";
            comboboxOnline.Size = new Size(208, 288);
            comboboxOnline.TabIndex = 20;
            comboboxOnline.Visible = false;
            // 
            // frmChatServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.New_Project;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 799);
            Controls.Add(comboboxOnline);
            Controls.Add(btnSendToAll);
            Controls.Add(lblOnlineClients);
            Controls.Add(rtfMsgContent);
            Controls.Add(lblTitle);
            Controls.Add(btnSendMsg);
            Controls.Add(txtMessage);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(lblCurrentState);
            Controls.Add(lblStatus);
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(215, 114, 60);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChatServer";
            Text = "ChatServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblStatus;
        private Label lblCurrentState;
        private Label btnStart;
        private Label label1;
        private Label btnSendMsg;
        private TextBox txtMessage;
        private Label lblTitle;
        private RichTextBox rtfMsgContent;
        private Label lblOnlineClients;
        private Label btnSendToAll;
        private ComboBox comboboxOnline;
    }
}