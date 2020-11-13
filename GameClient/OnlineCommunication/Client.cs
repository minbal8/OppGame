using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameClient
{
    public class Client
    {

        IPEndPoint localEndPoint;
        IPAddress ipAddress;
        Socket handler;

        public Client(string ip, int port)
        {
            ipAddress = IPAddress.Parse(ip);
            localEndPoint = new IPEndPoint(ipAddress, port);

        }

        public bool Connect()
        {
            try
            {
                handler = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                handler.Connect(localEndPoint);
                return true;
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                //Console.WriteLine("Could not connect to server, retrying...");

                Console.WriteLine("Could not connect to server. Check if server is online and try again");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            return false;

        }

        public bool Send(string message)
        {
            if (handler == null)
                return false;

            byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");
            try
            {
                int bytesSent = handler.Send(msg);
                return true;
            }
            catch
            {
                Console.WriteLine("Disconnected from server");

                handler = null;
                return false;
            }
        }

        public string WaitForReply()
        {
            if (handler != null)
            {
                String data = null;

                while (true)
                {
                    var bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }
                data = data.Replace("<EOF>", "");
                return data;
            }
            return String.Empty;

        }

        public bool Close()
        {
            try
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}

