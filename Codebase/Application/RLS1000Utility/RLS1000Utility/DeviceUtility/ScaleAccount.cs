using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DeviceUtility
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ScaleAccount
    {
        public int UserID;  //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 37)]
        public string Name; //37
        public int LFCode;
        public Double UnitPrice;
        public int WeightUnit;
        public Double TotalPrice;
        public Double Weight;
        public DateTime SaleTime;
        public int Rebate;
        public DateTime OnlineTime;
        public int Quantity;

    }
}
