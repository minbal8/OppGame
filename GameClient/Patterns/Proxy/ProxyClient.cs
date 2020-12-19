using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class ProxyClient : IClient
    {
        private RealClient client;
        private bool isConnected;

        public ProxyClient(string ip, int port)
        {
            client = new RealClient(ip, port);
            isConnected = false;
        }

        public bool Close()
        {

            if (isConnected)
            {
                isConnected = false;
                return client.Close();
            }
            else
            {
                isConnected = false;
                return true;
            }
        }

        public bool Connect()
        {
            if (!isConnected)
            {
                isConnected = client.Connect();
                return isConnected;
            }
            else
            {
                return false;
            }
        }

        public bool Send(string message)
        {
            if (isConnected)
            {
                return client.Send(message);
            }
            else
            {
                return false;
            }
        }

        public string WaitForReply()
        {
            if (isConnected)
            {
                return client.WaitForReply();
            }
            else
            {
                return "";
            }
        }
    }
}
