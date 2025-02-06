using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class PLUDataDB
    {
        public int HotKey { get; set; }
        public string PluName { get; set; }
        public int LFCode { get; set; }	
        public string Code { get; set; }
        public int BarCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int WeightUnit { get; set; }
        public int Deptment { get; set; }	
        public double Tare { get; set; }	
        public int ShlefTime { get; set; }	
        public int PackageType { get; set; }
        public double PackageWeight { get; set; }
        public int Tolerance { get; set; }	
        public int Message1 { get; set; }   
        public byte Message2 { get; set; }	
        public byte Reserved2 { get; set; }	
        public byte LabelId { get; set; }
        public byte Rebate { get; set; } 
        public int Account { get; set; }
        public int QtyUnit { get; set; }
    }
}
