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
            btnStart = new Button();
            lblStatus = new Label();
            lblCurrentState = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Transparent;
            btnStart.BackgroundImageLayout = ImageLayout.None;
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("SimSun-ExtB", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.FromArgb(215, 114, 60);
            btnStart.Location = new Point(245, 176);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(297, 117);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(215, 114, 60);
            lblStatus.Location = new Point(245, 312);
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
            lblCurrentState.Location = new Point(408, 312);
            lblCurrentState.Name = "lblCurrentState";
            lblCurrentState.Size = new Size(95, 28);
            lblCurrentState.TabIndex = 2;
            lblCurrentState.Text = "Stopped";
            // 
            // frmChatServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._6060363;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCurrentState);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Name = "frmChatServer";
            Text = "ChatServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblStatus;
        private Label lblCurrentState;
    }
}