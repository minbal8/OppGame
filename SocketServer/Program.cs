using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        private static string ipAddress = ServerProperties.ip;
        private static int port = ServerProperties.port;


        static void Main()
        {

            int level = 0;
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("1 - Easy Logic level");
                Console.WriteLine("2 - Easy Speed level");
                Console.WriteLine("3 - Hard Logic level");
                Console.WriteLine("4 - Hard Speed level");

                loop = int.TryParse(Console.ReadLine(), out level);
                if (level > 4)
                {
                    loop = false;
                }
            }

            Console.WriteLine(level);


            Server server = new Server(ipAddress, port, level);

            if (server.Connect())
            {
                Console.WriteLine("Server succesfully created");
                Console.WriteLine("Waiting for connections...");
                server.WaitForConnection();
            }
        }
    }
}
