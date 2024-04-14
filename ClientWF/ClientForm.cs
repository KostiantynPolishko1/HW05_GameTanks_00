using System.Drawing;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        private Bitmap bmp;
        private readonly int width;
        private readonly int height;
        private int angle;
        private readonly int angleRotate;
        private readonly Dictionary<string, int[]> vDirections;
        private readonly int offsetMove;
        private int row;
        private int col;

        public ClientForm()
        {
            InitializeComponent();
            bmp = new Bitmap("A:\\OneDrive - ITSTEP\\NetworkProg\\Projects\\HW05_GameTanks_00\\tank.png");
            width = bmp.Width;
            height = bmp.Height;
            angle = 0;
            angleRotate = 30;
            offsetMove = 5;
            vDirections = new Dictionary<string, int[]> { { "forward", new int[] { -1, 1} }, { "backward", new int[] {1, -1 } } };
            row = pcBxPlayer.Top;
            col = pcBxPlayer.Left;
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

        private void moveTank(in string direction)
        {
            row = (int)(Math.Cos(Math.PI * this.angle / 180) * vDirections[direction][0] * offsetMove) + row;
            col = (int)(Math.Sin(Math.PI * this.angle / 180) * vDirections[direction][1] * offsetMove) + col;

            pcBxPlayer.Location = new Point(col, row);
            pcBxPlayer.Refresh();
        }

        private void rotateTank(int angle)
        {
            this.angle += angle;
            if(this.angle > 360 || this.angle < -360) { this.angle = 0; }

            bmp = rotateBitMap(angle, bmp);
            pcBxPlayer.Image = bmp;
            pcBxPlayer.Refresh();
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
            int width = (int)(Math.Abs(this.width * Math.Cos(Math.PI * this.angle / 180)) + Math.Abs(this.height * Math.Sin(Math.PI * this.angle / 180)));
            int height = (int)(Math.Abs(this.height * Math.Cos(Math.PI * this.angle / 180)) + Math.Abs(this.width * Math.Sin(Math.PI * this.angle / 180)));

            return (width, height);
        }

        private void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { rotateTank(angleRotate); }
            else if (e.KeyCode == Keys.Left) { rotateTank(-angleRotate); }
            else if (e.KeyCode == Keys.Up) { moveTank("forward"); }
            else if (e.KeyCode == Keys.Down) { moveTank("backward"); }
        }
    }
}