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
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.AutoSize = true;
            btnConnect.BackColor = Color.Transparent;
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.Font = new Font("Stencil", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnConnect.Location = new Point(381, 9);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(138, 32);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.Click += btnConnect_Click;
            // 
            // frmChatClient
            // 
            AutoScaleDimensions = new SizeF(12F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.New_Project;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(930, 578);
            Controls.Add(btnConnect);
            DoubleBuffered = true;
            Font = new Font("Stencil", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.SandyBrown;
            Margin = new Padding(5, 3, 5, 3);
            Name = "frmChatClient";
            Text = "Chat Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label btnConnect;
    }
}