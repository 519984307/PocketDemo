using HslCommunication;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ServoManualForm2 : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;
        public ServoManualForm2()
        {
            InitializeComponent();
        }

        private void ServoManualForm2_Load(object sender, EventArgs e)
        {
            PlcCommon.readVar = false;
            this.ActiveControl = labjiaodian;
            ReadPara();

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
            if (PlcCommon.readVar == true)
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

        public void ReadPara()
        {
            try
            {
                #region "送袋伺服"

                //short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
                //int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

                ////故障指示 314:X3
                ////short rtn_gzzh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array314[3] == 0)
                //{
                //    this.rtn_gzzh.Checked = true;
                //}
                //else
                //{
                //    this.rtn_gzzh.Checked = false;
                //}

                ////转盘伺服复位 314:X2
                ////short btn_zpfw = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[2] == 0)
                //{
                //    this.btn_zpfw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpfw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpfw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpfw.ForeColor = System.Drawing.Color.White;
                //}

                ////转盘伺服寻零 314:X4
                ////short btn_zpxl = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[4] == 0)
                //{
                //    this.btn_zpxl.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpxl.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpxl.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpxl.ForeColor = System.Drawing.Color.White;
                //}

                ////转盘伺服转向平台 314:X1
                ////short btn_zpzxpt = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[1] == 0)
                //{
                //    this.btn_zpzxpt.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpzxpt.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpzxpt.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpzxpt.ForeColor = System.Drawing.Color.White;
                //}

                ////转盘伺服转向储袋 314:X0
                ////short btn_zpzxcd = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[0] == 0)
                //{
                //    this.btn_zpzxcd.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpzxcd.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpzxcd.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpzxcd.ForeColor = System.Drawing.Color.White;
                //}

                ////转盘伺服待命位 314:X6
                ////short btn_zpdmw = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[6] == 0)
                //{
                //    this.btn_zpdmw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpdmw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpdmw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpdmw.ForeColor = System.Drawing.Color.White;
                //}

                ////转盘伺服到达位 314:X7
                ////short btn_zpddw = PlcCommon.busTcpClient1.ReadInt16("").Content;

                //if (array314[7] == 0)
                //{
                //    this.btn_zpddw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_zpddw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_zpddw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_zpddw.ForeColor = System.Drawing.Color.White;
                //}

                //转盘伺服当前位置   326
                short zpdqwz = PlcCommon.busTcpClient1.ReadInt16("326").Content;
                tbx_zpdqwz.Text = (zpdqwz + "").ToString();

                //零点偏移 325
                short ldpy = PlcCommon.busTcpClient1.ReadInt16("325").Content;
                tbx_ldpy.Text = (ldpy + "").ToString();

                //转盘伺服速度1  318
                short zpsd1 = PlcCommon.busTcpClient1.ReadInt16("318").Content;
                tbx_zpsd1.Text = (zpsd1).ToString();

                //转盘伺服待命位 336
                short zpdmw = PlcCommon.busTcpClient1.ReadInt16("336").Content;
                tbx_zpdmw.Text = (zpdmw + "").ToString();

                //转盘伺服速度2 320
                short zpsd2 = PlcCommon.busTcpClient1.ReadInt16("320").Content;
                tbx_zpsd2.Text = (zpsd2).ToString();

                //转盘伺服到达位 338
                short zpddw = PlcCommon.busTcpClient1.ReadInt16("338").Content;
                tbx_zpddw.Text = (zpddw + "").ToString();

                #endregion "送袋伺服"

                #region "升降伺服"

                short addressBit388 = PlcCommon.busTcpClient1.ReadInt16("388").Content;
                int[] array388 = ToBinary.IntToBinaryDESC(addressBit388);

                //升降原点 388:X0
                //short rtn_sjyd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[0] == 0)
                {
                    this.rtn_sjyd.Checked = true;
                }
                else
                {
                    this.rtn_sjyd.Checked = false;
                }

                //升降上限位 388:X1
                //short rtn_sjsx = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[1] == 0)
                {
                    this.rtn_sjsx.Checked = true;
                }
                else
                {
                    this.rtn_sjsx.Checked = false;
                }
                //升降下限位 388:X2
                //short rtn_sjxx = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[2] == 0)
                {
                    this.rtn_sjxx.Checked = true;
                }
                else
                {
                    this.rtn_sjxx.Checked = false;
                }
                //送袋负限位 388:X4
                //short rtn_sdfx = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[4] == 0)
                {
                    this.rtn_sdfx.Checked = true;
                }
                else
                {
                    this.rtn_sdfx.Checked = false;
                }
                //转袋原点 388:X5
                //short rtn_zdyd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[5] == 0)
                {
                    this.rtn_zdyd.Checked = true;
                }
                else
                {
                    this.rtn_zdyd.Checked = false;
                }
                //转袋正限位 388:X6
                //short rtn_zdzx = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[6] == 0)
                {
                    this.rtn_zdzx.Checked = true;
                }
                else
                {
                    this.rtn_zdzx.Checked = false;
                }
                //转袋负限位 388:X7
                //short rtn_zdfx = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array388[7] == 0)
                {
                    this.rtn_zdfx.Checked = true;
                }
                else
                {
                    this.rtn_zdfx.Checked = false;
                }

                #endregion "升降伺服"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "点击事件"

        /// <summary>
        /// 转盘伺服复位 314:X2
        /// </summary>
        private void btn_zpfw_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpfw.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[2] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpfw.BackColor = System.Drawing.Color.Lime;
            //            btn_zpfw.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[2] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpfw.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpfw.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服复位操作失败：" + ex.Message);
            //}
        }

        /// <summary>
        /// 转盘伺服寻零 314:X4
        /// </summary>
        private void btn_zpxl_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpxl.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[4] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpxl.BackColor = System.Drawing.Color.Lime;
            //            btn_zpxl.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[4] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpxl.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpxl.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服寻零操作失败：" + ex.Message);
            //}
        }

        /// <summary>
        /// 转盘伺服转向平台 314:X1
        /// </summary>
        private void btn_zpzxpt_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpzxpt.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[1] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向平台按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpzxpt.BackColor = System.Drawing.Color.Lime;
            //            btn_zpzxpt.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[1] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向平台按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpzxpt.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpzxpt.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向平台操作失败：" + ex.Message);
            //}
        }

        /// <summary>
        /// 转盘伺服转向储袋 314:X0
        /// </summary>
        private void btn_zpzxcd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpzxcd.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[0] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向储袋按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpzxcd.BackColor = System.Drawing.Color.Lime;
            //            btn_zpzxcd.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[0] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向储袋按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpzxcd.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpzxcd.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向储袋操作失败：" + ex.Message);
            //}
        }

        /// <summary>
        /// 转盘伺服待命位 314:X6
        /// </summary>
        private void btn_zpdmw_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpdmw.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[6] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpdmw.BackColor = System.Drawing.Color.Lime;
            //            btn_zpdmw.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[6] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpdmw.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpdmw.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位操作失败：" + ex.Message);
            //}
        }

        /// <summary>
        /// 转盘伺服到达位 314:X7
        /// </summary>
        private void btn_zpddw_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    short addressBit314 = PlcCommon.busTcpClient1.ReadInt16("314").Content;
            //    int[] array314 = ToBinary.IntToBinaryDESC(addressBit314);

            //    if (btn_zpddw.BackColor == System.Drawing.Color.DarkGray)
            //    {
            //        array314[7] = 1;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpddw.BackColor = System.Drawing.Color.Lime;
            //            btn_zpddw.ForeColor = System.Drawing.Color.White;
            //        }
            //    }
            //    else
            //    {
            //        array314[7] = 0;
            //        Array.Reverse(array314);
            //        StringBuilder builder = new StringBuilder(addressBit314);
            //        foreach (var item in array314)
            //        {
            //            builder.Append(item);
            //        }
            //        OperateResult operate = PlcCommon.busTcpClient1.Write("314", Convert.ToUInt16(builder.ToString(), 2));
            //        if (!operate.IsSuccess)
            //        {
            //            Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
            //            return;
            //        }
            //        else
            //        {
            //            btn_zpddw.BackColor = System.Drawing.Color.DarkGray;
            //            btn_zpddw.ForeColor = System.Drawing.Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位操作失败：" + ex.Message);
            //}
        }

        #endregion "点击事件"

        #region "页面跳转 "

        private void Btn_ManualForm_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ManualForm manual = new ManualForm();
            this.Hide();
            manual.ShowDialog();
            this.Dispose();
        }

        private void Btn_ServoManualForm1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ServoManualForm2 servo2 = new ServoManualForm2();
            this.Hide();
            servo2.ShowDialog();
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

        #region "回车事件"

        /// <summary>
        /// 选中时停止刷新
        /// </summary>
        private void Tbx_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PlcCommon.readVar = false;
            }
        }

        /// <summary>
        /// 零点偏移 325
        /// </summary>
        private void tbx_ldpy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("325", short.Parse(tbx_ldpy.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "零点偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 转盘伺服速度1  318
        /// </summary>
        private void tbx_zpsd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("318", short.Parse(tbx_zpsd1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服速度1修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 转盘伺服待命位 336
        /// </summary>
        private void tbx_zpdmw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("336", short.Parse(tbx_zpdmw.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 转盘伺服速度2 320
        /// </summary>
        private void tbx_zpsd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("320", short.Parse(tbx_zpsd2.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服速度2修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 转盘伺服到达位 338
        /// </summary>
        private void tbx_zpddw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("338", short.Parse(tbx_zpddw.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "回车事件"

        #region "点击事件"

        /// <summary>
        /// 转盘伺服复位 314:X2
        /// </summary>
        private void btn_zpfw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 2, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpfw.BackColor = System.Drawing.Color.Lime;
                btn_zpfw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服复位 314:X2
        /// </summary>
        private void btn_zpfw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 2, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpfw.BackColor = System.Drawing.Color.DarkGray;
                btn_zpfw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 转盘伺服寻零 314:X4
        /// </summary>
        private void btn_zpxl_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 4, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpxl.BackColor = System.Drawing.Color.Lime;
                btn_zpxl.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服寻零 314:X4
        /// </summary>
        private void btn_zpxl_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 4, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpxl.BackColor = System.Drawing.Color.DarkGray;
                btn_zpxl.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 转盘伺服转向平台 314:X1
        /// </summary>
        private void btn_zpzxpt_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 1, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向平台按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpzxpt.BackColor = System.Drawing.Color.Lime;
                btn_zpzxpt.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服转向平台 314:X1
        /// </summary>
        private void btn_zpzxpt_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 1, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向平台按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpzxpt.BackColor = System.Drawing.Color.DarkGray;
                btn_zpzxpt.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 转盘伺服转向储袋 314:X0
        /// </summary>
        private void btn_zpzxcd_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 0, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向储袋按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpzxcd.BackColor = System.Drawing.Color.Lime;
                btn_zpzxcd.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服转向储袋 314:X0
        /// </summary>
        private void btn_zpzxcd_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 0, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服转向储袋按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpzxcd.BackColor = System.Drawing.Color.DarkGray;
                btn_zpzxcd.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 转盘伺服待命位 314:X6
        /// </summary>
        private void btn_zpdmw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 6, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpdmw.BackColor = System.Drawing.Color.Lime;
                btn_zpdmw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服待命位 314:X6
        /// </summary>
        private void btn_zpdmw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 6, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpdmw.BackColor = System.Drawing.Color.DarkGray;
                btn_zpdmw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 转盘伺服到达位 314:X7
        /// </summary>
        private void btn_zpddw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 7, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpddw.BackColor = System.Drawing.Color.Lime;
                btn_zpddw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 转盘伺服到达位 314:X7
        /// </summary>
        private void btn_zpddw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("314", ToBinary.AddressBitToBinary("314", 7, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual2(伺服手动2界面)" + "\r\n" + "转盘伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_zpddw.BackColor = System.Drawing.Color.DarkGray;
                btn_zpddw.ForeColor = System.Drawing.Color.Black;
            }
        }

        #endregion "点击事件"

        private void ServoManualForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }
    }
}