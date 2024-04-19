using ClientCL.Models;
using System.Net;
using System.Net.Sockets;
using TcpLibrary.Models;

namespace ClientCL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Client Start!");

            using (TcpClient client = new TcpClient())
            {
                Console.Write("enter name: ");
                string? user = Console.ReadLine();

                StreamReader? reader = null;
                StreamWriter? writer = null;

                try
                {
                    client.Connect(new ConnectIPEndP().getIpeP());
                    reader = new StreamReader(client.GetStream());
                    writer = new StreamWriter(client.GetStream());

                    if (writer == null || reader == null) return;

                    Task.Run(() => ClientExtensions.ReceiveMessageAsync(reader));
                    await writer.WriteLineAsync(user);
                    await writer.FlushAsync();
                    await ClientExtensions.SendMessageAsync(writer);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    writer?.Dispose();
                    reader?.Dispose();
                }
            }

            Console.WriteLine("Client Stop!");
        }
    }
}