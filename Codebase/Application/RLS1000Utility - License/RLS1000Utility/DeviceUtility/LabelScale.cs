using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RLS1000Utility.DeviceUtility
{
    class LabelScale
    {
        /// <summary>
        /// connect scale 
        /// </summary>
        /// <param name="Addr">ip addr or com  192.168.1.87  or COM1 </param>
        /// <param name="BaudRate">When it is ip, baund=0, otherwise it is the baud rate 9600,115200 </param>
        /// <param name="connid">Connection id, After the return value, other functions are passed in with this value
        ///                  返回值后，其他函数都用该值传入
        /// </param>
        /// <returns></returns>
        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleConnect")]
        public static extern int rtscaleConnect(String Addr, int BaudRate, ref int connid);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "rtscaleDisConnect")]
        public static extern int rtscaleDisConnect(int connid);
        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleLoadIniFile")]
        public static extern int rtscaleLoadIniFile(String cfgFileName);

        /// <summary>
        /// 清除全部PLU 
        /// Clear all PLUs
        /// </summary>
        /// <returns>0：成功 ，-1：失败
        /// 0: successful, -1: failed
        /// </returns>
        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int rtscaleClearPLUData(int connid);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleDownLoadPLU")]
        public static extern int rtscaleDownLoadPLU(int connid, String PluJson, int ipack);//下载PLU

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleDownLoadHotkey")]
        public static extern int rtscaleDownLoadHotkey(int connid, int[] HotkeyTable, int TableIndex);//下载热键


        /// <summary>
        ///  下发Message, 用于打印标签时，可以把单品的附加信息，如产地信息打印出来
        /// </summary>
        /// <param name="connid">连接id MsgId</param>
        /// <param name="MsgId">信息id:0~10000 </param>
        /// <param name="PMessage">信息正文</param>
        /// <param name="Datalen">信息正文长度 最多246</param>
        /// <param name="iLongMsg">返回当前第n条长消息，下次再调用此函数时，要代入此值。该值是累加的，直到所有消息发送结束。
        ///     在同一个Message 的包数计算方式为前面250 byte为1包，后面的字符256byte为1包。一个长消息的包数至少为2包。
        ///     例如字符长度为400byte的，iLongMsg=iLongMsg+2;</param>
        /// <returns></returns>
        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleDownLoadMessage")]
        public static extern int rtscaleDownLoadMessage(int connid, int MsgId, String PMessage, int Datalen, ref int iLongMsg);//下载Message


        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall)]//, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadPluData")]
        public static extern int rtscaleUploadPluData(int connid, IntPtr p);///上传PLU数据

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadSaleData")]
        public static extern int rtscaleUploadSaleData(int connid, bool AIsClearData, IntPtr p);///上传销售数据

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleStartGetWeightbyNet")]
        public static extern bool rtscaleStartGetWeightbyNet(IntPtr p);///启动获取重量

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "rtscaleStopGetWeightbyNet")]
        public static extern bool rtscaleStopGetWeightbyNet();//停止获取重量



        /// <summary>
        /// 获取当前得重量 Get the current weight
        /// </summary>
        /// <param name="dWeight">重量 weight</param>
        /// <returns>0：成功 ，-1：失败 
        /// 0: successful, -1: failed
        /// </returns>
        [DllImport("rtslabelscale.dll")]
        public static extern int rtscaleGetPluWeight(int Connid, ref Double dWeight);

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadMessage")]
        public static extern int rtscaleUploadMessage(int connid, IntPtr p);///上传Message


        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleDownLoadAdHead")]
        public static extern int rtscaleDownLoadAdHead(int connid, String AdInfotxt, int len);///下载广告标语的头部信息

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleDownLoadAdTail")]
        public static extern int rtscaleDownLoadAdTail(int connid, String AdInfotxt, int len);///下载广告标语的尾部信息


        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadDataAdHead")]
        public static extern int rtscaleUploadDataAdHead(int connid, StringBuilder Retdata);///上传头部数据

        [DllImport("rtslabelscale.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "rtscaleUploadDataAdTail")]
        public static extern int rtscaleUploadDataAdTail(int connid, StringBuilder Retdata);///上传尾部数据

    }
}
