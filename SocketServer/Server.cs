using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketServer
{

    public class Server
    {

        IPEndPoint localEndPoint;
        IPAddress ipAddress;
        Socket listener;
        Socket handler;

        int numberOfClients = 2;

        SyncObject syncObject = new SyncObject();

        int[] clientsID;
        Thread[] Threads;



        public Server(string ip, int port)
        {
            ipAddress = IPAddress.Parse(ip);
            localEndPoint = new IPEndPoint(ipAddress, port);
            clientsID = new int[numberOfClients];
            Threads = new Thread[numberOfClients];

        }

        public bool Connect()
        {
            try
            {
                Console.WriteLine("Starting server on: " + localEndPoint.ToString() + "...");
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(100);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WaitForConnection()
        {
            handler = listener.Accept();
            StartListeneningToClient();
            Console.WriteLine("Connected");
            WaitForConnection();
        }

        private void StartListeneningToClient()
        {
            int id = GetCurrentID();
            if (id >= 0)
            {
                clientsID[id] = 1;
                Threads[id] = new Thread(() =>
                {
                    ServerClient client = new ServerClient();
                    client.syncObject = syncObject;
                    client.handler = handler;
                    client.id = id;
                    bool listen = true;

                    while (listen)
                    {
                        listen = client.Listen();
                    }
                    lock (clientsID)
                    {
                        clientsID[client.id] = 0;
                    }
                    Console.WriteLine("Client" + client.id + "Disconnected");
                    Thread.CurrentThread.Join();

                });
                Threads[id].Start();
            }
            else
            {
                Console.WriteLine("Server is full");
            }
        }

        private int GetCurrentID()
        {
            lock (clientsID)
            {

                for (int i = 0; i < numberOfClients; i++)
                {
                    if (clientsID[i] == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
