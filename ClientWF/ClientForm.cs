using System.Net.Sockets;
using System.Text.Json;
using TcpLibrary.Models;

namespace ClientWF
{
    public partial class ClientForm : Form
    {
        public Player? player { get; set; }
        public ClientForm()
        {
            InitializeComponent();
            player = new Player();

            setPcBxPlayer(player);
            startPlayer();
        }

        public void startPlayer()
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(new ConnectIPEndP().getIpeP());
                StreamReader sreader = new StreamReader(client.GetStream());
                StreamWriter swriter = new StreamWriter(client.GetStream());

                swriter.WriteLine(JsonSerializer.Serialize(player));
                swriter.Flush();

                player = JsonSerializer.Deserialize<Player>(sreader.ReadLine());
                setPcBxPlayer(player);

                swriter.Close();
            }
        }

        private void setPcBxPlayer(Player? player)
        {
            pcBxUser.Location = player.ptn;
            //pcBxUser.BackColor = player.color;
        }
    }
}