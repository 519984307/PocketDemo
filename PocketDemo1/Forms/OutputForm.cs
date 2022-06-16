using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class OutputForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public OutputForm()
        {
            InitializeComponent();
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {
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
                Interval = 2000,
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
            if (this.InvokeRequired)
            {
                this.Invoke(new SetDataDelegate(ReadPara));
            }
            else
            {
                return;
            }
        }

        public void ReadPara()
        {
            try
            {
                #region "按钮指示灯"

                short addressBit381 = PlcCommon.busTcpClient1.ReadInt16("381").Content;
                int[] array381 = ToBinary.IntToBinaryDESC(addressBit381);

                //DQ0 381:X0
                //short rtn_DQ0 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[0] == 0)
                {
                    this.rtn_DQ0.Checked = true;
                }
                else
                {
                    this.rtn_DQ0.Checked = false;
                }

                //启动指示灯 381:X1
                //short rtn_qdzs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[1] == 0)
                {
                    this.rtn_qdzs.Checked = true;
                }
                else
                {
                    this.rtn_qdzs.Checked = false;
                }

                //停止指示灯 381:X2
                //short rtn_tzzs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[2] == 0)
                {
                    this.rtn_tzzs.Checked = true;
                }
                else
                {
                    this.rtn_tzzs.Checked = false;
                }

                //原点指示灯 381:X3
                //short rtn_ydzs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[3] == 0)
                {
                    this.rtn_ydzs.Checked = true;
                }
                else
                {
                    this.rtn_ydzs.Checked = false;
                }

                #endregion "按钮指示灯"

                #region "输出1"

                short addressBit385 = PlcCommon.busTcpClient1.ReadInt16("385").Content;
                int[] array385 = ToBinary.IntToBinaryDESC(addressBit385);

                //插袋气缸 385:X0
                //short rtn_cdqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[0] == 0)
                {
                    this.rtn_cdqg.Checked = true;
                }
                else
                {
                    this.rtn_cdqg.Checked = false;
                }

                //前压气缸 385:X1
                //short rtn_qyqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[1] == 0)
                {
                    this.rtn_qyqg.Checked = true;
                }
                else
                {
                    this.rtn_qyqg.Checked = false;
                }

                //1SDQ2 385:X2
                //short rtn_1SDQ2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[2] == 0)
                {
                    this.rtn_1SDQ2.Checked = true;
                }
                else
                {
                    this.rtn_1SDQ2.Checked = false;
                }

                // 手/自动切换 385:X3
                // short rtn_szdqh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[3] == 0)
                {
                    this.rtn_szdqh.Checked = true;
                }
                else
                {
                    this.rtn_szdqh.Checked = false;
                }

                //后取气缸 385:X4
                //short rtn_hqqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[4] == 0)
                {
                    this.rtn_hqqg.Checked = true;
                }
                else
                {
                    this.rtn_hqqg.Checked = false;
                }

                //1SDQ5 385:X5
                //short rtn_1SDQ5 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[5] == 0)
                {
                    this.rtn_1SDQ5.Checked = true;
                }
                else
                {
                    this.rtn_1SDQ5.Checked = false;
                }

                //1SDQ6 385:X6
                //short rtn_1SDQ6 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[6] == 0)
                {
                    this.rtn_1SDQ6.Checked = true;
                }
                else
                {
                    this.rtn_1SDQ6.Checked = false;
                }

                // 1SDQ7 385:X7
                //short rtn_1SDQ7 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[7] == 0)
                {
                    this.rtn_1SDQ7.Checked = true;
                }
                else
                {
                    this.rtn_1SDQ7.Checked = false;
                }

                //包机低速回零 385:X8
                //short rtn_bjdshl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[8] == 0)
                {
                    this.rtn_bjdshl.Checked = true;
                }
                else
                {
                    this.rtn_bjdshl.Checked = false;
                }

                //掉袋控制信号 385:X9
                // short rtn_ddkz = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[9] == 0)
                {
                    this.rtn_ddkz.Checked = true;
                }
                else
                {
                    this.rtn_ddkz.Checked = false;
                }

                //ISDQ10 385:X10
                //short rtn_ISDQ10 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[10] == 0)
                {
                    this.rtn_ISDQ10.Checked = true;
                }
                else
                {
                    this.rtn_ISDQ10.Checked = false;
                }

                //包机启动信号 385:X11
                // short rtn_bjqd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[11] == 0)
                {
                    this.rtn_bjqd.Checked = true;
                }
                else
                {
                    this.rtn_bjqd.Checked = false;
                }

                #endregion "输出1"

                #region "输出2"

                short addressBit386 = PlcCommon.busTcpClient1.ReadInt16("386").Content;
                int[] array386 = ToBinary.IntToBinaryDESC(addressBit386);

                //侧挡袋气缸 386:X0
                //short rtn_cddqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[0] == 0)
                {
                    this.rtn_cddqg.Checked = true;
                }
                else
                {
                    this.rtn_cddqg.Checked = false;
                }

                //2SDQ1 386:X1
                // short rtn_2SDQ1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[1] == 0)
                {
                    this.rtn_2SDQ1.Checked = true;
                }
                else
                {
                    this.rtn_2SDQ1.Checked = false;
                }

                //夹紧气缸 386:X2
                //short rtn_jjqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[2] == 0)
                {
                    this.rtn_jjqg.Checked = true;
                }
                else
                {
                    this.rtn_jjqg.Checked = false;
                }

                //二级气缸 386:X3
                //short rtn_2qg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[3] == 0)
                {
                    this.rtn_2qg.Checked = true;
                }
                else
                {
                    this.rtn_2qg.Checked = false;
                }

                //边推气缸 386:X4
                //short rtn_btqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[4] == 0)
                {
                    this.rtn_btqg.Checked = true;
                }
                else
                {
                    this.rtn_btqg.Checked = false;
                }

                //2SDQ5 386:X5
                //short rtn_2SDQ5 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[5] == 0)
                {
                    this.rtn_2SDQ5.Checked = true;
                }
                else
                {
                    this.rtn_2SDQ5.Checked = false;
                }

                //2SDQ6 386:X6
                //short rtn_2SDQ6 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[6] == 0)
                {
                    this.rtn_2SDQ6.Checked = true;
                }
                else
                {
                    this.rtn_2SDQ6.Checked = false;
                }

                // 翻袋平台风扇 386:X7
                // short rtn_fdfs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[7] == 0)
                {
                    this.rtn_fdfs.Checked = true;
                }
                else
                {
                    this.rtn_fdfs.Checked = false;
                }

                //2SDQ8 386:X8
                //short rtn_2SDQ8 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[8] == 0)
                {
                    this.rtn_2SDQ8.Checked = true;
                }
                else
                {
                    this.rtn_2SDQ8.Checked = false;
                }

                //报警指示灯(红) 386:X9
                //short rtn_bjh2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[9] == 0)
                {
                    this.rtn_bjh2.Checked = true;
                }
                else
                {
                    this.rtn_bjh2.Checked = false;
                }

                //报警指示灯(黄)  386:X10
                // short rtn_bjh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[10] == 0)
                {
                    this.rtn_bjh.Checked = true;
                }
                else
                {
                    this.rtn_bjh.Checked = false;
                }

                //报警指示灯 386:X11
                //short rtn_bjl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[11] == 0)
                {
                    this.rtn_bjl.Checked = true;
                }
                else
                {
                    this.rtn_bjl.Checked = false;
                }

                #endregion "输出2"

                #region "输出3"

                short addressBit387 = PlcCommon.busTcpClient1.ReadInt16("387").Content;
                int[] array387 = ToBinary.IntToBinaryDESC(addressBit387);

                //后取吸盘 387:X0

                //short rtn_hqxp = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[0] == 0)
                {
                    this.rtn_hqxp.Checked = true;
                }
                else
                {
                    this.rtn_hqxp.Checked = false;
                }

                //3SDQ1 387:X1
                //short rtn_3SDQ1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[1] == 0)
                {
                    this.rtn_3SDQ1.Checked = true;
                }
                else
                {
                    this.rtn_3SDQ1.Checked = false;
                }

                //3SDQ2 387:X2
                //short rtn_3SDQ2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[2] == 0)
                {
                    this.rtn_3SDQ2.Checked = true;
                }
                else
                {
                    this.rtn_3SDQ2.Checked = false;
                }

                // 取袋气缸 387:X3
                //short rtn_qdqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[3] == 0)
                {
                    this.rtn_qdqg.Checked = true;
                }
                else
                {
                    this.rtn_qdqg.Checked = false;
                }

                //翻袋吸盘 387:X4
                //short rtn_fdxp = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[4] == 0)
                {
                    this.rtn_fdxp.Checked = true;
                }
                else
                {
                    this.rtn_fdxp.Checked = false;
                }

                //一级气缸 升 387:X5
                //short rtn_1qgs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[5] == 0)
                {
                    this.rtn_1qgs.Checked = true;
                }
                else
                {
                    this.rtn_1qgs.Checked = false;
                }

                //3SDQ6 387:X6
                //short rtn_3SDQ6 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[6] == 0)
                {
                    this.rtn_3SDQ6.Checked = true;
                }
                else
                {
                    this.rtn_3SDQ6.Checked = false;
                }

                // 一级气缸 降 387:X7
                //short rtn_1qgj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[7] == 0)
                {
                    this.rtn_1qgj.Checked = true;
                }
                else
                {
                    this.rtn_1qgj.Checked = false;
                }

                //3SDQ8 387:X8
                //short rtn_3SDQ8 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[8] == 0)
                {
                    this.rtn_3SDQ8.Checked = true;
                }
                else
                {
                    this.rtn_3SDQ8.Checked = false;
                }

                //抓手气缸 387:X9
                //short rtn_zsqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[9] == 0)
                {
                    this.rtn_zsqg.Checked = true;
                }
                else
                {
                    this.rtn_zsqg.Checked = false;
                }

                //3SDQ10 387:X10
                //short rtn_3SDQ10 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[10] == 0)
                {
                    this.rtn_3SDQ10.Checked = true;
                }
                else
                {
                    this.rtn_3SDQ10.Checked = false;
                }

                //储袋马达 387:X11
                //short rtn_cdmd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[11] == 0)
                {
                    this.rtn_cdmd.Checked = true;
                }
                else
                {
                    this.rtn_cdmd.Checked = false;
                }

                #endregion "输出3"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "Output(输出界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转 "

        /// <summary>
        /// 输入页面
        /// </summary>
        private void Btn_InputForm_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            InputForm inputForm = new InputForm();
            this.Hide();
            inputForm.ShowDialog();
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

        private void OutputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}