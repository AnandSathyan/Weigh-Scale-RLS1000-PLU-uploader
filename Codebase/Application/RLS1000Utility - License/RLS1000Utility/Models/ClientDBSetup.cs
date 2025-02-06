using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class ClientDBSetup
    {

        public int ID { get; }
        public int ConnectionTypeID { get; }
        public int ConnectionParameterID { get; }
        public int DBObjectID { get; }
        public int DBObjectColumnMapID { get; }
        public int ConnectionType { get; }
        public string ConnString { get; }
        public string DBObjectName { get; }
        public string LFCodeColumn { get; }
        public string BarcodeColumn { get; }
        public string PLUNameColumn { get; }
        public string UnitPriceColumn { get; }

        public ClientDBSetup(
            int _ID, 
            int _ConnectionTypeID,
            int _ConnectionParameterID,
            int _DBObjectID,
            int _DBObjectColumnMapID,
            int _ConnectionType,
            string _ConnString,
            string _DBObjectName,
            string _LFCodeColumn,
            string _BarcodeColumn,
            string _PLUNameColumn,
            string _UnitPriceColumn
            )
        {
            ID = _ID;
            ConnectionTypeID = _ConnectionTypeID;
            ConnectionParameterID = _ConnectionParameterID;
            DBObjectID = _DBObjectID;
            DBObjectColumnMapID = _DBObjectColumnMapID;
            ConnectionType = _ConnectionType;
            ConnString = _ConnString;
            DBObjectName = _DBObjectName;
            LFCodeColumn = _LFCodeColumn;
            BarcodeColumn = _BarcodeColumn;
            PLUNameColumn = _PLUNameColumn;
            UnitPriceColumn = _UnitPriceColumn;
        }
        public ClientDBSetup()
        {
            ID = 0;
            ConnectionTypeID = 0;
            ConnectionParameterID = 0;
            DBObjectID = 0;
            DBObjectColumnMapID = 0;
            ConnectionType = 0;
            ConnString = "";
            DBObjectName = "";
            LFCodeColumn = "";
            BarcodeColumn = "";
            PLUNameColumn = "";
            UnitPriceColumn = "";
        }
    }
}
