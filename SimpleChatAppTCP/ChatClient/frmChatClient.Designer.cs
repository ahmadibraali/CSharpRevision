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
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.AutoSize = true;
            btnConnect.BackColor = Color.FromArgb(215, 114, 60);
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnConnect.ForeColor = Color.FromArgb(42, 61, 68);
            btnConnect.Location = new Point(750, 302);
            btnConnect.Margin = new Padding(4, 0, 4, 0);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(138, 32);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.Click += btnConnect_Click;
            btnConnect.MouseEnter += btnStart_MouseEnter;
            btnConnect.MouseLeave += btnStart_MouseLeave;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtMessage.Location = new Point(172, 515);
            txtMessage.Margin = new Padding(4);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(497, 117);
            txtMessage.TabIndex = 2;
            txtMessage.Visible = false;
            // 
            // btnSendMsg
            // 
            btnSendMsg.AutoSize = true;
            btnSendMsg.BackColor = Color.FromArgb(215, 114, 60);
            btnSendMsg.Cursor = Cursors.Hand;
            btnSendMsg.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendMsg.ForeColor = Color.FromArgb(42, 61, 68);
            btnSendMsg.Location = new Point(307, 655);
            btnSendMsg.Margin = new Padding(4, 0, 4, 0);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(217, 32);
            btnSendMsg.TabIndex = 3;
            btnSendMsg.Text = "Send Message";
            btnSendMsg.Visible = false;
            btnSendMsg.Click += btnSendMsg_Click;
            btnSendMsg.MouseEnter += btnStart_MouseEnter;
            btnSendMsg.MouseLeave += btnStart_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 80);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(262, 32);
            label1.TabIndex = 4;
            label1.Text = "Current State : ";
            label1.Visible = false;
            // 
            // lblClientState
            // 
            lblClientState.AutoSize = true;
            lblClientState.BackColor = Color.Transparent;
            lblClientState.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblClientState.Location = new Point(283, 80);
            lblClientState.Margin = new Padding(4, 0, 4, 0);
            lblClientState.Name = "lblClientState";
            lblClientState.Size = new Size(0, 32);
            lblClientState.TabIndex = 5;
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.BackColor = Color.Transparent;
            lblReceived.BorderStyle = BorderStyle.Fixed3D;
            lblReceived.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblReceived.Location = new Point(13, 300);
            lblReceived.Margin = new Padding(4, 0, 4, 0);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(152, 34);
            lblReceived.TabIndex = 6;
            lblReceived.Text = "Recieved";
            lblReceived.Visible = false;
            // 
            // rtfClientReceived
            // 
            rtfClientReceived.Enabled = false;
            rtfClientReceived.Font = new Font("Stencil", 13F, FontStyle.Bold, GraphicsUnit.Point);
            rtfClientReceived.Location = new Point(172, 153);
            rtfClientReceived.Name = "rtfClientReceived";
            rtfClientReceived.ReadOnly = true;
            rtfClientReceived.Size = new Size(498, 332);
            rtfClientReceived.TabIndex = 8;
            rtfClientReceived.Text = "";
            rtfClientReceived.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(215, 114, 60);
            lblTitle.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(42, 61, 68);
            lblTitle.Location = new Point(341, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 32);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Client Side";
            lblTitle.MouseEnter += btnStart_MouseEnter;
            lblTitle.MouseLeave += btnStart_MouseLeave;
            // 
            // frmChatClient
            // 
            AutoScaleDimensions = new SizeF(14F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.New_Project;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 799);
            Controls.Add(lblTitle);
            Controls.Add(rtfClientReceived);
            Controls.Add(lblReceived);
            Controls.Add(lblClientState);
            Controls.Add(label1);
            Controls.Add(btnSendMsg);
            Controls.Add(txtMessage);
            Controls.Add(btnConnect);
            DoubleBuffered = true;
            Font = new Font("FiraCode Nerd Font", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.SandyBrown;
            Margin = new Padding(6, 4, 6, 4);
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
    }
}