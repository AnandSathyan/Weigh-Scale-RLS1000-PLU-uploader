using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DeviceUtility
{
    public class ScaleAccountData
    {
        public int UserID { get; set; }
        public string PluName { get; set; }
        public int LFCode { get; set; }
        public Double UnitPrice { get; set; }
        public int WeightUnit { get; set; }
        public Double TotalPrice { get; set; }
        public Double Weight { get; set; }
        public string SaleTime { get; set; }
        public int Rebate { get; set; }
        public string OnlineTime { get; set; }
        public int Quantity { get; set; }
        public int Clerk { get; set; }
        public Double PackWeight { get; set; }
        public Double ErrorWeight { get; set; }//误差s
        public int SerialNum { get; set; }//Venezuela for Bill number
        public int GstRounding { get; set; }//四舍五入
        public int DeptId { get; set; }///部门ID
        public Double SGSTMoney { get; set; }//SGST 税率金额
        public Double CGSTMoney { get; set; }//CGST 税率金额
    }
}
