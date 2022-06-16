using HslCommunication;
using HslCommunication.ModBus;

namespace PocketDemo1
{
    //Plc公共方法
    public class PlcCommon
    {
        /// <summary>
        /// 判断对否打开PLC
        /// </summary>
        public static  bool variable = false;

        public static bool readVar =false ;

        /// <summary>
        /// PLCIP地址
        /// </summary>
        public static string PLCIP = "192.168.10.210";

        /// <summary>
        /// PLC端口号
        /// </summary>
        public static int PLCPort = 502;

        /// <summary>
        /// Plc连接
        /// </summary>
        public static ModbusTcpNet busTcpClient1 = new ModbusTcpNet(PLCIP, PLCPort);

        /// <summary>
        /// Plc通讯
        /// </summary>
        public static bool PlcConnect()
        {
            // busTcpClient1 = new ModbusTcpNet(PLCIP, PLCPort);
            OperateResult result = busTcpClient1.ConnectServer();
            if (!result.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "连接PLC失败,失败代码：" + result.ErrorCode + ",失败原因：" + result.Message);
                return false;
            }
            return true;
        }
    }
}