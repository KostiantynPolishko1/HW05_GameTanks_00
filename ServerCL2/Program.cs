using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using TcpLibrary.Models;

namespace ServerCL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server2 start!");

            TcpListener tcpListener = new TcpListener(new ConnectIPEndP().getIpeP());           
            Player? player = null;

            try
            {
                tcpListener.Start();
                TcpClient client = tcpListener.AcceptTcpClient();
                StreamReader sreader = new StreamReader(client.GetStream());
                StreamWriter swriter = new StreamWriter(client.GetStream());

                while (true)
                {
                    player = JsonSerializer.Deserialize<Player>(sreader.ReadLine());
                    //player.color = Color.Red;
                    player.ptn = new Point(20, 20);

                    string obj = JsonSerializer.Serialize(player);

                    swriter.WriteLine(JsonSerializer.Serialize(player));
                    swriter.Flush();
                }
                
                swriter.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                tcpListener.Stop();
            }
        }
    }
}