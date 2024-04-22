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
            pcBxUser = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcBxUser).BeginInit();
            SuspendLayout();
            // 
            // pcBxUser
            // 
            pcBxUser.BackColor = Color.FromArgb(128, 255, 255);
            pcBxUser.Location = new Point(0, 0);
            pcBxUser.Name = "pcBxUser";
            pcBxUser.Size = new Size(55, 52);
            pcBxUser.TabIndex = 0;
            pcBxUser.TabStop = false;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 400);
            Controls.Add(pcBxUser);
            Name = "ClientForm";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)pcBxUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pcBxPlayer;
        private Button btnMoveUp;
        private Button btnMoveDown;
        private Button btnRotateCW;
        private Button btnRotateCCW;
        private PictureBox pcBxUser;
    }
}