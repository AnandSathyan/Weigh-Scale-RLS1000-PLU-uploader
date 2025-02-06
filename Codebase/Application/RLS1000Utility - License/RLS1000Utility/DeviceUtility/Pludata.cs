using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DeviceUtility
{
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
        public int Message1 { get; set; }   //信息1,0-10000 Message 1,
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
