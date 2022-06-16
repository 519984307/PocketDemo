using HslCommunication;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ParaMeterForm3 : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public ParaMeterForm3()
        {
            InitializeComponent();
        }

        private void ParaMeterForm3_Load(object sender, EventArgs e)
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
                    ReadPara();
                }
            }
        }

        public void ReadPara()
        {
            try
            {
                #region "嘴开关"

                short addressBit362 = PlcCommon.busTcpClient1.ReadInt16("362").Content;
                int[] array362 = ToBinary.IntToBinaryDESC(addressBit362);

                //1#开 362:X1
                // short btn_k1 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[1] == 0)
                {
                    this.btn_k1.BackColor = System.Drawing.Color.Lime;
                    this.btn_k1.ForeColor = System.Drawing.Color.Black;
                    this.btn_k1.Text = "1#开";
                }
                else
                {
                    this.btn_k1.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k1.ForeColor = System.Drawing.Color.White;
                    this.btn_k1.Text = "1#关";
                }

                //2#开 362:X2
                //short btn_k2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[2] == 0)
                {
                    this.btn_k2.BackColor = System.Drawing.Color.Lime;
                    this.btn_k2.ForeColor = System.Drawing.Color.Black;
                    this.btn_k2.Text = "2#开";
                }
                else
                {
                    this.btn_k2.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k2.ForeColor = System.Drawing.Color.White;
                    this.btn_k2.Text = "2#关";
                }

                //3#开 362:X3
                //short btn_k3 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[3] == 0)
                {
                    this.btn_k3.BackColor = System.Drawing.Color.Lime;
                    this.btn_k3.ForeColor = System.Drawing.Color.Black;
                    this.btn_k3.Text = "3#开";
                }
                else
                {
                    this.btn_k3.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k3.ForeColor = System.Drawing.Color.White;
                    this.btn_k3.Text = "3#关";
                }

                //4#开 362:X4
                //short btn_k4 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[4] == 0)
                {
                    this.btn_k4.BackColor = System.Drawing.Color.Lime;
                    this.btn_k4.ForeColor = System.Drawing.Color.Black;
                    this.btn_k4.Text = "4#开";
                }
                else
                {
                    this.btn_k4.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k4.ForeColor = System.Drawing.Color.White;
                    this.btn_k4.Text = "4#关";
                }

                //5#开 362:X5
                //short btn_k5 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[5] == 0)
                {
                    this.btn_k5.BackColor = System.Drawing.Color.Lime;
                    this.btn_k5.ForeColor = System.Drawing.Color.Black;
                    this.btn_k5.Text = "5#开";
                }
                else
                {
                    this.btn_k5.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k5.ForeColor = System.Drawing.Color.White;
                    this.btn_k5.Text = "5#关";
                }

                //6#开 362:X6
                // short btn_k6 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[6] == 0)
                {
                    this.btn_k6.BackColor = System.Drawing.Color.Lime;
                    this.btn_k6.ForeColor = System.Drawing.Color.Black;
                    this.btn_k6.Text = "6#开";
                }
                else
                {
                    this.btn_k6.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k6.ForeColor = System.Drawing.Color.White;
                    this.btn_k6.Text = "6#关";
                }

                //7#开 362:X7
                //short btn_k7 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[7] == 0)
                {
                    this.btn_k7.BackColor = System.Drawing.Color.Lime;
                    this.btn_k7.ForeColor = System.Drawing.Color.Black;
                    this.btn_k7.Text = "7#开";
                }
                else
                {
                    this.btn_k7.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k7.ForeColor = System.Drawing.Color.White;
                    this.btn_k7.Text = "7#关";
                }

                //8#开 362:X8
                //short btn_k8 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array362[8] == 0)
                {
                    this.btn_k8.BackColor = System.Drawing.Color.Lime;
                    this.btn_k8.ForeColor = System.Drawing.Color.Black;
                    this.btn_k8.Text = "8#开";
                }
                else
                {
                    this.btn_k8.BackColor = System.Drawing.Color.DarkGray;
                    this.btn_k8.ForeColor = System.Drawing.Color.White;
                    this.btn_k8.Text = "8#关";
                }

                #endregion "嘴开关"

                #region "气缸参数"

                short addressBit200 = PlcCommon.busTcpClient1.ReadInt16("200").Content;
                int[] array200 = ToBinary.IntToBinaryDESC(addressBit200);

                //120吨时气缸参数 200:X1
                //short lab_120T = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array200[1] == 0)
                {
                    this.lab_120T.BackColor = System.Drawing.Color.Lime;
                    this.lab_120T.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.lab_120T.BackColor = System.Drawing.Color.Red;
                    this.lab_120T.ForeColor = System.Drawing.Color.Black;
                }

                //110吨时气缸参数 200:X2
                //short lab_110T = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array200[2] == 0)
                {
                    this.lab_110T.BackColor = System.Drawing.Color.Lime;
                    this.lab_110T.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.lab_110T.BackColor = System.Drawing.Color.Red;
                    this.lab_110T.ForeColor = System.Drawing.Color.Black;
                }

                //100吨时气缸参数 200:X3
                //short lab_100T = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array200[3] == 0)
                {
                    this.lab_100T.BackColor = System.Drawing.Color.Lime;
                    this.lab_100T.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.lab_100T.BackColor = System.Drawing.Color.Red;
                    this.lab_100T.ForeColor = System.Drawing.Color.Black;
                }

                //90吨时气缸参数 200:X4
                //short lab_90T = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array200[4] == 0)
                {
                    this.lab_90T.BackColor = System.Drawing.Color.Lime;
                    this.lab_90T.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.lab_90T.BackColor = System.Drawing.Color.Red;
                    this.lab_90T.ForeColor = System.Drawing.Color.Black;
                }

                #endregion "气缸参数"

                #region "夹紧气缸夹紧位"

                //夹紧气缸夹紧位 110-120吨时气缸参数 180
                short jj120T = PlcCommon.busTcpClient1.ReadInt16("180").Content;
                tbx_jj120T.Text = (jj120T + "").ToString();

                //夹紧气缸夹紧位 100-110吨时气缸参数 181
                short jj110T = PlcCommon.busTcpClient1.ReadInt16("184").Content;
                tbx_jj110T.Text = (jj110T + "").ToString();

                //夹紧气缸夹紧位 90-100吨时气缸参数 182
                short jj100T = PlcCommon.busTcpClient1.ReadInt16("188").Content;
                tbx_jj100T.Text = (jj100T + "").ToString();

                //夹紧气缸夹紧位 80-90吨时气缸参数 183
                short jj90T = PlcCommon.busTcpClient1.ReadInt16("192").Content;
                tbx_jj90T.Text = (jj90T + "").ToString();

                #endregion "夹紧气缸夹紧位"

                #region "夹紧气缸释放位"

                //夹紧气缸释放位 110-120吨时气缸参数
                short sf120T = PlcCommon.busTcpClient1.ReadInt16("181").Content;
                tbx_sf120T.Text = (sf120T + "").ToString();

                //夹紧气缸释放位 100-110吨时气缸参数
                short sf110T = PlcCommon.busTcpClient1.ReadInt16("185").Content;
                tbx_sf110T.Text = (sf110T + "").ToString();

                //夹紧气缸释放位 90-100吨时气缸参数
                short sf100T = PlcCommon.busTcpClient1.ReadInt16("189").Content;
                tbx_sf100T.Text = (sf100T + "").ToString();

                //夹紧气缸释放位 80-90吨时气缸参数
                short sf90T = PlcCommon.busTcpClient1.ReadInt16("193").Content;
                tbx_sf90T.Text = (sf90T + "").ToString();

                #endregion "夹紧气缸释放位"

                #region "插袋气缸开位置"

                //插袋气缸开位置 110-120吨时气缸参数
                short cdk120t = PlcCommon.busTcpClient1.ReadInt16("182").Content;
                tbx_cdk120T.Text = (cdk120t + "").ToString();

                //插袋气缸开位置 100-110吨时气缸参数
                short cdk110T = PlcCommon.busTcpClient1.ReadInt16("186").Content;
                tbx_cdk110T.Text = (cdk110T + "").ToString();

                //插袋气缸开位置 90-100吨时气缸参数
                short cdk100T = PlcCommon.busTcpClient1.ReadInt16("190").Content;
                tbx_cdk100T.Text = (cdk100T + "").ToString();

                //插袋气缸开位置 80-90吨时气缸参数
                short cdk90T = PlcCommon.busTcpClient1.ReadInt16("194").Content;
                tbx_cdk90T.Text = (cdk90T + "").ToString();

                #endregion "插袋气缸开位置"

                #region "插袋气缸关位置"

                //插袋气缸关位置 110-120吨时气缸参数
                short cdg120T = PlcCommon.busTcpClient1.ReadInt16("183").Content;
                tbx_cdg120T.Text = (cdg120T + "").ToString();

                //插袋气缸关位置 100-110吨时气缸参数
                short cdg110T = PlcCommon.busTcpClient1.ReadInt16("187").Content;
                tbx_cdg110T.Text = (cdg110T + "").ToString();

                //插袋气缸关位置 90-100吨时气缸参数
                short cdg100T = PlcCommon.busTcpClient1.ReadInt16("191").Content;
                tbx_cdg100T.Text = (cdg100T + "").ToString();

                //插袋气缸关位置 80-90吨时气缸参数
                short cdg90T = PlcCommon.busTcpClient1.ReadInt16("195").Content;
                tbx_cdg90T.Text = (cdg90T + "").ToString();

                #endregion "插袋气缸关位置"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转 "

        /// <summary>
        /// 参数1按钮
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

        #region "按钮"

        /// <summary>
        ///  1#开  362:X1
        /// </summary>
        private void btn_k1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k1.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 1, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "1#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k1.BackColor = System.Drawing.Color.DarkGray;
                        btn_k1.ForeColor = System.Drawing.Color.White;
                        btn_k1.Text = "1#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 1, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "1#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k1.BackColor = System.Drawing.Color.Lime;
                        btn_k1.ForeColor = System.Drawing.Color.Black;
                        btn_k1.Text = "1#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "1#按钮操作失败：" + ex.Message);
                return;
            }
        }

        /// <summary>
        ///  2#开  362:X2
        /// </summary>
        private void btn_k2_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k2.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 2, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "2#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k2.BackColor = System.Drawing.Color.DarkGray;
                        btn_k2.ForeColor = System.Drawing.Color.White;
                        btn_k2.Text = "2#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 2, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "2#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k2.BackColor = System.Drawing.Color.Lime;
                        btn_k2.ForeColor = System.Drawing.Color.Black;
                        btn_k2.Text = "1#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "2#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  3#开  362:X3
        /// </summary>
        private void btn_k3_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k3.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 3, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "3#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k3.BackColor = System.Drawing.Color.DarkGray;
                        btn_k3.ForeColor = System.Drawing.Color.White;
                        btn_k3.Text = "3#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 3, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "3#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k3.BackColor = System.Drawing.Color.Lime;
                        btn_k3.ForeColor = System.Drawing.Color.Black;
                        btn_k3.Text = "3#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "3#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  4#开  362:X4
        /// </summary>
        private void btn_k4_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k4.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 4, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "4#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k4.BackColor = System.Drawing.Color.DarkGray;
                        btn_k4.ForeColor = System.Drawing.Color.White;
                        btn_k4.Text = "4#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 4, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "4#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k4.BackColor = System.Drawing.Color.Lime;
                        btn_k4.ForeColor = System.Drawing.Color.Black;
                        btn_k4.Text = "4#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "4#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  5#开  362:X5
        /// </summary>
        private void btn_k5_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k5.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 5, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "5#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k5.BackColor = System.Drawing.Color.DarkGray;
                        btn_k5.ForeColor = System.Drawing.Color.White;
                        btn_k5.Text = "5#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 5, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "5#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k5.BackColor = System.Drawing.Color.Lime;
                        btn_k5.ForeColor = System.Drawing.Color.Black;
                        btn_k5.Text = "5#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "5#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  6#开  362:X6
        /// </summary>
        private void btn_k6_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k6.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 6, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "6#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k6.BackColor = System.Drawing.Color.DarkGray;
                        btn_k6.ForeColor = System.Drawing.Color.White;
                        btn_k6.Text = "6#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 6, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "6#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k6.BackColor = System.Drawing.Color.Lime;
                        btn_k6.ForeColor = System.Drawing.Color.Black;
                        btn_k6.Text = "6#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "6#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  7#开  362:X7
        /// </summary>
        private void btn_k7_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k7.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 7, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "7#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k7.BackColor = System.Drawing.Color.DarkGray;
                        btn_k7.ForeColor = System.Drawing.Color.White;
                        btn_k7.Text = "7#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 7, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "7#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k7.BackColor = System.Drawing.Color.Lime;
                        btn_k7.ForeColor = System.Drawing.Color.Black;
                        btn_k7.Text = "7#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "7#按钮操作失败：" + ex.Message);
            }
        }

        /// <summary>
        ///  8#开  362:X8
        /// </summary>
        private void btn_k8_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_k8.BackColor == System.Drawing.Color.Lime)
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 8, 1));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "8#关按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k8.BackColor = System.Drawing.Color.DarkGray;
                        btn_k8.ForeColor = System.Drawing.Color.White;
                        btn_k8.Text = "8#关";
                    }
                }
                else
                {
                    OperateResult operate = PlcCommon.busTcpClient1.Write("362", ToBinary.AddressBitToBinary("362", 8, 0));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "8#开按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        btn_k8.BackColor = System.Drawing.Color.Lime;
                        btn_k8.ForeColor = System.Drawing.Color.Black;
                        btn_k8.Text = "8#开";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "8#按钮操作失败：" + ex.Message);
            }
        }

        #endregion "按钮"

        #region "回车事件"

        #region "100-120吨时气缸参数"

        //夹紧气缸夹紧位 110-120吨时气缸参数 180
        private void tbx_jj120T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("180", short.Parse(tbx_jj120T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "120T夹紧气缸夹紧位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //夹紧气缸释放位 110-120吨时气缸参数 181
        private void tbx_sf120T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("181", short.Parse(tbx_sf120T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "120T夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸开位置 110-120吨时气缸参数 182
        private void tbx_cdk120T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("182", short.Parse(tbx_cdk120T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "120T插袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸关位置 110-120吨时气缸参数 183
        private void tbx_cdg120T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("183", short.Parse(tbx_cdg120T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "120T插袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "100-120吨时气缸参数"

        #region "100-110吨时气缸参数"

        //夹紧气缸夹紧位 100-110吨时气缸参数 184
        private void tbx_jj110T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("184", short.Parse(tbx_jj110T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "110T夹紧气缸夹紧位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //夹紧气缸释放位 100-110吨时气缸参数 185
        private void tbx_sf110T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("185", short.Parse(tbx_sf110T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "110T夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸开位置 100-110吨时气缸参数 186
        private void tbx_cdk110T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("186", short.Parse(tbx_cdk110T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "110T插袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸关位置 100-110吨时气缸参数 187
        private void tbx_cdg110T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("187", short.Parse(tbx_cdg110T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "110T插袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "100-110吨时气缸参数"

        #region "90-100吨时气缸参数"

        //夹紧气缸夹紧位 90-100吨时气缸参数 188
        private void tbx_jj100T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("188", short.Parse(tbx_jj100T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "100T夹紧气缸夹紧位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

        //夹紧气缸释放位 90-100吨时气缸参数 189
        private void tbx_sf100T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("189", short.Parse(tbx_sf100T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "100T夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

        //插袋气缸开位置 90-100吨时气缸参数 190
        private void tbx_cdk100T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("190", short.Parse(tbx_cdk100T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "100T插袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

        //插袋气缸关位置 90-100吨时气缸参数 191
        private void tbx_cdg100T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("191", short.Parse(tbx_cdg100T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "100T插袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
            }
        }

        #endregion "90-100吨时气缸参数"

        #region "80-90吨时气缸参数"

        //夹紧气缸夹紧位 80-90吨时气缸参数 192
        private void tbx_jj90T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("192", short.Parse(tbx_jj90T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "90T夹紧气缸夹紧位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //夹紧气缸释放位 80-90吨时气缸参数 193
        private void tbx_sf90T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("193", short.Parse(tbx_sf90T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "90T夹紧气缸释放位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸开位置 80-90吨时气缸参数 194
        private void tbx_cdk90T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("194", short.Parse(tbx_cdk90T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "90T插袋气缸开位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        //插袋气缸关位置 80-90吨时气缸参数 195
        private void tbx_cdg90T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("195", short.Parse(tbx_cdg90T.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ParaMeter3(参数3界面)" + "\r\n" + "90T插袋气缸关位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "80-90吨时气缸参数"

        #endregion "回车事件"

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

        private void ParaMeterForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}