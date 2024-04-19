using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpLibrary.Models
{
    public class TcpClientObj
    {
        public string id { get; }
        public StreamWriter writer { get; }
        public StreamReader reader { get; }

        public TcpClient client;
        public TcpServerObj server;

        public TcpClientObj(TcpClient tcpClient, TcpServerObj tcpServer)
        {
            id = Guid.NewGuid().ToString();
            this.client = tcpClient;
            this.server = tcpServer;
            writer = new StreamWriter(this.client.GetStream());
            reader = new StreamReader(this.client.GetStream());
        }

        public async Task processAsync()
        {
            try
            {
                string? user = await reader.ReadLineAsync();
                string? msg = $"{user} entered to chat";

                await server.sendMsgAsync(msg, id);
                Console.WriteLine(msg);

                while (true)
                {
                    try
                    {
                        msg = await reader.ReadLineAsync();
                        if (msg == null) continue;

                        string? msgChat = $"{user}: {msg}";
                        Console.WriteLine(msgChat);

                        await server.sendMsgAsync(msgChat, id);
                    }
                    catch
                    {
                        msg = $"{user} leaved chat";
                        Console.WriteLine(msg);
                        await server.sendMsgAsync(msg, id);
                        break;
                    }
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { server.removeConnection(id); }
        }

        public void closeTcpClient()
        {
            writer.Close();
            reader.Close();
            client.Close();
        }
    }
}
