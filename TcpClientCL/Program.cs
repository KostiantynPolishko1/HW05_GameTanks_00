using Library.Models;
using System.Net.Sockets;

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

                    while (true)
                    {
                        Console.Write("enter msg: ");
                        writer.WriteLine(Console.ReadLine());
                        writer.Flush();

                        Console.Write("answer msg: ");
                        Console.WriteLine(reader.ReadLine());
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