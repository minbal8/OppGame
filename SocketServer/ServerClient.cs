using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class ServerClient
    {
        public int id { get; set; }
        public Socket handler { get; set; }
        public SyncObject syncObject { get; set; }

        public bool Listen()
        {
            try
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
                updateData(data);
                Send(JsonConvert.SerializeObject(syncObject));

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void updateData(string data)
        {
            lock (syncObject)
            {
                data = data.Replace("<EOF>", "");
                var temp = JsonConvert.DeserializeObject<SyncObject>(data);

                if (syncObject.valves == null)
                    syncObject.valves = temp.valves;

                if (id == 0)
                {
                    syncObject.Player1 = temp.Player1;
                    syncObject.ClientID = 1;
                    if (temp.valves != null)
                        UpdateValves(1, temp);
                }
                if (id == 1)
                {
                    syncObject.Player2 = temp.Player2;
                    syncObject.ClientID = 2;
                    if (temp.valves != null)
                        UpdateValves(2, temp);
                }
            }
        }

        private void UpdateValves(int id, SyncObject temp)
        {
            for (int i = 0; i < temp.valves.Count; i++)
            {
                if (temp.valves[i].PlayerID == id)
                {
                    syncObject.valves[i].State = temp.valves[i].State;
                }
            }
        }

        public void Send(string message)
        {
            if (handler != null)
            {
                byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");
                int bytesSent = handler.Send(msg);
            }
        }

    }
}
