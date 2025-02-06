using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using uDefine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mainFrm = this;
            obj = new object();
        }
        public static Form1 mainFrm;

        int connid = 0;
        static Object obj;
        private Boolean ConnectScale()
        {
            string IPAddr = txtIp.Text;
            labelScale.rtscaleLoadIniFile(@".\SYSTEM.CFG");

            int iRtn = labelScale.rtscaleConnect(IPAddr, 0, ref connid);
            if (iRtn < 0)
            {
                MessageBox.Show("connect fail");
                return false;
            };
            return true;
        }

        private Boolean DisconnectScale()
        {
            return labelScale.rtscaleDisConnect(connid) == 0;//以太网断开 Ethernet disconnected
                                                             //  rtsdrv.rtscaleDisConnect(22); com断开 com disconnected
        }

        private Boolean SendHotKey()
        {

            //传送热键，要分三次传，1次只传84个 Send hotkey data to the scale, to be divided into three passes, one can only send 84
            int[] HotkeyTable = new int[84];
            for (int i = 0; i < 84; i++)
            {
                HotkeyTable[i] = 10001 + i; //对应LFCode Corresponding LFCode
            }
            if (labelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 0) != 0)
                return false;

            for (int i = 0; i < 84; i++)
            {
                HotkeyTable[i] = 10001 + 84 + i;
            }
            if (labelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 1) != 0)
                return false;

            for (int i = 0; i < 224 - 84 * 2; i++)
            {
                HotkeyTable[i] = 10001 + 84 * 2 + i;
            }
            if (labelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 2) != 0)
                return false;
            return true;

        }





        private void button3_Click(object sender, EventArgs e)
        {
            int iRtn = -1;
            if (!ConnectScale())
                return;

            double dWeight = 0;

            iRtn = labelScale.rtscaleGetPluWeight(connid, ref dWeight);
            if (iRtn < 0)
                MessageBox.Show("Failed to get the weight");
            else
                MessageBox.Show(dWeight.ToString());
            labelScale.rtscaleDisConnect(connid);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ConnectScale())
            {
                if (labelScale.rtscaleClearPLUData(connid) == 0)
                    MessageBox.Show("Empty ok");
                labelScale.rtscaleDisConnect(connid);

            };


        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            string s = "this is a message1";
            int iLongMsg = 0;
            bool isok = true;
            int iret = 0;
            for (int i = 0; i < 5; i++)
            {
                s = "this is a message " + (i + 1).ToString();
                // s = "الأندلس للبرمجياتthis is a Message " + (i + 1).ToString();
                iret = labelScale.rtscaleDownLoadMessage(connid, i, s, s.Length, ref iLongMsg);//下载Message
                if (iret != 0)
                    isok = false;
            }
            DisconnectScale();
            if (isok)
                MessageBox.Show("true");
            else
                MessageBox.Show("false");

        }


        public delegate void Callback([MarshalAs(UnmanagedType.LPStr)] string iRecNO, int iPack, int ACount);
        //sResult: retun the json data, iRecNO:Number of records   ACount:Total number of records
        //
        /**
            Json format:
              {
                "Weight": 2.88,
                "Quantity": 1,
                "WeightUnit": 4,
                "TotalPrice": 2.88,
                "UnitPrice": 12.96,
                "OnlineTime": "20180906094400",
                "LFCode": 2,
                "Rebate": 0,
                "SaleTime": "20180906094500",
                "PluName": "aaaa",
                "UserID": 80257,
                "Clerk": 0
               }
        **/
        public static void scaleAccountCallback(string sResult, int iRecNO, int ACount)
        {
            ScaleAccountData accountData;
            accountData = JsonConvert.DeserializeObject<ScaleAccountData>(sResult);
            string s = string.Format("UserId={0},Name={1},LFCode={2},unitPrice={3},WeightUnit={4},"
                  + "TotalPrice={5},Weight={6},saletime={7},Rebate={8},OnlineTime={9},Quantity={10},Clerk={11}",
                  accountData.UserID, accountData.PluName, accountData.LFCode, accountData.UnitPrice, accountData.WeightUnit,
                  accountData.TotalPrice, accountData.Weight, accountData.SaleTime, accountData.Rebate, accountData.OnlineTime,
                  accountData.Quantity, accountData.Clerk);


            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "salelist.txt";
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(s);
            sw.Close();
        }


        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }

        //sResult: retun the json data, iRecNO:Number of records 当前第几条   ACount: Reserved 预留  一次一条
        public static void uploadPluDataCallback(string sResult, int iRecNO, int ACount)
        {
            //  MessageBox.Show(sResult);
            // System.Diagnostics.Debug.WriteLine(sResult);
            Pludata pluData = JsonConvert.DeserializeObject<Pludata>(sResult);
            String s = string.Format("PluName={0},LFCode={1},Code={2},BarCode={3},Rebate={4},"
                  + "UnitPrice={5},WeightUnit={6},Deptment={7},Tare={8},ShlefTime={9},PackageType={10},PackageWeight={11},"
                  + "Tolerance={12},Message1={13},MultiLabel={14},HotKey={15},iRecNO={16}",
                    pluData.PluName, pluData.LFCode, pluData.Code, pluData.BarCode, pluData.Rebate,
                  pluData.UnitPrice, pluData.WeightUnit, pluData.Deptment, pluData.Tare,
                  pluData.ShlefTime, pluData.PackageType, pluData.PackageWeight, pluData.Tolerance,
                  pluData.Message1, pluData.LabelId, pluData.HotKey, iRecNO
                  );

            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "plulist.csv";
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(s);
            sw.Close();


        }

        //sResult: retun the json data, MsgId:ID corresponding to the information  信息ID   ACount: Reserved 预留
        public static void rtscaleUploadMessage(string sResult, int MsgId, int ACount)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(sResult);
            MessageBox.Show(string.Format("MsgText={0},MsgId={1}", jo["MsgText"].ToString(), MsgId));
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "salelist.txt";
            File.Delete(fileName);

            Callback info = scaleAccountCallback;
            IntPtr p = Marshal.GetFunctionPointerForDelegate(info);
            int iret = labelScale.rtscaleUploadSaleData(connid, false, p);//Ok: return  Total number of records  Fail: return <0 
            labelScale.rtscaleDisConnect(connid);
            if (iret >= 0)
            {
                MessageBox.Show("ok");
                if (File.Exists(fileName))
                    System.Diagnostics.Process.Start(fileName); //直
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "plulist.csv";
            File.Delete(fileName);

            Callback info = uploadPluDataCallback;
            IntPtr p = Marshal.GetFunctionPointerForDelegate(info);
            int iret = labelScale.rtscaleUploadPluData(connid, p);//Ok: return  Total number of records  Fail: return <0 
            labelScale.rtscaleDisConnect(connid);
            if (iret >= 0)
            {
                MessageBox.Show("ok");
                System.Diagnostics.Process.Start(fileName); //直
            }
            else
            {
                MessageBox.Show("Fail");
            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            Callback info = rtscaleUploadMessage;
            IntPtr p = Marshal.GetFunctionPointerForDelegate(info);

            int iRtn = labelScale.rtscaleUploadMessage(connid, p);//Ok: return  Total number of records  Fail: return <0
            MessageBox.Show(String.Format("iRtn={0}", iRtn));
            labelScale.rtscaleDisConnect(connid);
        }
        private Boolean DownloadpluByJson2()
        {
            for (int J = 0; J < 45; J++)
            {
                var obj = new JArray();
                for (int i = 0; i < 4; i++)
                {
                    string s = "الأندلس للبرمجيات" + (J * 4 + i + 1).ToString();
                    //  string s = "pluname" + (J * 4 + i + 1).ToString();
                    int LFCode = J * 4 + i + 1 + 10000;

                    obj.Add(new JObject() {
                                        new JProperty("PluName",s),
                                        new JProperty("LFCode",LFCode),
                                        new JProperty("Code",LFCode.ToString()),
                                        new JProperty("BarCode",40),
                                        new JProperty("UnitPrice",2000),
                                        new JProperty("WeightUnit",4),
                                        new JProperty("Deptment",2),
                                        new JProperty("Tare",0),
                                        new JProperty("ShlefTime",15),
                                        new JProperty("PackageType",5),
                                        new JProperty("PackageWeight",3.2f),
                                        new JProperty("Tolerance",0),
                                        new JProperty("Message1",1),
                                        new JProperty("Message2",0),
                                        new JProperty("MultiLabel",0),
                                        new JProperty("Rebate",0),
                                        new JProperty("Account",0),
                                        new JProperty("QtyUnit",0),

                });

                }

                String stmp = obj.ToString();
                StringBuilder sb = new StringBuilder(stmp);
                if (labelScale.rtscaleDownLoadPLU(connid, stmp, J) != 0)
                {
                    MessageBox.Show("Fail");
                    return false;
                }



            }
            return true;

        }

        private Boolean DownloadpluByJson1()
        {



            for (int J = 0; J < 1; J++)
            {
                var obj = new JArray();
                for (int i = 0; i < 4; i++)
                {
                    //string s = "pluname الأندلس للبرمجيات" + (J * 4 + i + 1).ToString();
                    string s = "pluname" + (J * 4 + i + 1).ToString();
                    int LFCode = J * 4 + i + 1 + 10000;
                    Pludata plu = new Pludata();
                    plu.PluName = s;
                    plu.LFCode = LFCode;
                    plu.Code = LFCode.ToString();
                    plu.BarCode = 40;
                    plu.UnitPrice = 1000;
                    plu.WeightUnit = 4;
                    plu.Deptment = 4;
                    plu.Tare = 0;
                    plu.ShlefTime = 15;
                    plu.PackageType = 5;
                    plu.PackageWeight = 3.2f;
                    plu.Tolerance = 0;
                    plu.Message1 = 1;
                    plu.Message2 = 0;
                    plu.LabelId = 0;
                    plu.Rebate = 0;
                    plu.QtyUnit = 0;
                    string sjson = JsonConvert.SerializeObject(plu);
                    JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                    obj.Add(jo);


                }
                String stmp = obj.ToString();
                //      StringBuilder sb = new StringBuilder(stmp);
                if (labelScale.rtscaleDownLoadPLU(connid, stmp, J) != 0)
                {
                    MessageBox.Show("Fail");
                    return false;
                }

            }
            return true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            if (!DownloadpluByJson1())
                return;


            if (SendHotKey())
            {
                MessageBox.Show("ok");
            }
            else
                MessageBox.Show("Fail");

            DisconnectScale();

        }
        private void btnDownloadHead_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;

            int iret = 0;
            //string s = "الأندلس للبرمجيات this is a head";
            string s = "this is a head";
            iret = labelScale.rtscaleDownLoadAdHead(connid, s, s.Length);//下载Message
            DisconnectScale();
            if (iret == 0)
                MessageBox.Show("ok");
            else
                MessageBox.Show("Fail");
        }

        private void btnDownLoadAdTail_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            string s = "this is a Tail";
            int iret = 0;
            // s= "الأندلس للبرمجيات this is a Tail11" +"\r\n"+ "الأندلس للبرمجيات  this is a Tail2"+"\r\n"+"الأندلس للبرمجيات  this is a Tail3";
            s = "this is a Tail11" + "\r\n" + "this is a Tail2" + "\r\n" + " this is a Tail3";

            iret = labelScale.rtscaleDownLoadAdTail(connid, s, s.Length);//下载Message
            DisconnectScale();
            if (iret == 0)
                MessageBox.Show("ok");
            else
                MessageBox.Show("Fail");

        }




        private void btnUploadAdHead_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            StringBuilder s = new StringBuilder(255);
            int iret = labelScale.rtscaleUploadDataAdHead(connid, s);//Ok: return  Total number of records  Fail: return <0
            if (iret == 0)
            {
                MessageBox.Show(s.ToString());
            }
            else
            {
                MessageBox.Show("true");
            }
            labelScale.rtscaleDisConnect(connid);
        }

        private void btnTail_Click(object sender, EventArgs e)
        {
            if (!ConnectScale())
                return;
            //  string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbb2222222222222222222bbb";
            StringBuilder s = new StringBuilder(255);
            int iret = labelScale.rtscaleUploadDataAdTail(connid, s);//Ok: return  Total number of records  Fail: return <0
            if (iret == 0)
            {
                MessageBox.Show(s.ToString());
            }
            else
            {
                MessageBox.Show("true");
            }
            labelScale.rtscaleDisConnect(connid);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ConnectScale())
                MessageBox.Show("connect ok");

        }

        public delegate void WeightCallback(double AWeight, int lfcode);
        //sResult: retun the json data, iRecNO:Number of records 当前第几条   ACount: Reserved 预留  一次一条
        public static void getWeightCallback(double AWeight, int lfcode)
        {
            Form1.mainFrm.Invoke(new Action(() =>
            {
                Form1.mainFrm.listBox1.Items.Add(String.Format("weight={0:F3},lfcode={1:D0}", AWeight, lfcode));
            }));
        }

        private void btnGetWeight_Click(object sender, EventArgs e)
        {
            //  double AWeight = 12.22; int lfcode = 45;

            ////  Form1.mainFrm.listBox1.Items.Add(String.Format("weight={0:F3},lfcode={1:D3}", AWeight, lfcode));
            listBox1.Items.Clear();
            WeightCallback info = getWeightCallback;
            IntPtr p = Marshal.GetFunctionPointerForDelegate(info);
            labelScale.rtscaleStartGetWeightbyNet(p);//Ok: return  Total number of records  Fail: return <0 


        }

        private void btnStopGetWev_Click(object sender, EventArgs e)
        {
            labelScale.rtscaleStopGetWeightbyNet();
        }
    }
}