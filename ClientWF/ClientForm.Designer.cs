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
            pcBxPlayer = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).BeginInit();
            SuspendLayout();
            // 
            // pcBxPlayer
            // 
            pcBxPlayer.BackColor = Color.Green;
            pcBxPlayer.Location = new Point(200, 200);
            pcBxPlayer.Name = "pcBxPlayer";
            pcBxPlayer.Size = new Size(100, 100);
            pcBxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            pcBxPlayer.TabIndex = 0;
            pcBxPlayer.TabStop = false;
            pcBxPlayer.BackColor = Color.Transparent;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Controls.Add(pcBxPlayer);
            KeyPreview = true;
            Name = "ClientForm";
            Text = "Client";
            KeyDown += ClientForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pcBxPlayer;
    }
}