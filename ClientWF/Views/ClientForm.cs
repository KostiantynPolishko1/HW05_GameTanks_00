using ClientWF.Models;
using ClientWF.Resources;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        public Graphics? g;
        public BmpPlayer player;
        public BmpPlayer bullet;
        public int xBullet;
        public int yBullet;
        public ClientForm()
        {
            InitializeComponent();
            player = new BmpPlayer(GameImages.tank, new Size(50, 50));
            bullet = new BmpPlayer(GameImages.bullet, new Size(8, 10));

            xBullet = player.x + 21;
            yBullet = player.y - 10;
        }

        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(player.bmp, player.x, player.y);
            g.DrawImage(bullet.bmp, xBullet, yBullet);
        }

        private void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            player.movePayer(e);
            xBullet = player.x + 21;
            yBullet = player.y - 10;

            if (e.KeyCode == Keys.Enter) 
            {
                do
                {
                    yBullet -= 2;
                    Thread.Sleep(10);

                    Refresh();
                } while (yBullet > 0);
            }

            Refresh();
        }
    }
}