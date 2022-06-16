using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class InputForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
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
                Interval = 3000,
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
            if (IsHandleCreated)
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
                #region "按钮"

                short addressBit380 = PlcCommon.busTcpClient1.ReadInt16("380").Content;
                int[] array380 = ToBinary.IntToBinaryDESC(addressBit380);

                //急停 380:X0
                //short jt = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[0] == 0)
                {
                    this.cbx_jt.Checked = true;
                }
                else
                {
                    this.cbx_jt.Checked = false;
                }

                //原点 380:X1
                //short yd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[1] == 0)
                {
                    this.cbx_yd.Checked = true;
                }
                else
                {
                    this.cbx_yd.Checked = false;
                }

                //复位 380:X2
                //short fw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[2] == 0)
                {
                    this.cbx_fw.Checked = true;
                }
                else
                {
                    this.cbx_fw.Checked = false;
                }

                //启动 380:X3
                //short qd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[3] == 0)
                {
                    this.cbx_qd.Checked = true;
                }
                else
                {
                    this.cbx_qd.Checked = false;
                }

                //停止 380:X4
                //short tz = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[4] == 0)
                {
                    this.cbx_tz.Checked = true;
                }
                else
                {
                    this.cbx_tz.Checked = false;
                }

                //自动 380:X5
                //short zd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[5] == 0)
                {
                    this.cbx_zd.Checked = true;
                }
                else
                {
                    this.cbx_zd.Checked = false;
                }

                //手动 380:X6
                //short sd = PlcCommon.busTcpClient1.ReadInt16("").Content;

                if (array380[6] == 0)
                {
                    this.cbx_sd.Checked = true;
                }
                else
                {
                    this.cbx_sd.Checked = false;
                }

                #endregion "按钮"

                #region "输入1"

                short addressBit382 = PlcCommon.busTcpClient1.ReadInt16("382").Content;
                int[] array382 = ToBinary.IntToBinaryDESC(addressBit382);

                //负压检测 382:X0
                //short fyjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[0] == 0)
                {
                    this.cbx_fyjc.Checked = true;
                }
                else
                {
                    this.cbx_fyjc.Checked = false;
                }

                //1SDI2 382:X2
                //short SDI2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[2] == 0)
                {
                    this.cbx_1SDI2.Checked = true;
                }
                else
                {
                    this.cbx_1SDI2.Checked = false;
                }

                //包机原点  382:X4
                //short bjyd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[4] == 0)
                {
                    this.cbx_bjyd.Checked = true;
                }
                else
                {
                    this.cbx_bjyd.Checked = false;
                }

                //包机有袋  382:X6
                //short bjyd2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[6] == 0)
                {
                    this.cbx_bjyd2.Checked = true;
                }
                else
                {
                    this.cbx_bjyd2.Checked = false;
                }

                //包机有袋检测异常 382:X8
                //short bjjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[8] == 0)
                {
                    this.cbx_bjjc.Checked = true;
                }
                else
                {
                    this.cbx_bjjc.Checked = false;
                }

                //ISDI10 382:X10
                //short ISDI10 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[10] == 0)
                {
                    this.cbx_ISDI10.Checked = true;
                }
                else
                {
                    this.cbx_ISDI10.Checked = false;
                }

                //1SDI1 382:X1
                // short SDI1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[1] == 0)
                {
                    this.cbx_1SDI1.Checked = true;
                }
                else
                {
                    this.cbx_1SDI1.Checked = false;
                }

                //1SDI3 382:X3
                //short SDI3 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[3] == 0)
                {
                    this.cbx_1SDI3.Checked = true;
                }
                else
                {
                    this.cbx_1SDI3.Checked = false;
                }

                //1SDI5 382:X5
                //short SDI5 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[5] == 0)
                {
                    this.cbx_1SDI5.Checked = true;
                }
                else
                {
                    this.cbx_1SDI5.Checked = false;
                }

                //1SDI7 382:X7
                //short SDI7 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[7] == 0)
                {
                    this.cbx_1SDI7.Checked = true;
                }
                else
                {
                    this.cbx_1SDI7.Checked = false;
                }

                //1SDI9 382:X9
                //short SDI9 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[9] == 0)
                {
                    this.cbx_1SDI9.Checked = true;
                }
                else
                {
                    this.cbx_1SDI9.Checked = false;
                }

                //二级气缸 升 382:X11
                // short qgs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[11] == 0)
                {
                    this.cbx_2qgs.Checked = true;
                }
                else
                {
                    this.cbx_2qgs.Checked = false;
                }

                #endregion "输入1"

                #region "输入2"

                short addressBit383 = PlcCommon.busTcpClient1.ReadInt16("383").Content;
                int[] array383 = ToBinary.IntToBinaryDESC(addressBit383);

                //二级气缸 降 383:X0
                //short qgj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[0] == 0)
                {
                    this.cbx_2qgj.Checked = true;
                }
                else
                {
                    this.cbx_2qgj.Checked = false;
                }

                //计数器信号 383:X2
                //short jsqxh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[2] == 0)
                {
                    this.cbx_jsqxh.Checked = true;
                }
                else
                {
                    this.cbx_jsqxh.Checked = false;
                }

                //总气压检测  383:X4
                //short zqyjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[4] == 0)
                {
                    this.cbx_zqyjc.Checked = true;
                }
                else
                {
                    this.cbx_zqyjc.Checked = false;
                }

                //2SDI6  383:X6
                //short SDI6 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[6] == 0)
                {
                    this.cbx_2SDI6.Checked = true;
                }
                else
                {
                    this.cbx_2SDI6.Checked = false;
                }

                //理袋完成取袋信号 383:X8
                //short ldwcqd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[8] == 0)
                {
                    this.cbx_ldwcqd.Checked = true;
                }
                else
                {
                    this.cbx_ldwcqd.Checked = false;
                }

                //ISDI10 383:X10
                //short SDI10 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[10] == 0)
                {
                    this.cbx_2SDI10.Checked = true;
                }
                else
                {
                    this.cbx_2SDI10.Checked = false;
                }

                //2SDI1 383:X1
                //short iiSDI1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[1] == 0)
                {
                    this.cbx_2SDI1.Checked = true;
                }
                else
                {
                    this.cbx_2SDI1.Checked = false;
                }

                //前有袋检测 383:X3
                //short qydjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[3] == 0)
                {
                    this.cbx_qydjc.Checked = true;
                }
                else
                {
                    this.cbx_qydjc.Checked = false;
                }

                //2SDI5 383:X5
                //short iiSDI5 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[5] == 0)
                {
                    this.cbx_2SDI5.Checked = true;
                }
                else
                {
                    this.cbx_2SDI5.Checked = false;
                }

                //装车信号(接包机) 383:X7
                //short zcxh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[7] == 0)
                {
                    this.cbx_zcxh.Checked = true;
                }
                else
                {
                    this.cbx_zcxh.Checked = false;
                }

                //2SDI9 383:X9
                //short iiSDI9 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[9] == 0)
                {
                    this.cbx_2SDI9.Checked = true;
                }
                else
                {
                    this.cbx_2SDI9.Checked = false;
                }

                //2SDI11 383:X11
                //short iiSDI11 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[11] == 0)
                {
                    this.cbx_2SDI11.Checked = true;
                }
                else
                {
                    this.cbx_2SDI11.Checked = false;
                }

                #endregion "输入2"

                #region "输入3"

                short addressBit384 = PlcCommon.busTcpClient1.ReadInt16("384").Content;
                int[] array384 = ToBinary.IntToBinaryDESC(addressBit384);

                //3SDI0 降 384:X0
                //short iiiSDI0 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[0] == 0)
                {
                    this.cbx_3SDI0.Checked = true;
                }
                else
                {
                    this.cbx_3SDI0.Checked = false;
                }

                //取袋气缸伸出 384:X2
                //short qdsc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[2] == 0)
                {
                    this.cbx_qdsc.Checked = true;
                }
                else
                {
                    this.cbx_qdsc.Checked = false;
                }

                //取袋气缸缩回  384:X4
                //short qdsh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[4] == 0)
                {
                    this.cbx_qdsh.Checked = true;
                }
                else
                {
                    this.cbx_qdsh.Checked = false;
                }

                //一级气缸 升  384:X6
                //short iiiqgs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[6] == 0)
                {
                    this.cbx_1qgs.Checked = true;
                }
                else
                {
                    this.cbx_1qgs.Checked = false;
                }

                //一级气缸 降 384:X8
                //short iiiqgj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[8] == 0)
                {
                    this.cbx_1qgj.Checked = true;
                }
                else
                {
                    this.cbx_1qgj.Checked = false;
                }

                //抓手气缸 夹紧 384:X10
                //short zsjj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[10] == 0)
                {
                    this.cbx_zsjj.Checked = true;
                }
                else
                {
                    this.cbx_zsjj.Checked = false;
                }

                //抓手气缸张开 384:X1
                //short zszk = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[1] == 0)
                {
                    this.cbx_zszk.Checked = true;
                }
                else
                {
                    this.cbx_2SDI1.Checked = false;
                }

                //储袋定位传感器 384:X3
                //short cddw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[3] == 0)
                {
                    this.cbx_cddw.Checked = true;
                }
                else
                {
                    this.cbx_cddw.Checked = false;
                }

                //储袋对射传感器 384:X5
                //short cdds = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[5] == 0)
                {
                    this.cbx_cdds.Checked = true;
                }
                else
                {
                    this.cbx_cdds.Checked = false;
                }

                //3SDI7 383:X7
                //short iiiSDI7 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[7] == 0)
                {
                    this.cbx_3SDI7.Checked = true;
                }
                else
                {
                    this.cbx_3SDI7.Checked = false;
                }

                //后有袋检测 384:X9
                // short hydjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[9] == 0)
                {
                    this.cbx_hydjc.Checked = true;
                }
                else
                {
                    this.cbx_hydjc.Checked = false;
                }

                //3SDI11 384:X11
                //short iiiSDI11 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[11] == 0)
                {
                    this.cbx_3SDI11.Checked = true;
                }
                else
                {
                    this.cbx_3SDI11.Checked = false;
                }

                #endregion "输入3"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "InPut(输入界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转"

        /// <summary>
        /// 输出页面
        /// </summary>
        private void Btn_OutputForm_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            OutputForm outputForm = new OutputForm();
            this.Hide();
            outputForm.ShowDialog();
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

        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}