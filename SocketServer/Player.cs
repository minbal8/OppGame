﻿using System.Reflection;
using System.Text;

namespace SocketServer
{
    public class Player
    {
        public int Id { get; set; }
        public bool isConnected { get; set; }
        public int PosX { get; set; }

        public int PosY { get; set; }

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
