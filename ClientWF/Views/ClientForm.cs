using ClientWF.Models;
using ClientWF.Resources;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        public Graphics? g;
        public BmpPlayer player;
        public ClientForm()
        {
            InitializeComponent();
            //g = this.CreateGraphics();
            player = new BmpPlayer(GameImages.tank, new Size(50, 50));
        }

        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(player.bmp, player.x, player.y);
        }

        private void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) { player.y += player.offset; }
            else if (e.KeyCode == Keys.Up) { player.y -= player.offset; }
            else if (e.KeyCode == Keys.Right) { player.x += player.offset; }
            else if (e.KeyCode == Keys.Left) { player.x -= player.offset; }

            Refresh();
        }
    }
}