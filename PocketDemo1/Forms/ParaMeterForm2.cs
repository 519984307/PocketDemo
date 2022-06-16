using HslCommunication;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ParaMeterForm2 : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public ParaMeterForm2()
        {
            InitializeComponent();
        }

        private void ParaMeterForm2_Load(object sender, EventArgs e)
        {
            PlcCommon.readVar = false;
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
            timer = new System.Timers.Timer
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
                #region "第一列"

                //气压低停机时间  106
                short qydt = PlcCommon.busTcpClient1.ReadInt16("106").Content;
                tbx_qydt.Text = (qydt + "ms").ToString();

                //气压负压次数 109
                short lxfy = PlcCommon.busTcpClient1.ReadInt16("109").Content;
                tbx_lxfy.Text = (lxfy + "次").ToString();

                //抓手气缸延时 31
                short zsys = PlcCommon.busTcpClient1.ReadInt16("31").Content;
                tbx_zsys.Text = (zsys + "ms").ToString();

                //送袋延时 85
                short sdys = PlcCommon.busTcpClient1.ReadInt16("85").Content;
                tbx_sdys.Text = (sdys + "ms").ToString();

                //清包机延时开时间 107
                short qbjk = PlcCommon.busTcpClient1.ReadInt16("107").Content;
                tbx_qbjk.Text = (qbjk + "ms").ToString();

                //清包机延时关机时间 100
                short qbjg = PlcCommon.busTcpClient1.ReadInt16("100").Content;
                tbx_qbjg.Text = (qbjg + "ms").ToString();

                #endregion "第一列"

                #region "第二列"

                //吹气1开始位置  102
                short cqks1 = PlcCommon.busTcpClient1.ReadInt16("102").Content;
                tbx_cqks1.Text = (cqks1 + "").ToString();

                //吹气1停止位置 103
                short cqtz1 = PlcCommon.busTcpClient1.ReadInt16("103").Content;
                tbx_cqtz1.Text = (cqtz1 + "").ToString();

                //侧挡上翻延时 210
                short cdsf = PlcCommon.busTcpClient1.ReadInt16("210").Content;
                tbx_cdsf.Text = (cdsf + "ms").ToString();

                //装车信号滤波 214
                short zclb = PlcCommon.busTcpClient1.ReadInt16("214").Content;
                tbx_zclb.Text = (zclb + "ms").ToString();

                //前有袋检测信号滤波 215
                short qydjc = PlcCommon.busTcpClient1.ReadInt16("215").Content;
                tbx_qydjc.Text = (qydjc + "ms").ToString();

                //升降回位延时 84
                short sjhw = PlcCommon.busTcpClient1.ReadInt16("84").Content;
                tbx_sjhw.Text = (sjhw + "ms").ToString();

                #endregion "第二列"

                #region "第三列"

                //调试时夹紧气缸释放位 344
                short tsjjsf = PlcCommon.busTcpClient1.ReadInt16("344").Content;
                tbx_tsjjsf.Text = (tsjjsf + "").ToString();

                //自行运行夹紧气缸释放位 345
                short zdjjsf = PlcCommon.busTcpClient1.ReadInt16("345").Content;
                tbx_zdjjsf.Text = (zdjjsf + "").ToString();

                //计数器滤波时间 356
                short jsqlb = PlcCommon.busTcpClient1.ReadInt16("356").Content;
                tbx_jsqlb.Text = (jsqlb + "ms").ToString();

                //纸袋升降伺服回位 274
                short zdhw = PlcCommon.busTcpClient1.ReadInt16("274").Content;
                tbx_zdhw.Text = (zdhw + "mm").ToString();

                //纸袋升降伺服递增 275
                short zddz = PlcCommon.busTcpClient1.ReadInt16("275").Content;
                tbx_zddz.Text = (zddz + "mm").ToString();

                //编织袋升降伺服回位 276
                short bzhw = PlcCommon.busTcpClient1.ReadInt16("276").Content;
                tbx_bzhw.Text = (bzhw + "mm").ToString();

                //编织袋升降伺服递增 277
                short bzdz = PlcCommon.busTcpClient1.ReadInt16("277").Content;
                tbx_bzdz.Text = (bzdz + "mm").ToString();

                #endregion "第三列"

                #region "第四列"

                short addressBit161 = PlcCommon.busTcpClient1.ReadInt16("161").Content;
                int[] array161 = ToBinary.IntToBinaryDESC(addressBit161);
                //停止调试 161:X3
                //short btn_tzts = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array161[3] == 0)
                {
                    this.btn_tzts.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_tzts.ForeColor = System.Drawing.Color.Black;
                    this.btn_tzts.Text = "调试停止";
                }
                else
                {
                    this.btn_tzts.BackColor = System.Drawing.Color.Lime;
                    this.btn_tzts.ForeColor = System.Drawing.Color.White;
                    this.btn_tzts.Text = "调试启动";
                }

                //还余几袋停插袋机 303
                short hyjd = PlcCommon.busTcpClient1.ReadInt16("303").Content;
                tbx_hyjd.Text = (hyjd + "").ToString();

                //计数传感器前包数 302
                short jscg = PlcCommon.busTcpClient1.ReadInt16("302").Content;
                tbx_jscg.Text = (jscg + "").ToString();

                #endregion "第四列"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "回车事件"

        #region "第一列"

        /// <summary>
        ///气压低停机时间  106
        /// </summary>
        private void tbx_qydt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("106", short.Parse(tbx_qydt.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "气压低停机时间修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///气压负压次数 109
        /// </summary>
        private void tbx_lxfy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("109", short.Parse(tbx_lxfy.Text.Replace("次", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "气压负压次数修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///抓手气缸延时 31
        /// </summary>
        private void tbx_zsys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("31", short.Parse(tbx_zsys.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "抓手气缸延时修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋延时 85
        /// </summary>
        private void tbx_sdys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("85", short.Parse(tbx_sdys.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "送袋延时修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 清包机延时开时间 107
        /// </summary>
        private void tbx_qbjk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("107", short.Parse(tbx_qbjk.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "清包机延时开时间修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///清包机延时关机时间 100
        /// </summary>
        private void tbx_qbjg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("100", short.Parse(tbx_qbjg.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "清包机延时关机时间修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "第一列"

        #region "第二列"

        /// <summary>
        /// 吹气1开始位置  102
        /// </summary>
        private void tbx_cqks1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("102", short.Parse(tbx_cqks1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "吹气1开始位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 吹气1停止位置 103
        /// </summary>
        private void tbx_cqtz1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("103", short.Parse(tbx_cqtz1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "主吹气1停止位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 侧挡上翻延时 210
        /// </summary>
        private void tbx_cdsf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("210", short.Parse(tbx_cdsf.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "侧挡上翻延时修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 装车信号滤波 214
        /// </summary>
        private void tbx_zclb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("214", short.Parse(tbx_zclb.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "装车信号滤波修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 前有袋检测信号滤波 215
        /// </summary>
        private void tbx_qydjc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("215", short.Parse(tbx_qydjc.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "前有袋检测信号滤波修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "第二列"

        #region "第三列"

        /// <summary>
        /// 调试时夹紧气缸释放位 344
        /// </summary>
        private void tbx_tsjjsf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("344", short.Parse(tbx_tsjjsf.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "调试时夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 自行运行夹紧气缸释放位 345
        /// </summary>
        private void tbx_zdjjsf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("345", short.Parse(tbx_zdjjsf.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "自行运行夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 计数器滤波时间 356
        /// </summary>
        private void tbx_jsqlb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("356", short.Parse(tbx_jsqlb.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "计数器滤波时间修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 纸袋升降伺服回位 274
        /// </summary>
        private void tbx_zdhw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("274", short.Parse(tbx_zdhw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "纸袋升降伺服回位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 纸袋升降伺服递增 275
        /// </summary>
        private void tbx_zddz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("275", short.Parse(tbx_zddz.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "纸袋升降伺服递增修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 编织袋升降伺服回位 276
        /// </summary>
        private void tbx_bzhw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("276", short.Parse(tbx_bzhw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "编织袋升降伺服回位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 编织袋升降伺服递增 277
        /// </summary>
        private void tbx_bzdz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("277", short.Parse(tbx_bzdz.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "编织袋升降伺服递增修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "第三列"

        #region "第四列"

        /// <summary>
        /// 还余几袋停插袋机 303
        /// </summary>
        private void tbx_hyjd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("303", short.Parse(tbx_hyjd.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "还余几袋停插袋机修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 计数传感器前包数 302
        /// </summary>
        private void tbx_jscg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("302", short.Parse(tbx_jscg.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "计数传感器前包数修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "第四列"

        #endregion "回车事件"

        #region "页面跳转"

        /// <summary>
        /// 参数2按钮
        /// </summary>
        private void Btn_ParaMeterForm1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ParaMeterForm1 paraMeterForm1 = new ParaMeterForm1();
            this.Hide();
            paraMeterForm1.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 参数3按钮
        /// </summary>
        private void Btn_ParaMeterForm3_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ParaMeterForm3 paraMeterForm3 = new ParaMeterForm3();
            this.Hide();
            paraMeterForm3.ShowDialog();
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

        #endregion "页面跳转"

        #region "按钮"

        /// <summary>
        /// 停止调试 161:X3
        /// </summary>
        private void btn_tzts_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_tzts.BackColor == System.Drawing.Color.DarkGray)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", ToBinary.AddressBitToBinary("161", 3, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "停止调试写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_tzts.BackColor = System.Drawing.Color.Lime;
                        btn_tzts.ForeColor = System.Drawing.Color.White;
                        btn_tzts.Text = "调试开始";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("161", ToBinary.AddressBitToBinary("161", 3, 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter2(参数2界面)" + "\r\n" + "停止调试写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_tzts.BackColor = System.Drawing.Color.DarkGray;
                        btn_tzts.ForeColor = System.Drawing.Color.Black;
                        btn_tzts.Text = "调试停止";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Manual(手动界面)" + "\r\n" + "停止调试操作失败：" + ex.Message);
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

        #endregion "按钮"

        /// <summary>
        /// 窗体关闭，关闭线程
        /// </summary>
        private void ParaMeterForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}