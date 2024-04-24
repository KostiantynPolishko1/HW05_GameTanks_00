namespace ClientWF
{
    public partial class ClientForm : Form
    {
        private int step;
        private int x;
        TaskScheduler taskScheduler;

        public ClientForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = true;
            step = 10;
            x = pcBxPlayer.Left;
            taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void movePcBxAuto2()
        {
            int count = (this.Width - pcBxAuto.Width) / step;
            while (true)
            {
                for (int i = 0; i != count; i++)
                {                    
                    Thread.Sleep(50);
                    Task.Factory.StartNew(() =>
                    {
                        pcBxAuto.Left += step;
                    }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);

                }
                for (int i = 0; i != count; i++)
                {
                    Thread.Sleep(50);
                    Task.Factory.StartNew(() =>
                    {
                        pcBxAuto.Left -= step;
                    }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
                }
            }
        }

        private async void ClientForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                await Task.Run(() => 
                {
                    movePcBxAuto2();
                });
            }
        }

        private async void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                await Task.Run(() => { x += step; });
            }
            else if (e.KeyCode == Keys.Left)
            {
                await Task.Run(() => { x -= step; });
            }

            pcBxPlayer.Left = x;
        }
    }
}