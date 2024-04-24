using ClientWF.Models;
using ClientWF.Resources;
using System.Threading.Tasks;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        public Graphics? g;
        public BmpPlayer player;
        public BmpPlayer bullet;
        public int xBullet;
        public int yBullet;
        public bool isBullet { get; set; } = false;
        TaskScheduler taskScheduler;

        public ClientForm()
        {
            InitializeComponent();
            player = new BmpPlayer(GameImages.tank, new Size(50, 50));
            bullet = new BmpPlayer(GameImages.bullet, new Size(8, 10));
            taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            xBullet = player.x + 21;
            yBullet = player.y - 10;
        }

        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(player.bmp, player.x, player.y);

            if(isBullet)
            {
                g.DrawImage(bullet.bmp, xBullet, yBullet);
            }           
        }

        private async void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            await Task.Run(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    player.movePayer(e);
                    Refresh();

                }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
            });

            await Task.Run(() =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    xBullet = player.x + 21;
                    yBullet = player.y - 10;

                    isBullet = true;
                    do
                    {
                        Thread.Sleep(15);
                        Task.Factory.StartNew(() =>
                        {
                            yBullet -= 2;
                            Refresh();
                        }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
                    } while (yBullet > 0);

                    isBullet = false;
                }
            });
           
        }
    }
}