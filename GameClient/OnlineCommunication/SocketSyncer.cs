using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace GameClient
{
    public class SocketSyncer
    {

        // Declare our worker thread
        private Thread workerThread = null;

        private readonly IClient client;
        private static string ipAddress = SocketServer.ServerProperties.ip;
        private static int port = SocketServer.ServerProperties.port;
        private bool connected = false;

        SyncObject item = new SyncObject();


        public SocketSyncer()
        {
            workerThread = new Thread(new ThreadStart(StartWorkerThread));
            client = new ProxyClient(ipAddress, port);
            //client = new RealClient(ipAddress, port);

        }

        public void Start()
        {
            workerThread.Start();
        }

        public void Stop()
        {
            workerThread.Abort();
            if (connected)
            {
                client.Send("");
                client.Close();
            }
        }


        public void StartWorkerThread()
        {
            Stopwatch sw = new Stopwatch();
            Process proc = Process.GetCurrentProcess();
            sw.Start();

            connected = client.Connect();

            sw.Stop();
            Console.WriteLine("Proxy greitaveika.");
            Console.WriteLine("Time elapsed: " + sw.Elapsed + " ms");
            Console.WriteLine("Memory used: " + proc.PrivateMemorySize64 + " ");

            while (true)
            {
                UpdateData();
                Thread.Sleep(1000 / 60);
            }
        }

        private void UpdateData()
        {
            UpdateSyncObject();

            var myContent = JsonConvert.SerializeObject(item);
            connected = client.Send(myContent);
            GetData();
        }


        private void UpdateSyncObject()
        {
            UpdatePlayerInformation();
            UpdateValveInformation();
        }

        private void UpdateValveInformation()
        {
            item.valves = GameStateSingleton.getInstance().LocalValvesStates;
        }

        private void UpdatePlayerInformation()
        {
            item.Player1 = GameStateSingleton.getInstance().Player1;
            item.Player2 = GameStateSingleton.getInstance().Player2;
        }


        private void GetData()
        {
            var result = client.WaitForReply();
            var _item = JsonConvert.DeserializeObject<SyncObject>(result);
            

            GameStateSingleton.getInstance().Player2 = _item.Player2;
            GameStateSingleton.getInstance().Player1 = _item.Player1;
            GameStateSingleton.getInstance().ClientID = _item.ClientID;
            GameStateSingleton.getInstance().LevelID = _item.levelID;
            GameStateSingleton.getInstance().SyncedValvesStates = _item.valves;


        }
    }
}
