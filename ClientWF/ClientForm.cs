namespace ClientWF
{
    public partial class ClientForm : Form
    {
        private int step;
        private int x;
        MethodInvoker? methodInvoker;
        TaskScheduler taskScheduler;

        public ClientForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = true;
            step = 10;
            x = pcBxPlayer.Left;
            taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //methodInvoker = delegate(){ simpleCycle2(); };
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //movePcBxAuto();
        }

        private void movePcBxAuto()
        {
            int count = (this.Width - pcBxAuto.Width) / step;

            MethodInvoker methodInvoker = delegate ()
            {
                while (true)
                {
                    for (int i = 0; i != count; i++)
                    {
                        pcBxAuto.Left += step;
                        Thread.Sleep(50);
                    }
                    for (int i = 0; i != count; i++)
                    {
                        pcBxAuto.Left -= step;
                        Thread.Sleep(50);
                    }
                }
            };

            if (this.InvokeRequired) this.Invoke(methodInvoker);
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

                //await Task.Run(() => { movePcBxAuto(); });
                //await testAsync(15);
                //await testAsync2(15);
                //await testAsync3(15);
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

        private async Task testAsync(int count)
        {
            lbInfo.Text = $"start: {DateTime.Now.Second}";

            await Task.Run(() =>
            {
                for (int i = 0; i != count; i++)
                {
                    Thread.Sleep(1000);
                }
            });

            lbInfo.Text = $"finish: {DateTime.Now.Second}";
        }

        private async Task testAsync2(int count)
        {
            lbInfo.Text = $"start: {DateTime.Now.Second}";

            await Task.Run(() =>
            {
                if (this.InvokeRequired) this.Invoke(this.methodInvoker);
            });

            lbInfo.Text = $"finish: {DateTime.Now.Second}";
        }

        private async Task testAsync3(int count)
        {
            lbInfo.Text = $"start: {DateTime.Now.Second}";

            await Task.Run(() =>
            {
                simpleCycle(count);
            });

            lbInfo.Text = $"finish: {DateTime.Now.Second}";
        }

        private void simpleCycle(int count)
        {
            for (int i = 0; i != count; i++)
            {
                Thread.Sleep(1000);

                Task.Factory.StartNew(() =>
                {
                    lbInfo.Text = $"Now: {DateTime.Now.Second}";
                }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
            }
        }

        private void simpleCycle2()
        {
            for (int i = 0; i != 10; i++)
            {
                Thread.Sleep(1000);
                lbInfo.Text = $"Now: {DateTime.Now.Second}";
            }
        }
    }
}