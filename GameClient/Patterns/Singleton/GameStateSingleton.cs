using System.Reflection;
using System.Text;

namespace GameClient
{
    class GameStateSingleton
    {
        private static GameStateSingleton instance = new GameStateSingleton();
        private static readonly object padlock = new object();

        public int ClientID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public int LevelID { get; set; }

        GameStateSingleton()
        {
            Player1 = new Player();
            Player2 = new Player();

        }

        public static GameStateSingleton getInstance()
        {
            lock (padlock)
            {
                return instance;
            }
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
