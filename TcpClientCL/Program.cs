using Library.Models;
using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;

namespace TcpClientCL
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(new ConnectIPEndP().getIpeP());
                    Console.WriteLine("Client Start!");

                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());

                    Player? player = new Player() { x = 0, y = 0, color = "white"};
                    string? json = null;

                    while (true)
                    {
                        Console.WriteLine($"sent obj:\t{player}");
                        //json = JsonSerializer.Serialize(player);
                        json = JsonConvert.SerializeObject(player);
                        writer.WriteLine(json);
                        writer.Flush();

                        Console.ReadLine();

                        Console.Write("received obj:\t");
                        json = reader.ReadLine();
                        //player = JsonSerializer.Deserialize<Player>(json);
                        player = JsonConvert.DeserializeObject<Player>(json);
                        Console.WriteLine(player);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    client.Close();
                }

            }
        }
    }
}