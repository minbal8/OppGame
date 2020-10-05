using System.Reflection;
using System.Text;

namespace SocketServer
{
    public class SyncObject
    {
        public int ClientID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }


        public SyncObject()
        {
            Player1 = new Player();
            Player2 = new Player();


        }

        private PropertyInfo[] _PropertyInfos = null;


        public override string ToString()
        {
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }
}
