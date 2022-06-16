using HslCommunication;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ParaMeterForm1 : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public ParaMeterForm1()
        {
            InitializeComponent();
        }

        private void ParaMeterForm1_Load(object sender, EventArgs e)
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

        /// <summary>
        /// 读取参数
        /// </summary>
        public void ReadPara()
        {
            try
            {
                #region "工位偏移"

                //1#工位偏移 9
                int gwpy1 = PlcCommon.busTcpClient1.ReadInt16("9").Content;
                //tbx_gwpy1.Text = Convert.ToDouble(gwpy1 / 10).ToString(" ");
                tbx_gwpy1.Text = Convert.ToDouble(gwpy1).ToString();

                //2#工位偏移 10
                short gwpy2 = PlcCommon.busTcpClient1.ReadInt16("10").Content;
                tbx_gwpy2.Text = Convert.ToDouble(gwpy2).ToString();

                //3#工位偏移 11
                short gwpy3 = PlcCommon.busTcpClient1.ReadInt16("11").Content;
                tbx_gwpy3.Text = Convert.ToDouble(gwpy3).ToString();

                //4#工位偏移 12
                short gwpy4 = PlcCommon.busTcpClient1.ReadInt16("12").Content;
                tbx_gwpy4.Text = Convert.ToDouble(gwpy4).ToString();

                //5#工位偏移 13
                short gwpy5 = PlcCommon.busTcpClient1.ReadInt16("13").Content;
                tbx_gwpy5.Text = Convert.ToDouble(gwpy5).ToString();

                //6#工位偏移 14
                short gwpy6 = PlcCommon.busTcpClient1.ReadInt16("14").Content;
                tbx_gwpy6.Text = Convert.ToDouble(gwpy6).ToString();

                //7#工位偏移 15
                short gwpy7 = PlcCommon.busTcpClient1.ReadInt16("15").Content;
                tbx_gwpy7.Text = Convert.ToDouble(gwpy7).ToString();

                //8#工位偏移 16
                short gwpy8 = PlcCommon.busTcpClient1.ReadInt16("16").Content;
                tbx_gwpy8.Text = Convert.ToDouble(gwpy8).ToString();

                #endregion "工位偏移"

                #region "第二列"

                //边推气缸第一次启动位置 211
                short btdycqd = PlcCommon.busTcpClient1.ReadInt16("211").Content;
                tbx_btdycqd.Text = btdycqd + "mm".ToString();

                //主轴零位偏移角度 17
                short zzlwpyjd = PlcCommon.busTcpClient1.ReadInt16("17").Content;
                tbx_zzlwpyjd.Text = Convert.ToDouble(zzlwpyjd).ToString();

                //边推气缸启动位置 145
                short btqd = PlcCommon.busTcpClient1.ReadInt16("145").Content;
                tbx_btqd.Text = Convert.ToDouble(btqd).ToString();

                //边推气缸停止位置 146
                short bttz = PlcCommon.busTcpClient1.ReadInt16("146").Content;
                tbx_bttz.Text = Convert.ToDouble(bttz).ToString();

                //前压气缸启动位置 141
                short qyqd = PlcCommon.busTcpClient1.ReadInt16("141").Content;
                tbx_qyqd.Text = Convert.ToDouble(qyqd).ToString();

                //前压气缸停止位置 142
                short qytz = PlcCommon.busTcpClient1.ReadInt16("142").Content;
                tbx_qytz.Text = Convert.ToDouble(qytz).ToString();

                #endregion "第二列"

                #region "第三列"

                //摆臂最大电流 346
                short bbzd = PlcCommon.busTcpClient1.ReadInt16("346").Content;
                tbx_bbzd.Text = bbzd + "mA".ToString();

                //插袋气缸开位置 150
                short cdk = PlcCommon.busTcpClient1.ReadInt16("150").Content;
                tbx_cdk.Text = Convert.ToDouble(cdk).ToString();

                //插袋气缸关位置 151
                short cdg = PlcCommon.busTcpClient1.ReadInt16("151").Content;
                tbx_cdg.Text = Convert.ToDouble(cdg).ToString();

                //翻袋吸盘开位置 110
                short fdk = PlcCommon.busTcpClient1.ReadInt16("110").Content;
                tbx_fdk.Text = Convert.ToDouble(fdk).ToString();

                //翻袋吸盘关位置 111
                short fdg = PlcCommon.busTcpClient1.ReadInt16("111").Content;
                tbx_fdg.Text = Convert.ToDouble(fdg).ToString();

                //后取袋吸盘开位置 98
                short hqdk = PlcCommon.busTcpClient1.ReadInt16("98").Content;
                tbx_hqdk.Text = Convert.ToDouble(hqdk).ToString();

                //后取袋吸盘关位置 99
                short hqdg = PlcCommon.busTcpClient1.ReadInt16("99").Content;
                tbx_hqdg.Text = Convert.ToDouble(hqdg).ToString();

                #endregion "第三列"

                #region "第四列"

                //包机零号工位号 25
                short bjlhgwh = PlcCommon.busTcpClient1.ReadInt16("25").Content;
                tbx_bjlhgwh.Text = Convert.ToDouble(bjlhgwh) + "工位".ToString();

                //夹紧气缸夹紧位 26
                short jjjj = PlcCommon.busTcpClient1.ReadInt16("26").Content;
                tbx_jjjj.Text = Convert.ToDouble(jjjj).ToString();

                //夹紧气缸释放位 27
                short jjsf = PlcCommon.busTcpClient1.ReadInt16("27").Content;
                tbx_jjsf.Text = Convert.ToDouble(jjsf).ToString();

                //后取袋气缸开位置 112
                short hqdqgk = PlcCommon.busTcpClient1.ReadInt16("112").Content;
                tbx_hqdqgk.Text = Convert.ToDouble(hqdqgk).ToString();

                //后取袋气缸关位置 113
                short hqdqgg = PlcCommon.busTcpClient1.ReadInt16("113").Content;
                tbx_hqdqgg.Text = Convert.ToDouble(hqdqgg).ToString();

                #endregion "第四列"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转 "

        /// <summary>
        /// 参数2按钮
        /// </summary>
        private void Btn_ParaMeterForm2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ParaMeterForm2 paraMeterForm2 = new ParaMeterForm2();
            this.Hide();
            paraMeterForm2.ShowDialog();
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

        #endregion "页面跳转 "

        #region "回车事件"

        #region "第一列"

        /// <summary>
        /// 1#工位偏移 9
        /// </summary>
        private void tbx_gwpy1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("9", short.Parse(tbx_gwpy1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "1#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 2#工位偏移 10
        /// </summary>
        private void tbx_gwpy2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("10", short.Parse(tbx_gwpy2.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "2#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 3#工位偏移 11
        /// </summary>
        private void tbx_gwpy3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("11", short.Parse(tbx_gwpy3.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "3#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 4#工位偏移 12
        /// </summary>
        private void tbx_gwpy4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("12", short.Parse(tbx_gwpy4.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "4#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 5#工位偏移 13
        /// </summary>
        private void tbx_gwpy5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("13", short.Parse(tbx_gwpy5.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "5#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 6#工位偏移 14
        /// </summary>
        private void tbx_gwpy6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("14", short.Parse(tbx_gwpy6.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "6#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 7#工位偏移 15
        /// </summary>
        private void tbx_gwpy7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("15", short.Parse(tbx_gwpy7.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "7#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        #endregion "第一列"

        #region "第二列"

        /// <summary>
        /// 8#工位偏移 16
        /// </summary>
        private void tbx_gwpy8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("16", short.Parse(tbx_gwpy8.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "8#工位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 边推气缸第一次启动位置 211
        /// </summary>
        private void tbx_btdycqd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("211", short.Parse(tbx_btdycqd.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "边推气缸第一次启动位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17; PlcCommon.readVar = true;
            }
        }

        /// <summary>
        ///  主轴零位偏移角度 17
        /// </summary>
        private void tbx_zzlwpyjd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("17", short.Parse(tbx_zzlwpyjd.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "主轴零位偏移角度修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 边推气缸启动位置 145
        /// </summary>
        private void tbx_btqd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("145", short.Parse(tbx_btqd.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "边推气缸启动位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 边推气缸停止位置 146
        /// </summary>
        private void tbx_bttz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("146", short.Parse(tbx_bttz.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "边推气缸停止位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 前压气缸启动位置 141
        /// </summary>
        private void tbx_qyqd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("141", short.Parse(tbx_qyqd.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "前压气缸启动位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 前压气缸停止位置 142
        /// </summary>
        private void tbx_qytz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("142", short.Parse(tbx_qytz.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "前压气缸停止位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        #endregion "第二列"

        #region "第三列"

        /// <summary>
        /// 摆臂最大电流 346
        /// </summary>
        private void tbx_bbzd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("346", short.Parse(tbx_bbzd.Text.Replace("mA", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "摆臂最大电流修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 插袋气缸开位置 150
        /// </summary>
        private void tbx_cdk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("150", short.Parse(tbx_cdk.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "插袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 插袋气缸关位置 151
        /// </summary>
        private void tbx_cdg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("151", short.Parse(tbx_cdg.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "插袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 翻袋吸盘开位置 110
        /// </summary>
        private void tbx_fdk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("110", short.Parse(tbx_fdk.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "翻袋吸盘开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 翻袋吸盘关位置 111
        /// </summary>
        private void tbx_fdg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("111", short.Parse(tbx_fdg.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "翻袋吸盘关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 后取袋吸盘开位置 98
        /// </summary>
        private void tbx_hqdk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("98", short.Parse(tbx_hqdk.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "后取袋吸盘开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 后取袋吸盘关位置 99
        /// </summary>
        private void tbx_hqdg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("99", short.Parse(tbx_hqdg.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "后取袋吸盘关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        #endregion "第三列"

        #region "第四列"

        /// <summary>
        /// 包机零号工位号 25
        /// </summary>
        private void tbx_bjlhgwh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("25", short.Parse(tbx_bjlhgwh.Text.Replace("工位", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "包机零号工位号修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 夹紧气缸夹紧位 26
        /// </summary>
        private void tbx_jjjj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("26", short.Parse(tbx_jjjj.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "夹紧气缸夹紧位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        ///夹紧气缸释放位 27
        /// </summary>
        private void tbx_jjsf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("27", short.Parse(tbx_jjsf.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 后取袋气缸开位置 112
        /// </summary>
        private void tbx_hqdqgk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("112", short.Parse(tbx_hqdqgk.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "后取袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        /// <summary>
        /// 后取袋气缸关位置 113
        /// </summary>
        private void tbx_hqdqgg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("113", short.Parse(tbx_hqdqgg.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter(参数界面)" + "\r\n" + "后取袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = label17;
            }
        }

        #endregion "第四列"

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

        #endregion "回车事件"

        private void ParaMeterForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}