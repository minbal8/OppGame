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
    public class Syncer
    {

        // Declare our worker thread
        private Thread workerThread = null;

        private static readonly HttpClient client = new HttpClient();
        private static string _url = "https://localhost:44316/api/test/";

        SyncObject item = new SyncObject();

        public void setUrl(string url)
        {
            _url = url;
        }

        public Syncer()
        {
            workerThread = new Thread(new ThreadStart(StartWorkerThread));
        }

        public void Start()
        {
            workerThread.Start();
        }

        public async void Stop()
        {
            workerThread.Abort();


            item.Player1.isConnected = false;
            item.Player2.isConnected = false;


            var myContent = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await client.PostAsync(_url, stringContent);

        }


        public void StartWorkerThread()
        {
            GetClientID();
            while (true)
            {
                UpdateData();
                Thread.Sleep(50);
            }
        }

        private async void UpdateData()
        {
            UpdateSyncObject();

            var myContent = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await client.PostAsync(_url, stringContent);
            GetData();
        }


        private void UpdateSyncObject()
        {
            item.Player1 = GameStateSingleton.getInstance().Player1;
            item.Player2 = GameStateSingleton.getInstance().Player2;
        }



        private async void GetData()
        {
            var result = await client.GetStringAsync(_url);
            var _item = JsonConvert.DeserializeObject<SyncObject>(result);


            GameStateSingleton.getInstance().Player2 = _item.Player2;

            GameStateSingleton.getInstance().Player1 = _item.Player1;


        }

        private async void GetClientID()
        {
            var result = await client.GetStringAsync(_url);
            SyncObject syncObject = JsonConvert.DeserializeObject<SyncObject>(result);

            if (syncObject.Player1.isConnected == false)
            {
                GameStateSingleton.getInstance().ClientID = 1;
                item.ClientID = 1;
            }
            else
            {
                GameStateSingleton.getInstance().ClientID = 2;
                item.ClientID = 2;
            }
        }
    }
}
