using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppDBObjectColumnMap
    {
        public int ID { get; }
        public int DBObjectID { get; }
        public string LFCodeColumn { get; }
        public string BarcodeColumn { get; }
        public string PLUNameColumn { get; }
        public string UnitPriceColumn { get; }

        public AppDBObjectColumnMap(int _ID, 
            int _DBObjectID, 
            string _LFCodeColumn, 
            string _BarcodeColumn, 
            string _PLUNameColumn, 
            string _UnitPriceColumn)
        {
            ID = _ID;
            DBObjectID = _DBObjectID;
            LFCodeColumn = _LFCodeColumn;
            BarcodeColumn = _BarcodeColumn;
            PLUNameColumn = _PLUNameColumn;
            UnitPriceColumn = _UnitPriceColumn;
        }

        public AppDBObjectColumnMap()
        {
            ID = 0;
            DBObjectID = 0;
            LFCodeColumn = "";
            BarcodeColumn = "";
            PLUNameColumn = "";
            UnitPriceColumn = "";
        }
    }
}
