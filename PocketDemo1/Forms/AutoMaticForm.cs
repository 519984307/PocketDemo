using HslCommunication;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class AutoMaticForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;
        public AutoMaticForm()
        {
            InitializeComponent();
        }

        private void AutoMaticForm_Load(object sender, EventArgs e)
        {
            PlcCommon.readVar = true;  
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
                #region "只读信号灯"

                //故障  2:X0
                short AddressBit2 = PlcCommon.busTcpClient1.ReadInt16("2").Content;
                int[] array2 = ToBinary.IntToBinaryDESC(AddressBit2);
                int guzhang = array2[0];

                if (guzhang == 0)
                {
                    this.rtn_gz.Checked = true;
                }
                else
                {
                    this.rtn_gz.Checked = false;
                }

                //设备回原点完成 22:X3
                short AddressBit22 = PlcCommon.busTcpClient1.ReadInt16("22").Content;
                int[] array22 = ToBinary.IntToBinaryDESC(AddressBit22);

                int sbhyd = array22[3];
                if (sbhyd == 0)
                {
                    this.rtn_sbhyd.Checked = true;
                }
                else
                {
                    this.rtn_sbhyd.Checked = false;
                }

                //包机编码器寻零状态 22:X0
                //short bjbmq = PlcCommon.busTcpClient1.ReadInt16("").Content;
                int bjbmq = array22[0];

                if (bjbmq == 0)
                {
                    this.rtn_bjbmq.Checked = true;
                }
                else
                {
                    this.rtn_bjbmq.Checked = false;
                }

                //送袋伺服寻零状态 22:X4
                //short sdxl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                int sdxl = array22[4];
                if (sdxl == 0)
                {
                    this.rtn_sdxl.Checked = true;
                }
                else
                {
                    this.rtn_sdxl.Checked = false;
                }

                //升降伺服寻零状态 22:X6
                // short sjxl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                int sjxl = array22[6];
                if (sjxl == 0)
                {
                    this.rtn_sjxl.Checked = true;
                }
                else
                {
                    this.rtn_sjxl.Checked = false;
                }

                //袋装伺服寻零状态 22:X5
                // short zdxl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                int zdxl = array22[5];
                if (zdxl == 0)
                {
                    this.rtn_zdxl.Checked = true;
                }
                else
                {
                    this.rtn_zdxl.Checked = false;
                }

                #endregion "只读信号灯"

                #region "参数"

                //真空检测 29:X8
                short AddressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] arryay29 = ToBinary.IntToBinaryDESC(AddressBit29);

                if (arryay29[8] == 0)
                {
                    this.btn_zkjck.BackColor = System.Drawing.Color.Lime;
                    this.btn_zkjck.ForeColor = System.Drawing.Color.Black;
                    this.btn_zkjck.Text = "真空检测开";
                }
                else
                {
                    this.btn_zkjck.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_zkjck.ForeColor = System.Drawing.Color.White;
                    this.btn_zkjck.Text = "真空检测关";
                }

                //开启送袋 22:X2
                //  short btn_kqsd = PlcCommon.busTcpClient1.ReadInt16("").Content;

                if (array22[2] == 0)
                {
                    this.btn_kqsd.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_kqsd.ForeColor = System.Drawing.Color.Black;
                    this.btn_kqsd.Text = "开启送袋";
                }
                else
                {
                    this.btn_kqsd.BackColor = System.Drawing.Color.Lime;
                    this.btn_kqsd.ForeColor = System.Drawing.Color.Black;
                    this.btn_kqsd.Text = "关闭送袋";
                }
                //选择纸袋 270:X0
                short addressBit270 = PlcCommon.busTcpClient1.ReadInt16("270").Content;

                int[] arryay270 = ToBinary.IntToBinaryDESC(addressBit270);

                if (arryay270[0] == 0)
                {
                    this.btn_xzzd.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_xzzd.ForeColor = System.Drawing.Color.Black;
                    this.btn_xzzd.Text = "选择纸袋";
                }
                else
                {
                    this.btn_xzzd.BackColor = System.Drawing.Color.Lime;
                    this.btn_xzzd.ForeColor = System.Drawing.Color.Black;
                    this.btn_xzzd.Text = "选择塑编袋";
                }

                //产量设定 354
                short clsd = PlcCommon.busTcpClient1.ReadInt16("354").Content;
                tbx_clsd.Text = (clsd) + "袋".ToString();

                //当前产量 357
                short dqcl = PlcCommon.busTcpClient1.ReadInt16("357").Content;
                tbx_dqcl.Text = (dqcl) + "袋".ToString();

                //插袋总数 392
                short cdzs = PlcCommon.busTcpClient1.ReadInt16("392").Content;
                tbx_cdzs.Text = (cdzs) + "袋".ToString();

                //剩余袋数 371
                short syds = PlcCommon.busTcpClient1.ReadInt16("371").Content;
                tbx_syds.Text = (syds) + "袋".ToString();

                //最后只插 300
                short zhzc = PlcCommon.busTcpClient1.ReadInt16("300").Content;
                tbx_zhzc.Text = (zhzc).ToString();

                //当前工位 18
                short dqgw = PlcCommon.busTcpClient1.ReadInt16("18").Content;
                tbx_dqgw.Text = (dqgw) + "嘴".ToString();

                //主轴位置 19
                short zzwz = PlcCommon.busTcpClient1.ReadInt16("19").Content;
                tbx_zzwz.Text = (zzwz).ToString();

                //摆臂角度    20
                short bbjd = PlcCommon.busTcpClient1.ReadInt16("20").Content;
                tbx_bbjd.Text = (bbjd).ToString();

                //角调整角度 21
                short jtzjd = PlcCommon.busTcpClient1.ReadInt16("21").Content;
                tbx_jtzjd.Text = (jtzjd).ToString();

                //摆臂电流 346
                int bbdl = PlcCommon.busTcpClient1.ReadInt32("346").Content;
                tbx_bbdl.Text = (bbdl + "mA").ToString();

                //储袋点动

                //byte[] cddd=PlcCommon.busTcpClient1.Read("",)

                #endregion "参数"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转事件 "

        /// <summary>
        /// 设备启停记录
        /// </summary>
        private void btn_sbqtjl_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            RecordForm recordForm = new RecordForm();
            this.Hide();
            recordForm.ShowDialog();
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

        #endregion "页面跳转事件 "

        #region "点击事件"

        /// <summary>
        /// 当前产量清零
        /// </summary>
        private void btn_dqclql_Click(object sender, EventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("357", 0);
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", DateTime.Now + ":" + "当前产量清零失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
        }

        /// <summary>
        /// 真空检测开
        /// </summary>
        private void btn_zkjck_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit29 = PlcCommon.busTcpClient1.ReadInt16("29").Content;
                int[] array29 = ToBinary.IntToBinaryDESC(addressBit29);

                // 29:X8
                if (btn_zkjck.BackColor == System.Drawing.Color.Lime)
                {
                    array29[8] = 1;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "真空检测按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_zkjck.BackColor = System.Drawing.Color.DarkGray;
                        btn_zkjck.ForeColor = System.Drawing.Color.White;
                        btn_zkjck.Text = "真空检测关";
                    }
                }
                else
                {
                    array29[8] = 0;
                    Array.Reverse(array29);
                    StringBuilder builder = new StringBuilder(addressBit29);
                    foreach (var item in array29)
                    {
                        builder.Append(item);
                    }

                    OperateResult operate = PlcCommon.busTcpClient1.Write("29", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "真空检测按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_zkjck.BackColor = System.Drawing.Color.Lime;
                        btn_zkjck.ForeColor = System.Drawing.Color.Black;
                        btn_zkjck.Text = "真空检测开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "真空检测操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 开启送袋
        /// </summary>
        private void btn_kqsd_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit22 = PlcCommon.busTcpClient1.ReadInt16("22").Content;
                int[] array22 = ToBinary.IntToBinaryDESC(addressBit22);
                // 22:X2
                if (btn_kqsd.BackColor == System.Drawing.Color.DarkGray)
                {
                    array22[2] = 1;
                    Array.Reverse(array22);
                    StringBuilder builder = new StringBuilder(addressBit22);
                    foreach (var item in array22)
                    {
                        builder.Append(item);
                    }

                    OperateResult operate = PlcCommon.busTcpClient1.Write("22", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "关闭送袋写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    }
                    else
                    {
                        btn_kqsd.BackColor = System.Drawing.Color.Lime;
                        btn_kqsd.ForeColor = System.Drawing.Color.Black;
                        btn_kqsd.Text = "关闭送袋";
                    }
                }
                else
                {
                    array22[2] = 0;
                    Array.Reverse(array22);
                    StringBuilder builder = new StringBuilder(addressBit22);
                    foreach (var item in array22)
                    {
                        builder.Append(item);
                    }

                    OperateResult operate = PlcCommon.busTcpClient1.Write("22", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "开启送袋写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_kqsd.BackColor = System.Drawing.Color.DarkGray;
                        btn_kqsd.ForeColor = System.Drawing.Color.Black;
                        btn_kqsd.Text = "开启送袋";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "开启送袋操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 选择纸袋 270:X0
        /// </summary>
        private void btn_xzzd_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit270 = PlcCommon.busTcpClient1.ReadInt16("270").Content;
                int[] array270 = ToBinary.IntToBinaryDESC(addressBit270);

                // 270:X0
                if (btn_xzzd.BackColor == System.Drawing.Color.DarkGray)
                {
                    array270[0] = 1;
                    Array.Reverse(array270);
                    StringBuilder builder = new StringBuilder(addressBit270);
                    foreach (var item in array270)
                    {
                        builder.Append(item);
                    }

                    OperateResult operate = PlcCommon.busTcpClient1.Write("270", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "选择塑编袋写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_xzzd.BackColor = System.Drawing.Color.Lime;
                        btn_xzzd.ForeColor = System.Drawing.Color.Black;
                        btn_xzzd.Text = "选择塑编袋";
                    }
                }
                else
                {
                    array270[0] = 0;
                    Array.Reverse(array270);
                    StringBuilder builder = new StringBuilder(addressBit270);
                    foreach (var item in array270)
                    {
                        builder.Append(item);
                    }

                    OperateResult operate = PlcCommon.busTcpClient1.Write("270", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "选择纸袋写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_xzzd.BackColor = System.Drawing.Color.DarkGray;
                        btn_xzzd.ForeColor = System.Drawing.Color.Black;
                        btn_xzzd.Text = "选择纸袋";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "开启送袋操作失败：" + ex.Message);
            }
        }

        #endregion "点击事件"

        #region "回车事件"

        /// <summary>
        /// 产量设定回车事件
        /// </summary>
        private void tbx_clsd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("354", short.Parse(tbx_clsd.Text.Replace("袋", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "产量设定下发失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiandian;
            }
        }

        /// <summary>
        /// 当前产量回车事件
        /// </summary>
        private void tbx_dqcl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("357", short.Parse(tbx_dqcl.Text.Replace("袋", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "当前产量下发失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiandian;
            }
        }

        /// <summary>
        /// 插袋总数回车事件
        /// </summary>
        private void tbx_cdzs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("392", short.Parse(tbx_cdzs.Text.Replace("袋", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "插袋总数下发失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiandian;
            }
        }

        /// <summary>
        /// 剩余袋数回车事件
        /// </summary>
        private void tbx_syds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("371", short.Parse(tbx_syds.Text.Replace("袋", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "剩余袋数下发失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiandian;
            }
        }

        /// <summary>
        /// 最后只插回车事件
        /// </summary>
        private void tbx_zhzc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("300", short.Parse(tbx_zhzc.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "最后只插下发失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiandian;
            }
        }

        #endregion "回车事件"

        #region "按钮点下"

        /// <summary>
        ///  插袋总数清零，点击改变为1
        /// </summary>
        private void btn_ql_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("395", ToBinary.AddressBitToBinary("395", 0, 1));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "插袋总数清零写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

        /// <summary>
        ///  插袋总数清零，点击改变为1
        /// </summary>
        private void btn_ql_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("395", ToBinary.AddressBitToBinary("395", 0, 0));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "AutoMatic(自动界面)" + "\r\n" + "插袋总数清零写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

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

        #endregion "按钮点下"

        private void AutoMaticForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            System.Environment.Exit(0);
        }
    }
}