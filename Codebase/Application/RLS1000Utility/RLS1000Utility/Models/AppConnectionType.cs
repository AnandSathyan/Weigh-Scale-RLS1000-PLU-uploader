using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppConnectionType
    {
        public int ID { get; }
        public string ConnectionName { get; }
        public int ConnectionType { get; }

        public AppConnectionType(int _ID,string _ConnectionName,int _ConnectionType)
        {
            ID = _ID;
            ConnectionName = _ConnectionName;
            ConnectionType = _ConnectionType;
        }

        public AppConnectionType()
        {
            ID = 0;
            ConnectionName = "";
            ConnectionType = 0;
        }
    }
}
