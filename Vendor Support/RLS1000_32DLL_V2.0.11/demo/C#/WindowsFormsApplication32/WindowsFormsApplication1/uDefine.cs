using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Windows;

namespace uDefine
 {
   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)] //delphi 固定用的是1
  public struct PLU
    {
        // [MarshalAsAttribute(UnmanagedType.LPStr, SizeConst = 36)]
       public string PluName; 	//品名 Name, 36 characters
       public int LFCode;	//生鲜码 fresh code, 1-999999, uniquely identifies each fresh product
        public string Code;	//货号 goods no, 10 digits
        public int BarCode;	//条码类型,0-99    //barcode type, 0-99
        public int UnitPrice;	//单价,无小数模式,0-9999999 //unit price, no decimal mode, 0-9999999
        public int WeightUnit;	//称重单位/Weighing Units 0-12  (0: 50g, 1: g, 2: 10g, 3: 100g, 4: Kg, 5: oz, 6: Lb, 7: 500g, 8: 600g, 9 : PCS (g), 10: PCS (Kg), 11: PCS (oz), 12: PCS (Lb))
        public int Deptment;	//部门,2位数字,用来组成条码 // Department, two digits
        public double Tare;	//皮重,逻辑换算后应在15Kg内 // Tare, logical conversion should be within 15Kg
        public int ShlefTime;	//保存期,0-365 // Shelf life, 0-365
        public int PackageType;	// //包装类型 0:正常 1:定重 2：定价 3:定重定价 4:二维码 //Package Type 0: Normal 1: Fixed Weight 2: Pricing 3: Fixed Price 4: QR Code
        public double PackageWeight;	//包装重量/限重重量,逻辑换算后应在15Kg内 // Package weight, logical conversion should be within 15Kg
        public int Tolerance;	//包装误差,0-20 Packaging error, 0-20 
        public int Message1;	//信息1,0-10000 Message 1,
        public byte Reserved;	//保留 // Reserved
        public Int16 Reserved1;	//保留 //Reserved
        public byte Message2;	//信息2,0-255 // Message 2, 0- 197
        public byte Reserved2;	//保留 //Reserved
        public byte MultiLabel;	// 标签类型 Label type 1,2,4,8,16,32,64,128,,3,12 correspond to the label types of the label editor RTLabel.exe (A0, A1, B0, B1, C0, C1, D0, D1, E0, E1)
        public byte Rebate;   //折扣,0-99  //discounts
        public int Account;	//Reserved
    }
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


    public class Pludata
    {
        public int HotKey { get; set; }
        public string PluName { get; set; }     //品名 Name, 36 characters
        public int LFCode { get; set; }	//生鲜码 fresh code, 1-999999, uniquely identifies each fresh product
        public string Code { get; set; }	//货号 goods no, 10 digits
        public int BarCode { get; set; }	//条码类型,0-99    //barcode type, 0-99
        public int UnitPrice { get; set; }	//单价,无小数模式,0-9999999 //unit price, no decimal mode, 0-9999999
        public int WeightUnit { get; set; }	//称重单位/Weighing Units 0-12  (0: 50g, 1: g, 2: 10g, 3: 100g, 4: Kg, 5: oz, 6: Lb, 7: 500g, 8: 600g, 9 : PCS (g), 10: PCS (Kg), 11: PCS (oz), 12: PCS (Lb))
        public int Deptment { get; set; }	//部门,2位数字,用来组成条码 // Department, two digits
        public double Tare { get; set; }	//皮重,逻辑换算后应在15Kg内 // Tare, logical conversion should be within 15Kg
        public int ShlefTime { get; set; }	//保存期,0-365 // Shelf life, 0-365
        public int PackageType { get; set; }	// //包装类型 0:正常 1:定重 2：定价 3:定重定价 4:二维码 //Package Type 0: Normal 1: Fixed Weight 2: Pricing 3: Fixed Price 4: QR Code
        public double PackageWeight { get; set; }	//包装重量/限重重量,逻辑换算后应在15Kg内 // Package weight, logical conversion should be within 15Kg
        public int Tolerance { get; set; }	//包装误差,0-20 Packaging error, 0-20 
        public int Message1 { get; set; }	//信息1,0-10000 Message 1,
      //  public byte Reserved { get; set; }	//保留 // Reserved
      //  public Int16 Reserved1 { get; set; }	//保留 //Reserved
        public byte Message2 { get; set; }	//信息2,0-255 // Message 2, 0- 197
        public byte Reserved2 { get; set; }	//保留 //Reserved
        public byte LabelId { get; set; }// 标签类型 Label type 1,2,4,8,16,32,64,128,,3,12 correspond to the label types of the label editor RTLabel.exe (A0, A1, B0, B1, C0, C1, D0, D1, E0, E1)
        public byte Rebate { get; set; }   //折扣,0-99  //discounts
        public int Account { get; set; }	//Reserved
        public int QtyUnit { get; set; }  //数量单位
        //public double ice { get; set; }  //含冰量
        //public double VAT { get; set; }  //税率
       // public int DisCountPrice { get; set; } //折扣价
      
    }
 


 }