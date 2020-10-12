using Newtonsoft.Json;
using System.Threading;

namespace GameClient
{
    public class SocketSyncer
    {

        // Declare our worker thread
        private Thread workerThread = null;

        private readonly Client client;
        private static string ipAddress = "192.168.192.142";
        private static int port = 8888;
        private bool connected = false;

        SyncObject item = new SyncObject();

        public SocketSyncer()
        {
            workerThread = new Thread(new ThreadStart(StartWorkerThread));
            client = new Client(ipAddress, port);

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
            connected = client.Connect();
            while (true)
            {
                UpdateData();
                Thread.Sleep(1000/60);
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
