using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient
{
    public class SocketSyncer
    {

        // Declare our worker thread
        private Thread workerThread = null;

        private readonly Client client;
        private static string ipAddress = "192.168.192.142";
        private static int port = 8888;

        SyncObject item = new SyncObject();

        public void setUrl(string url)
        {
            GameStateSingleton.getInstance().ClientID = 1;

            GameStateSingleton.getInstance().DebugText = "" + GameStateSingleton.getInstance().ClientID;
        }

        public SocketSyncer()
        {
            workerThread = new Thread(new ThreadStart(StartWorkerThread));
            client = new Client(ipAddress, port);

        }

        public void Start()
        {
            client.Connect();
            workerThread.Start();
        }

        public void Stop()
        {

            workerThread.Abort();
            client.Send("");
            client.Close();
        }


        public void StartWorkerThread()
        {
            while (true)
            {
                UpdateData();
                Thread.Sleep(50);
            }
        }

        private void UpdateData()
        {
            UpdateSyncObject();

            var myContent = JsonConvert.SerializeObject(item);
            client.Send(myContent);
            GetData();
        }


        private void UpdateSyncObject()
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


        }
    }
}
