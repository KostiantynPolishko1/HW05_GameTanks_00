namespace ClientWF
{
    public partial class ClientForm : Form
    {
        public Bitmap tank;
        public Graphics g;
        public int x { get; set; } = 50;
        public int y { get; set; } = 50;
        public int offset { get; set; } = 5;

        public ClientForm()
        {
            InitializeComponent();
            tank = new Bitmap(GameImages.tank, new Size(50, 50));
            tank.MakeTransparent(tank.GetPixel(1, 1));
        }

        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(tank, x, y);
        }

        private void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) { y += offset; }
            else if (e.KeyCode == Keys.Up) { y -= offset; }
            else if (e.KeyCode == Keys.Right) { x += offset; }
            else if (e.KeyCode == Keys.Left) { x -= offset; }

            Refresh();
        }
    }
}