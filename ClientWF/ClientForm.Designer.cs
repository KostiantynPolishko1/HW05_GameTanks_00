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
            btnMoveUp = new Button();
            btnMoveDown = new Button();
            btnRotateCW = new Button();
            btnRotateCCW = new Button();
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).BeginInit();
            SuspendLayout();
            // 
            // pcBxPlayer
            // 
            pcBxPlayer.Location = new Point(200, 200);
            pcBxPlayer.Name = "pcBxPlayer";
            pcBxPlayer.Size = new Size(100, 100);
            pcBxPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            pcBxPlayer.TabIndex = 0;
            pcBxPlayer.TabStop = false;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(12, 12);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(100, 30);
            btnMoveUp.TabIndex = 1;
            btnMoveUp.Text = "MoveUp";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(12, 54);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(100, 30);
            btnMoveDown.TabIndex = 2;
            btnMoveDown.Text = "MoveDown";
            btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnRotateCW
            // 
            btnRotateCW.Location = new Point(12, 96);
            btnRotateCW.Name = "btnRotateCW";
            btnRotateCW.Size = new Size(100, 30);
            btnRotateCW.TabIndex = 3;
            btnRotateCW.Text = "Rotate(+)";
            btnRotateCW.UseVisualStyleBackColor = true;
            btnRotateCW.Click += btnRotateCW_Click;
            // 
            // btnRotateCCW
            // 
            btnRotateCCW.Location = new Point(12, 132);
            btnRotateCCW.Name = "btnRotateCCW";
            btnRotateCCW.Size = new Size(100, 30);
            btnRotateCCW.TabIndex = 4;
            btnRotateCCW.Text = "Rotate(-)";
            btnRotateCCW.UseVisualStyleBackColor = true;
            btnRotateCCW.Click += btnRotateCCW_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Controls.Add(btnRotateCCW);
            Controls.Add(btnRotateCW);
            Controls.Add(btnMoveDown);
            Controls.Add(btnMoveUp);
            Controls.Add(pcBxPlayer);
            Name = "ClientForm";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)pcBxPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pcBxPlayer;
        private Button btnMoveUp;
        private Button btnMoveDown;
        private Button btnRotateCW;
        private Button btnRotateCCW;
    }
}