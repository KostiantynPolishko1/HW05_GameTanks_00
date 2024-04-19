using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpLibrary.Models
{
    public class TcpServerObj
    {
        public TcpListener tcpListener;
        public List<TcpClientObj> tcpClients;

        public TcpServerObj(IPEndPoint ipEndPoint)
        {
            tcpListener = new TcpListener(ipEndPoint);
            tcpClients = new List<TcpClientObj>();
        }

        public async Task listenAsync()
        {
            try
            {
                tcpListener.Start();

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    TcpClientObj tcpClientObj = new TcpClientObj(tcpClient, this);
                    tcpClients.Add(tcpClientObj);

                    Task.Run(tcpClientObj.processAsync);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally 
            {
                disconnectTcpClient();
                tcpListener.Stop();
            }
        }

        public async Task sendMsgAsync(string msg, string id)
        {
            foreach(TcpClientObj client in tcpClients)
            {
                if (client.id != id)
                {
                    await client.writer.WriteAsync(msg);
                    await client.writer.FlushAsync();
                }
            }
        }

        public void removeConnection(string id)
        {
            TcpClientObj? client = tcpClients.FirstOrDefault(c => c.id == id);
            if (client != null) { tcpClients.Remove(client); }
            client?.closeTcpClient();
        }

        private void disconnectTcpClient()
        {
            foreach (TcpClientObj? client in tcpClients) { client?.closeTcpClient(); }
        }
    }
}
