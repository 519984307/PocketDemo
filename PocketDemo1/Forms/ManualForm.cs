using HslCommunication;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ManualForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public ManualForm()
        {
            InitializeComponent();
        }

        private void ManualForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = labjiaodian;
            thread = new Thread(new ThreadStart(GetData))
            {
                IsBackground = true
            };
            thread.Start();
        }

        #region "读取方法"

        private void GetData()
        {
            timer = new System.Timers.Timer()
            {
                Interval = 1000,
                Enabled = true,
                AutoReset = true
            };
            timer.Start();
            timer.Elapsed += (o, a) =>
            {
                SetData();
            };
        }

        private void SetData()
        {
            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new SetDataDelegate(ReadPara));
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 读取参数
        /// </summary>
        public void ReadPara()
        {
            try
            {
                #region "工作平台"

                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //后取气缸 108:X2
                //short hqqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array108[2] == 0)
                {
                    this.btn_hqqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_hqqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_hqqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_hqqg.ForeColor = System.Drawing.Color.White;
                }

                //边推气缸 108:X4
                //short btqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array108[4] == 0)
                {
                    this.btn_btqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_btqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_btqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_btqg.ForeColor = System.Drawing.Color.White;
                }

                //后取吸盘 108:X7
                //short hqxp = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array108[7] == 0)
                {
                    this.btn_hqxp.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_hqxp.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_hqxp.BackColor = System.Drawing.Color.Lime;
                    this.btn_hqxp.ForeColor = System.Drawing.Color.White;
                }

                short addressBit161 = PlcCommon.busTcpClient1.ReadInt16("161").Content;
                int[] array161 = ToBinary.IntToBinaryDESC(addressBit161);

                //夹紧气缸 161:X0
                //short jjqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array161[0] == 0)
                {
                    this.btn_jjqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_jjqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_jjqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_jjqg.ForeColor = System.Drawing.Color.White;
                }

                //插袋气缸 161:X1
                // short cdqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array161[1] == 0)
                {
                    this.btn_cdqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_cdqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_cdqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_cdqg.ForeColor = System.Drawing.Color.White;
                }

                //前压气缸 108:X5
                //short qyqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array108[5] == 0)
                {
                    this.btn_qyqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_qyqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_qyqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_qyqg.ForeColor = System.Drawing.Color.White;
                }

                //翻袋吸盘 108:X9
                //short fdxp = PlcCommon.busTcpClient1.ReadInt16("").Content;

                if (array108[9] == 0)
                {
                    this.btn_fdxp.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_fdxp.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_fdxp.BackColor = System.Drawing.Color.Lime;
                    this.btn_fdxp.ForeColor = System.Drawing.Color.White;
                }

                #endregion "工作平台"

                #region "转袋工位"

                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //一级气缸 升 29:X4
                //short qgs1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array29[4] == 0)
                {
                    this.btn_qgs1.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_qgs1.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_qgs1.BackColor = System.Drawing.Color.Lime;
                    this.btn_qgs1.ForeColor = System.Drawing.Color.White;
                }

                //取袋气缸 29:X2
                //short qdqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array29[2] == 0)
                {
                    this.btn_qdqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_qdqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_qdqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_qdqg.ForeColor = System.Drawing.Color.White;
                }

                //二级气缸升/降 29:X10
                //short qgsj2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array29[10] == 0)
                {
                    this.btn_qgsj2.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_qgsj2.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_qgsj2.BackColor = System.Drawing.Color.Lime;
                    this.btn_qgsj2.ForeColor = System.Drawing.Color.White;
                }

                //一级气缸/降 29:X5
                //short qgj1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array29[5] == 0)
                {
                    this.btn_qgj1.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_qgj1.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_qgj1.BackColor = System.Drawing.Color.Lime;
                    this.btn_qgj1.ForeColor = System.Drawing.Color.White;
                }

                //抓手气缸 29:X3
                //short zsqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array29[3] == 0)
                {
                    this.btn_zsqg.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_zsqg.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_zsqg.BackColor = System.Drawing.Color.Lime;
                    this.btn_zsqg.ForeColor = System.Drawing.Color.White;
                }

                #endregion "转袋工位"

                #region "信号灯"

                short addressBit95 = PlcCommon.busTcpClient1.ReadInt16("95").Content;
                int[] array95 = ToBinary.IntToBinaryDESC(addressBit95);

                //一级气缸 升 95:X0
                //short rtn_qgs1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[0] == 0)
                {
                    this.rtn_qgs1.Checked = true;
                }
                else
                {
                    this.rtn_qgs1.Checked = false;
                }

                //取袋气缸1 95:X1
                //short rtn_qdqg1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[1] == 0)
                {
                    this.rtn_qdqg1.Checked = true;
                }
                else
                {
                    this.rtn_qdqg1.Checked = false;
                }

                //取袋气缸2 95:X2
                //short rtn_qdqg2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[2] == 0)
                {
                    this.rtn_qdqg2.Checked = true;
                }
                else
                {
                    this.rtn_qdqg2.Checked = false;
                }

                //二级气缸升/降1 95:X3
                //short rtn_qgsj21 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[3] == 0)
                {
                    this.rtn_qgsj21.Checked = true;
                }
                else
                {
                    this.rtn_qgsj21.Checked = false;
                }

                //二级气缸升/降2 95:X4
                //short rtn_qgsj22 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[4] == 0)
                {
                    this.rtn_qgsj22.Checked = true;
                }
                else
                {
                    this.rtn_qgsj22.Checked = false;
                }

                //一级气缸 降 95:X5
                //short rtn_qgj1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[5] == 0)
                {
                    this.rtn_qgj1.Checked = true;
                }
                else
                {
                    this.rtn_qgj1.Checked = false;
                }

                //抓手气缸1 95:X6
                //short zsqg1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[6] == 0)
                {
                    this.rtn_zsqg1.Checked = true;
                }
                else
                {
                    this.rtn_zsqg1.Checked = false;
                }
                //抓手气缸2 95:X7
                //short zsqg2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array95[7] == 0)
                {
                    this.rtn_zsqg2.Checked = true;
                }
                else
                {
                    this.rtn_zsqg2.Checked = false;
                }

                #endregion "信号灯"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "按钮事件"

        #region "工作平台"

        /// <summary>
        /// 后取气缸
        /// </summary>
        private void btn_hqqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //108:X2
                if (btn_hqqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array108[2] = 1;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));

                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_hqqg.BackColor = System.Drawing.Color.Lime;
                        btn_hqqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array108[2] = 0;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_hqqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_hqqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 边推气缸
        /// </summary>
        private void btn_btqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //108:X4
                if (btn_btqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array108[4] = 1;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "边推气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_btqg.BackColor = System.Drawing.Color.Lime;
                        btn_btqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array108[4] = 0;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "边推气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_btqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_btqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "边推气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 后取吸盘
        /// </summary>
        private void btn_hqxp_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //108:X7
                if (btn_hqxp.BackColor == System.Drawing.Color.DarkGray)
                {
                    array108[7] = 1;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取吸盘按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_hqxp.BackColor = System.Drawing.Color.Lime;
                        btn_hqxp.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array108[7] = 0;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取吸盘按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_hqxp.BackColor = System.Drawing.Color.DarkGray;
                        btn_hqxp.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取吸盘操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 夹紧气缸
        /// </summary>
        private void btn_jjqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit161 = PlcCommon.busTcpClient1.ReadInt16("161").Content;
                int[] array161 = ToBinary.IntToBinaryDESC(addressBit161);

                //161:X0
                if (btn_jjqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array161[0] = 1;
                    Array.Reverse(array161);
                    StringBuilder builder = new StringBuilder(addressBit161);
                    foreach (var item in array161)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "夹紧气缸按钮操作失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_jjqg.BackColor = System.Drawing.Color.Lime;
                        btn_jjqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array161[0] = 0;
                    Array.Reverse(array161);
                    StringBuilder builder = new StringBuilder(addressBit161);
                    foreach (var item in array161)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "夹紧气缸按钮操作失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_jjqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_jjqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "夹紧气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 插袋气缸
        /// </summary>
        private void btn_cdqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit161 = PlcCommon.busTcpClient1.ReadInt16("161").Content;
                int[] array161 = ToBinary.IntToBinaryDESC(addressBit161);

                //161:X1
                if (btn_cdqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array161[1] = 1;
                    Array.Reverse(array161);
                    StringBuilder builder = new StringBuilder(addressBit161);
                    foreach (var item in array161)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "插袋气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_cdqg.BackColor = System.Drawing.Color.Lime;
                        btn_cdqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array161[1] = 0;
                    Array.Reverse(array161);
                    StringBuilder builder = new StringBuilder(addressBit161);
                    foreach (var item in array161)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "插袋气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_cdqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_cdqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "插袋气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 前压气缸
        /// </summary>
        private void btn_qyqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //108:X5
                if (btn_qyqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array108[5] = 1;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "前压气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qyqg.BackColor = System.Drawing.Color.Lime;
                        btn_qyqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array108[5] = 0;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "前压气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qyqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_qyqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "前压气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 翻袋吸盘
        /// </summary>
        private void btn_fdxp_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit108 = PlcCommon.busTcpClient1.ReadInt16("108").Content;
                int[] array108 = ToBinary.IntToBinaryDESC(addressBit108);

                //108:X9
                if (btn_fdxp.BackColor == System.Drawing.Color.DarkGray)
                {
                    btn_fdxp.BackColor = System.Drawing.Color.Lime;
                    btn_fdxp.ForeColor = System.Drawing.Color.White;

                    array108[9] = 1;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "翻袋吸盘按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    }
                }
                else
                {
                    btn_fdxp.BackColor = System.Drawing.Color.DarkGray;
                    btn_fdxp.ForeColor = System.Drawing.Color.Black;
                    array108[9] = 0;
                    Array.Reverse(array108);
                    StringBuilder builder = new StringBuilder(addressBit108);
                    foreach (var item in array108)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("108", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "翻袋吸盘按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "翻袋吸盘操作失败：" + ex.Message);
            }
        }

        #endregion "工作平台"

        #region "转袋工位"

        /// <summary>
        /// 一级气缸升
        /// </summary>
        private void btn_qgs1_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //29:X4
                if (btn_qgs1.BackColor == System.Drawing.Color.DarkGray)
                {
                    array29[4] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "一级气缸升按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgs1.BackColor = System.Drawing.Color.Lime;
                        btn_qgs1.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array29[4] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "一级气缸升写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgs1.BackColor = System.Drawing.Color.DarkGray;
                        btn_qgs1.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "一级气缸升操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 取袋气缸
        /// </summary>
        private void btn_qdqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //29:X2
                if (btn_qdqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array29[2] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "取袋气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qdqg.BackColor = System.Drawing.Color.Lime;
                        btn_qdqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array29[2] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "取袋气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qdqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_qdqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "取袋气缸操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 二级气缸升降
        /// </summary>
        private void btn_qgsj2_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //29:X10
                if (btn_qgsj2.BackColor == System.Drawing.Color.DarkGray)
                {
                    array29[10] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "二级气缸升降按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgsj2.BackColor = System.Drawing.Color.Lime;
                        btn_qgsj2.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array29[10] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "二级气缸升降按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgsj2.BackColor = System.Drawing.Color.DarkGray;
                        btn_qgsj2.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "二级气缸升降操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 一级气缸降
        /// </summary>
        private void btn_qgj1_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //29:X5
                if (btn_qgj1.BackColor == System.Drawing.Color.DarkGray)
                {
                    array29[5] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgj1.BackColor = System.Drawing.Color.Lime;
                        btn_qgj1.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array29[5] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "后取气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_qgj1.BackColor = System.Drawing.Color.DarkGray;
                        btn_qgj1.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "一级气缸降操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 抓手气缸
        /// </summary>
        private void btn_zsqg_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                //29:X3
                if (btn_zsqg.BackColor == System.Drawing.Color.DarkGray)
                {
                    array29[3] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "抓手气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_zsqg.BackColor = System.Drawing.Color.Lime;
                        btn_zsqg.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    array29[3] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "抓手气缸按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_zsqg.BackColor = System.Drawing.Color.DarkGray;
                        btn_zsqg.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "抓手气缸操作失败：" + ex.Message);
            }
        }

        #endregion "转袋工位"

        #endregion "按钮事件"

        #region "页面跳转 "

        private void Btn_ServoManualForm1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ServoManualForm1 servo = new ServoManualForm1();
            this.Hide();
            servo.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 主页页面
        /// </summary>
        private void Btn_HomePage_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 手动页面
        /// </summary>
        private void Btn_Manual_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ManualForm manualForm = new ManualForm();
            this.Hide();
            manualForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 自动页面
        /// </summary>
        private void Btn_AutoMatic_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            AutoMaticForm autoMaticForm = new AutoMaticForm();
            this.Hide();
            autoMaticForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 参数页面
        /// </summary>
        private void Btn_ParaMeter_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ParaMeterForm1 paraMeterForm1 = new ParaMeterForm1();
            this.Hide();
            paraMeterForm1.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 报警页面
        /// </summary>
        private void Btn_Warning_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            WarningForm1 warningForm1 = new WarningForm1();
            this.Hide();
            warningForm1.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 诊断页面
        /// </summary>
        private void Btn_Diagnosis_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            DiagnosisForm diagnosisForm = new DiagnosisForm();
            this.Hide();
            diagnosisForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 权限页面
        /// </summary>
        private void Btn_Administration_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            AdministrationForm administration = new AdministrationForm();
            this.Hide();
            administration.ShowDialog();
            this.Dispose();
        }

        #endregion "页面跳转 "

        private void ManualForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}