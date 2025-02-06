using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppDBObject
    {
        public int ID { get; }
        public string DBObjectName { get; }
        public string DBObjectType { get; }

        public AppDBObject(int _ID,string _DBObjectName,string _DBObjectType)
        {
            ID = _ID;
            DBObjectName = _DBObjectName;
            DBObjectType = _DBObjectType;
        }

        public AppDBObject()
        {
            ID = 0;
            DBObjectName = "";
            DBObjectType = "";
        }
    }
}
