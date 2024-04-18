namespace ClientWF
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pcBxAuto = new PictureBox();
            pcBxPlayer = new PictureBox();
            lbInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pcBxAuto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).BeginInit();
            SuspendLayout();
            // 
            // pcBxAuto
            // 
            pcBxAuto.BackColor = Color.Blue;
            pcBxAuto.Location = new Point(0, 50);
            pcBxAuto.Name = "pcBxAuto";
            pcBxAuto.Size = new Size(50, 50);
            pcBxAuto.TabIndex = 0;
            pcBxAuto.TabStop = false;
            // 
            // pcBxPlayer
            // 
            pcBxPlayer.BackColor = Color.Green;
            pcBxPlayer.Location = new Point(50, 400);
            pcBxPlayer.Name = "pcBxPlayer";
            pcBxPlayer.Size = new Size(50, 50);
            pcBxPlayer.TabIndex = 1;
            pcBxPlayer.TabStop = false;
            // 
            // lbInfo
            // 
            lbInfo.BackColor = Color.Yellow;
            lbInfo.Location = new Point(10, 10);
            lbInfo.Margin = new Padding(0);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(150, 20);
            lbInfo.TabIndex = 2;
            lbInfo.Text = "Info";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Controls.Add(lbInfo);
            Controls.Add(pcBxPlayer);
            Controls.Add(pcBxAuto);
            KeyPreview = true;
            Name = "ClientForm";
            Text = "Client";
            Load += ClientForm_Load;
            KeyDown += ClientForm_KeyDown;
            KeyPress += ClientForm_KeyPress;
            ((System.ComponentModel.ISupportInitialize)pcBxAuto).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pcBxAuto;
        private PictureBox pcBxPlayer;
        private Label lbInfo;
    }
}