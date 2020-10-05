using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        private static string ipAddress = "192.168.192.142";
        private static int port = 8888;


        static void Main()
        {

            Server server = new Server(ipAddress, port);

            if (server.Connect())
            {
                Console.WriteLine("Server succesfully created");
                Console.WriteLine("Waiting for connections...");
                server.WaitForConnection();
            }
        }
    }
}
