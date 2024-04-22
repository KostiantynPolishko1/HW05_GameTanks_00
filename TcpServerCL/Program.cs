using Library.Models;
using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;

namespace TcpServerCL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(new ConnectIPEndP().getIpeP());
            try
            {
                server.Start();
                Console.WriteLine("Server Start!");

                using(TcpClient client = server.AcceptTcpClient())
                {
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    Player? player = null;
                    string? json = null;

                    while (true)
                    {
                        Console.Write("received obj:\t");
                        json = reader.ReadLine();
                        //player = JsonSerializer.Deserialize<Player>(json);
                        player = JsonConvert.DeserializeObject<Player>(json);
                        Console.WriteLine(player);

                        player.x += 10;
                        player.y += 10;

                        Console.WriteLine($"sent obj:\t{player}");
                        //json = JsonSerializer.Serialize(player);
                        json = JsonConvert.SerializeObject(player);
                        writer.WriteLine(json);
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally 
            { 
                server.Stop(); 
            }
        }
    }
}