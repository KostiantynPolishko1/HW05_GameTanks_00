﻿using System.Net;

namespace Library.Models
{
    public class ConnectIPEndP
    {
        public readonly string IP_SERVER_ADDR;
        public readonly int PORT_SERVER_ADDR;

        public ConnectIPEndP() : this("127.0.0.1", 4000) { }

        public ConnectIPEndP(string? IP_SERVER_ADDR, int PORT_SERVER_ADDR)
        {
            this.IP_SERVER_ADDR = IP_SERVER_ADDR ??= "127.0.0.1";
            this.PORT_SERVER_ADDR = PORT_SERVER_ADDR;
        }

        public IPEndPoint getIpeP()
        {
            if (IPAddress.TryParse(IP_SERVER_ADDR, out IPAddress? ipAdress))
            { return new IPEndPoint(ipAdress, PORT_SERVER_ADDR); }

            return new IPEndPoint(IPAddress.Any, PORT_SERVER_ADDR);
        }
    }
}