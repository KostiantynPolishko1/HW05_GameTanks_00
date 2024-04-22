using Library.Models;
using System.Net.Sockets;

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

                    while (true)
                    {
                        Console.Write("answer msg: ");
                        Console.WriteLine(reader.ReadLine());

                        Console.Write("enter msg: ");
                        writer.WriteLine(Console.ReadLine());
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