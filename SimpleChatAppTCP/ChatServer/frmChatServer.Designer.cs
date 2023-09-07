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
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(215, 114, 60);
            lblStatus.Location = new Point(414, 376);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(157, 28);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Current State : ";
            // 
            // lblCurrentState
            // 
            lblCurrentState.AutoSize = true;
            lblCurrentState.BackColor = Color.Transparent;
            lblCurrentState.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentState.ForeColor = Color.FromArgb(215, 114, 60);
            lblCurrentState.Location = new Point(587, 376);
            lblCurrentState.Name = "lblCurrentState";
            lblCurrentState.Size = new Size(95, 28);
            lblCurrentState.TabIndex = 2;
            lblCurrentState.Text = "Stopped";
            // 
            // btnStart
            // 
            btnStart.AutoSize = true;
            btnStart.BackColor = Color.Transparent;
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("SimSun-ExtB", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.FromArgb(215, 114, 60);
            btnStart.Location = new Point(427, 316);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(269, 40);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start Server";
            btnStart.Click += btnStart_Click;
            // 
            // frmChatServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._6060363;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1128, 674);
            Controls.Add(btnStart);
            Controls.Add(lblCurrentState);
            Controls.Add(lblStatus);
            Name = "frmChatServer";
            Text = "ChatServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblStatus;
        private Label lblCurrentState;
        private Label btnStart;
    }
}