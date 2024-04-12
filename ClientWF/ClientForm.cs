using System.Drawing;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        private Bitmap bmp;

        public ClientForm()
        {
            InitializeComponent();
            bmp = new Bitmap("A:\\OneDrive - ITSTEP\\NetworkProg\\Projects\\HW05_GameTanks_00\\tank.png");

            setMainColor();

            Color backColor = bmp.GetPixel(1, 1);
            bmp.MakeTransparent(backColor);

            pcBxPlayer.Image = bmp;
        }

        private void setMainColor()
        {
            for (int i = 0; i != bmp.Width; i++)
            {
                for (int j = 0; j != bmp.Height; j++)
                {
                    if (bmp.GetPixel(i, j) == Color.FromArgb(0, 255, 0))
                    {
                        bmp.SetPixel(i, j, Color.Brown);
                    }
                }
            }
        }

        private Bitmap rotateBitMap(int angle, Bitmap bmp)
        {
            (int width, int height) = getSizeRotation(angle, bmp);

            Bitmap rBmp = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(rBmp);
            g.TranslateTransform(width / 2, height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
            g.DrawImage(bmp, 0, 0);

            return rBmp;
        }

        private (int, int) getSizeRotation(int angle, Bitmap bmp)
        {
            int width = (int)(Math.Abs(bmp.Width * Math.Cos(Math.PI * angle / 180)) + Math.Abs(bmp.Height * Math.Sin(Math.PI * angle / 180)));
            int height = (int)(Math.Abs(bmp.Height * Math.Cos(Math.PI * angle / 180)) + Math.Abs(bmp.Width * Math.Sin(Math.PI * angle / 180)));

            return (width, height);
        }

        private void rotateTank(int angle)
        {
            bmp = rotateBitMap(angle, bmp);
            pcBxPlayer.Image = bmp;
            pcBxPlayer.Refresh();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRotateCW_Click(object sender, EventArgs e)
        {
            rotateTank(90);
        }

        private void btnRotateCCW_Click(object sender, EventArgs e)
        {
            rotateTank(-90);
        }
    }
}