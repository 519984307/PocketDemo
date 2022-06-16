using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class IOControllerForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public IOControllerForm()
        {
            InitializeComponent();
        }

        private void IOControllerForm_Load(object sender, EventArgs e)
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
                #region "输入"

                #region "第一列"

                short addressBit380 = PlcCommon.busTcpClient1.ReadInt16("380").Content;
                int[] array380 = ToBinary.IntToBinaryDESC(addressBit380);

                //急停 380:X0
                //short rtn_jt = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[0] == 0)
                {
                    this.rtn_jt.Checked = true;
                }
                else
                {
                    this.rtn_jt.Checked = false;
                }

                //原点 380:X1
                //short rtn_yd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[1] == 0)
                {
                    this.rtn_yd.Checked = true;
                }
                else
                {
                    this.rtn_yd.Checked = false;
                }

                //复位 380:X2
                //short rtn_fw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[2] == 0)
                {
                    this.rtn_fw.Checked = true;
                }
                else
                {
                    this.rtn_fw.Checked = false;
                }

                //启动 380:X3
                //short rtn_qd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[3] == 0)
                {
                    this.rtn_qd.Checked = true;
                }
                else
                {
                    this.rtn_qd.Checked = false;
                }

                //停止 380:X4
                //short rtn_tz = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[4] == 0)
                {
                    this.rtn_tz.Checked = true;
                }
                else
                {
                    this.rtn_tz.Checked = false;
                }

                //手动 380:X5
                //short rtn_sd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[5] == 0)
                {
                    this.rtn_sd.Checked = true;
                }
                else
                {
                    this.rtn_sd.Checked = false;
                }

                //自动 380:X6
                //short rtn_zd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array380[6] == 0)
                {
                    this.rtn_zd.Checked = true;
                }
                else
                {
                    this.rtn_zd.Checked = false;
                }

                short addressBit382 = PlcCommon.busTcpClient1.ReadInt16("382").Content;
                int[] array382 = ToBinary.IntToBinaryDESC(addressBit382);

                //负压检测 382:X0
                //short rtn_fyjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[0] == 0)
                {
                    this.rtn_fyjc.Checked = true;
                }
                else
                {
                    this.rtn_fyjc.Checked = false;
                }

                //包机运行反馈信号 382:X1
                //short rtn_bjfk = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[1] == 0)
                {
                    this.rtn_bjfk.Checked = true;
                }
                else
                {
                    this.rtn_bjfk.Checked = false;
                }

                #endregion "第一列"

                #region "第二列"

                //包机原点 382:X4
                //short rtn_bjyd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[4] == 0)
                {
                    this.rtn_bjyd.Checked = true;
                }
                else
                {
                    this.rtn_bjyd.Checked = false;
                }

                //包机有袋 382:X6
                //short rtn_bjyd2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[6] == 0)
                {
                    this.rtn_bjyd2.Checked = true;
                }
                else
                {
                    this.rtn_bjyd2.Checked = false;
                }

                //包机有袋检测异常 382:X8
                //short rtn_bjyc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[8] == 0)
                {
                    this.rtn_bjyc.Checked = true;
                }
                else
                {
                    this.rtn_bjyc.Checked = false;
                }

                //二级气缸升 382:X11
                //short rtn_2qgs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array382[11] == 0)
                {
                    this.rtn_2qgs.Checked = true;
                }
                else
                {
                    this.rtn_2qgs.Checked = false;
                }

                short addressBit383 = PlcCommon.busTcpClient1.ReadInt16("383").Content;
                int[] array383 = ToBinary.IntToBinaryDESC(addressBit383);

                //二级气缸降 383:X0
                //short rtn_2qgj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[0] == 0)
                {
                    this.rtn_2qgj.Checked = true;
                }
                else
                {
                    this.rtn_2qgj.Checked = false;
                }

                //计数器信号 383:X2
                //short rtn_jsxh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[2] == 0)
                {
                    this.rtn_jsxh.Checked = true;
                }
                else
                {
                    this.rtn_jsxh.Checked = false;
                }

                //前有袋检测 383:X3
                //short rtn_qydjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[3] == 0)
                {
                    this.rtn_qydjc.Checked = true;
                }
                else
                {
                    this.rtn_qydjc.Checked = false;
                }

                //总气压检测 383:X4
                //short rtn_zqyjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[4] == 0)
                {
                    this.rtn_zqyjc.Checked = true;
                }
                else
                {
                    this.rtn_zqyjc.Checked = false;
                }

                //后有袋检测 383:X5
                //short rtn_hydjc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[5] == 0)
                {
                    this.rtn_hydjc.Checked = true;
                }
                else
                {
                    this.rtn_hydjc.Checked = false;
                }

                #endregion "第二列"

                #region "第三列"

                //装车信号 383:X7
                //short rtn_zcxh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[7] == 0)
                {
                    this.rtn_zcxh.Checked = true;
                }
                else
                {
                    this.rtn_zcxh.Checked = false;
                }

                short addressBit384 = PlcCommon.busTcpClient1.ReadInt16("384").Content;
                int[] array384 = ToBinary.IntToBinaryDESC(addressBit384);

                //抓手气缸张开 384:X1
                //short rtn_zszk = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[1] == 0)
                {
                    this.rtn_zszk.Checked = true;
                }
                else
                {
                    this.rtn_zszk.Checked = false;
                }

                //取袋气缸伸出 383:X2
                //short rtn_qdsc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array383[2] == 0)
                {
                    this.rtn_qdsc.Checked = true;
                }
                else
                {
                    this.rtn_qdsc.Checked = false;
                }

                //储袋定位传感器 384:X3
                //short rtn_cdcg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[3] == 0)
                {
                    this.rtn_cdcg.Checked = true;
                }
                else
                {
                    this.rtn_cdcg.Checked = false;
                }

                //取袋气缸缩回 384:X4
                //short rtn_qdsh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[4] == 0)
                {
                    this.rtn_qdsh.Checked = true;
                }
                else
                {
                    this.rtn_qdsh.Checked = false;
                }

                //储袋对射传感器 384:X5
                //short rtn_cdds = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[5] == 0)
                {
                    this.rtn_cdds.Checked = true;
                }
                else
                {
                    this.rtn_cdds.Checked = false;
                }

                //一级气缸升 384:X6
                //short rtn_1qgs = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[6] == 0)
                {
                    this.rtn_1qgs.Checked = true;
                }
                else
                {
                    this.rtn_1qgs.Checked = false;
                }

                //一级气缸降 384:X8
                //short rtn_1qgj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[8] == 0)
                {
                    this.rtn_1qgj.Checked = true;
                }
                else
                {
                    this.rtn_1qgj.Checked = false;
                }

                //抓手气缸夹紧 384:X10
                //short rtn_zsjj = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array384[10] == 0)
                {
                    this.rtn_zsjj.Checked = true;
                }
                else
                {
                    this.rtn_zsjj.Checked = false;
                }

                #endregion "第三列"

                #endregion "输入"

                #region "输出"

                #region "第一列"

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

                //前压袋气缸 385:X1
                //short rtn_qydqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[1] == 0)
                {
                    this.rtn_qydqg.Checked = true;
                }
                else
                {
                    this.rtn_qydqg.Checked = false;
                }

                //开袋口气缸 385:X2
                //short rtn_kdkqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[2] == 0)
                {
                    this.rtn_kdkqg.Checked = true;
                }
                else
                {
                    this.rtn_kdkqg.Checked = false;
                }

                //手/自动切换 385:X3
                //short rtn_szdqh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[3] == 0)
                {
                    this.rtn_szdqh.Checked = true;
                }
                else
                {
                    this.rtn_szdqh.Checked = false;
                }

                //前取袋气缸 385:X4
                //short rtn_qqdqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[4] == 0)
                {
                    this.rtn_qqdqg.Checked = true;
                }
                else
                {
                    this.rtn_qqdqg.Checked = false;
                }

                //包机回原点 385:X8
                //short rtn_bjhyd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[8] == 0)
                {
                    this.rtn_bjhyd.Checked = true;
                }
                else
                {
                    this.rtn_bjhyd.Checked = false;
                }

                //清包机启停信号 385:X9
                //short rtn_qbjqt = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[9] == 0)
                {
                    this.rtn_qbjqt.Checked = true;
                }
                else
                {
                    this.rtn_qbjqt.Checked = false;
                }

                //包机启动信号 385:X11
                //short rtn_bjqd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array385[11] == 0)
                {
                    this.rtn_bjqd.Checked = true;
                }
                else
                {
                    this.rtn_bjqd.Checked = false;
                }

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

                #endregion "第一列"

                #region "第二列"

                //吹气气缸 386:X1
                //short rtn_cqqg = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[1] == 0)
                {
                    this.rtn_cqqg.Checked = true;
                }
                else
                {
                    this.rtn_cqqg.Checked = false;
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

                //前压袋气缸 386:X6
                //short rtn_qydqg2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[6] == 0)
                {
                    this.rtn_qydqg2.Checked = true;
                }
                else
                {
                    this.rtn_qydqg2.Checked = false;
                }

                //报警指示灯(红) 386:X9
                //short rtn_bjh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[9] == 0)
                {
                    this.rtn_bjh.Checked = true;
                }
                else
                {
                    this.rtn_bjh.Checked = false;
                }

                //报警指示灯(黄) 386:X10
                //short rtn_bjh2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[10] == 0)
                {
                    this.rtn_bjh2.Checked = true;
                }
                else
                {
                    this.rtn_bjh2.Checked = false;
                }

                //报警指示灯(绿) 386:X11
                //short rtn_bjl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array386[11] == 0)
                {
                    this.rtn_bjl.Checked = true;
                }
                else
                {
                    this.rtn_bjl.Checked = false;
                }

                short addressBit387 = PlcCommon.busTcpClient1.ReadInt16("387").Content;
                int[] array387 = ToBinary.IntToBinaryDESC(addressBit387);

                //开袋口吸盘 387:X0
                //short rtn_kdkxp = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[0] == 0)
                {
                    this.rtn_kdkxp.Checked = true;
                }
                else
                {
                    this.rtn_kdkxp.Checked = false;
                }

                //储袋取袋气缸 387:X3
                // short rtn_cdqd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[3] == 0)
                {
                    this.rtn_cdqd.Checked = true;
                }
                else
                {
                    this.rtn_cdqd.Checked = false;
                }

                #endregion "第二列"

                #region "第三列"

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
                //short rtn_1qgs2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[5] == 0)
                {
                    this.rtn_1qgs2.Checked = true;
                }
                else
                {
                    this.rtn_1qgs2.Checked = false;
                }

                //一级气缸 降  387:X7
                //short rtn_1qgj2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[7] == 0)
                {
                    this.rtn_1qgj2.Checked = true;
                }
                else
                {
                    this.rtn_1qgj2.Checked = false;
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

                //储袋马达 387:X11
                // short rtn_cdmd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array387[11] == 0)
                {
                    this.rtn_cdmd.Checked = true;
                }
                else
                {
                    this.rtn_cdmd.Checked = false;
                }

                short addressBit381 = PlcCommon.busTcpClient1.ReadInt16("381").Content;
                int[] array381 = ToBinary.IntToBinaryDESC(addressBit381);

                //启动按钮指示灯 381:X1
                //short rtn_qdan = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[1] == 0)
                {
                    this.rtn_qdan.Checked = true;
                }
                else
                {
                    this.rtn_qdan.Checked = false;
                }

                //停止指示灯 381:X2
                //short rtn_tzan = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[2] == 0)
                {
                    this.rtn_tzan.Checked = true;
                }
                else
                {
                    this.rtn_tzan.Checked = false;
                }

                //回零完成指示灯黄 381:X3
                //short rtn_hlwc = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array381[3] == 0)
                {
                    this.rtn_hlwc.Checked = true;
                }
                else
                {
                    this.rtn_hlwc.Checked = false;
                }

                #endregion "第三列"

                #endregion "输出"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "IOController(IO控制器界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转 "

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

        private void IOControllerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}