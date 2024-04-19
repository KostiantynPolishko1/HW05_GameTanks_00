using System.Net;
using System.Net.Sockets;
using TcpLibrary.Models;

namespace ServerCL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Server start!");

            TcpServerObj server = new TcpServerObj(new ConnectIPEndP().getIpeP());
            await server.listenAsync();
            
            Console.WriteLine("Server stop!");
        }
    }
}