using HslCommunication;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ServoManualForm1 : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public ServoManualForm1()
        {
            InitializeComponent();
        }

        private void ServoManualForm1_Load(object sender, EventArgs e)
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

                //short addressBit114 = PlcCommon.busTcpClient1.ReadInt16("114").Content;
                //int[] array114 = ToBinary.IntToBinaryDESC(addressBit114);

                ////故障提示 114:X3
                ////short rtn_gzzh = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[3] == 0)
                //{
                //    this.rtn_gzzh.Checked = true;
                //}
                //else
                //{
                //    this.rtn_gzzh.Checked = false;
                //}

                ////送袋伺服复位 114:X2
                ////short btn_sdfw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[2] == 0)
                //{
                //    this.btn_sdfw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdfw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdfw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdfw.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服寻零 114:X4
                ////short btn_sdxl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[4] == 0)
                //{
                //    this.btn_sdxl.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdxl.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdxl.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdxl.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服前移 114:X0
                ////short btn_sdqy = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[0] == 0)
                //{
                //    this.btn_sdqy.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdqy.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdqy.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdqy.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服后移 114:X1
                ////short btn_sdhy = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[1] == 0)
                //{
                //    this.btn_sdhy.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdhy.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdhy.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdhy.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服起始位 114:X5
                ////short btn_sdqsw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[5] == 0)
                //{
                //    this.btn_sdqsw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdqsw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdqsw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdqsw.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服待命位 114:X6
                ////short btn_sddmw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[6] == 0)
                //{
                //    this.btn_sddmw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sddmw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sddmw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sddmw.ForeColor = System.Drawing.Color.White;
                //}

                ////送袋伺服到达位 114:X7
                ////short btn_sdddw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[7] == 0)
                //{
                //    this.btn_sdddw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sdddw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sdddw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sdddw.ForeColor = System.Drawing.Color.White;
                //}

                //送袋伺服当前位置 126
                short sddqwz = PlcCommon.busTcpClient1.ReadInt16("126").Content;
                tbx_sddqwz.Text = (sddqwz + "mm").ToString();

                //送袋到位延时 213
                short sdys = PlcCommon.busTcpClient1.ReadInt16("213").Content;
                tbx_sdys.Text = (sdys + "ms").ToString();

                //送袋伺服速度1 116
                short sdsd1 = PlcCommon.busTcpClient1.ReadInt16("116").Content;
                tbx_sdsd1.Text = (sdsd1).ToString();

                //送袋伺服起始位    115
                short sdqsw = PlcCommon.busTcpClient1.ReadInt16("115").Content;
                tbx_sdqsw.Text = (sdqsw + "mm").ToString();

                //送袋伺服速度2 118
                short sdsd2 = PlcCommon.busTcpClient1.ReadInt16("118").Content;
                tbx_sdsd2.Text = (sdsd2).ToString();

                //送袋伺服待命位 117
                short sddmw = PlcCommon.busTcpClient1.ReadInt16("117").Content;
                tbx_sddmw.Text = (sddmw + "mm").ToString();

                //送袋伺服速度3  120
                short sdsd3 = PlcCommon.busTcpClient1.ReadInt16("120").Content;
                tbx_sdsd3.Text = (sdsd3).ToString();

                //送袋伺服到达位  119
                short sdddw = PlcCommon.busTcpClient1.ReadInt16("119").Content;
                tbx_sdddw.Text = (sdddw + "mm").ToString();

                #endregion "送袋伺服"

                #region "升降伺服"

                ////升降伺服复位 114:X10
                ////short btn_sjfw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[10] == 0)
                //{
                //    this.btn_sjfw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sjfw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sjfw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sjfw.ForeColor = System.Drawing.Color.White;
                //}
                ////升降伺服寻零 114:X12
                ////short btn_sjxl = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[12] == 0)
                //{
                //    this.btn_sjxl.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sjxl.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sjxl.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sjxl.ForeColor = System.Drawing.Color.White;
                //}

                ////升降伺服上移 114:X8
                ////short btn_sjsy = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[8] == 0)
                //{
                //    this.btn_sjsy.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sjsy.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sjsy.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sjsy.ForeColor = System.Drawing.Color.White;
                //}

                ////升降伺服下移 114:X9
                ////short btn_sjxy = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[9] == 0)
                //{
                //    this.btn_sjxy.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sjxy.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sjxy.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sjxy.ForeColor = System.Drawing.Color.White;
                //}

                ////升降伺服回位 114:X13
                ////short btn_sjhw = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[13] == 0)
                //{
                //    this.btn_sjhw.BackColor = System.Drawing.Color.DarkGray;
                //    this.btn_sjhw.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    this.btn_sjhw.BackColor = System.Drawing.Color.Lime;
                //    this.btn_sjhw.ForeColor = System.Drawing.Color.White;
                //}

                ////故障提示 114:X11
                //// short rtn_gzzh2 = PlcCommon.busTcpClient1.ReadInt16("").Content;
                //if (array114[11] == 0)
                //{
                //    this.rtn_gzzh2.Checked = true;
                //}
                //else
                //{
                //    this.rtn_gzzh2.Checked = false;
                //}

                //送袋伺服当前位置 139
                short sjdqwz = PlcCommon.busTcpClient1.ReadInt16("139").Content;
                tbx_sjdqwz.Text = (sddqwz + "mm").ToString();

                //升降伺服回位 130
                short sjhw = PlcCommon.busTcpClient1.ReadInt16("130").Content;
                tbx_sjhw.Text = (sdys + "mm").ToString();

                //升降伺服速度1  131
                short sjsd1 = PlcCommon.busTcpClient1.ReadInt16("131").Content;
                tbx_sjsd1.Text = (sjsd1).ToString();

                //升降伺服递升高度    132
                short sjdsgd = PlcCommon.busTcpClient1.ReadInt16("132").Content;
                tbx_sjdsgd.Text = (sjdsgd + "mm").ToString();

                //升降伺服速度2 133
                short sjsd2 = PlcCommon.busTcpClient1.ReadInt16("133").Content;
                tbx_sjsd2.Text = (sjsd2).ToString();

                #endregion "升降伺服"

                #region "翻袋伺服"

                //翻袋伺服当前位置 147
                short fddqwz = PlcCommon.busTcpClient1.ReadInt16("147").Content;
                tbx_fddqwz.Text = (fddqwz).ToString();

                //翻袋伺服零位偏移 170
                short fdlwpy = PlcCommon.busTcpClient1.ReadInt16("170").Content;
                tbx_fdlwpy.Text = (fdlwpy).ToString();

                #endregion "翻袋伺服"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "页面跳转 "

        private void Btn_ManualForm_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ManualForm manual = new ManualForm();
            this.Hide();
            manual.ShowDialog();
            this.Dispose();
        }

        private void Btn_ServoManualForm2_Click(object sender, EventArgs e)
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

        #region "送袋伺服"

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
        /// 送袋到位延时 213
        /// </summary>
        private void tbx_sdys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("213", short.Parse(tbx_sdys.Text.Replace("ms", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋到位延时修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///  送袋伺服速度1 116
        /// </summary>
        private void tbx_sdsd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("116", short.Parse(tbx_sdsd1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服速度1修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋伺服起始位    115
        /// </summary>
        private void tbx_sdqsw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("115", short.Parse(tbx_sdqsw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服起始位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋伺服速度2 118
        /// </summary>
        private void tbx_sdsd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("118", short.Parse(tbx_sdsd2.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服速度2修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋伺服待命位 117
        /// </summary>
        private void tbx_sddmw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("117", short.Parse(tbx_sddmw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服待命位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋伺服速度3  120
        /// </summary>
        private void tbx_sdsd3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("120", short.Parse(tbx_sdsd3.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服速度3修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 送袋伺服到达位  119
        /// </summary>
        private void tbx_sdddw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("120", short.Parse(tbx_sdddw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服到达位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "送袋伺服"

        #region "送袋伺服"

        /// <summary>
        ///  升降伺服回位 130
        /// </summary>
        private void tbx_sjhw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("130", short.Parse(tbx_sjhw.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服回位修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///  升降伺服速度1  131
        /// </summary>
        private void tbx_sjsd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("131", short.Parse(tbx_sjsd1.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服速度1修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///  升降伺服递升高度    132
        /// </summary>
        private void tbx_sjdsgd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("132", short.Parse(tbx_sjdsgd.Text.Replace("mm", "")));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服递升高度修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        ///  升降伺服速度2 133
        /// </summary>
        private void tbx_sjsd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("133", short.Parse(tbx_sjsd2.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服速度2修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "送袋伺服"

        #region "翻袋伺服"

        /// <summary>
        /// 翻袋伺服当前位置 147
        /// </summary>
        private void tbx_fddqwz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("147", short.Parse(tbx_sjhw.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "翻袋伺服当前位置修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        /// <summary>
        /// 翻袋伺服零位偏移 170
        /// </summary>
        private void tbx_fdlwpy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OperateResult operate = PlcCommon.busTcpClient1.Write("170", short.Parse(tbx_sjhw.Text));
                if (!operate.IsSuccess)
                {
                    Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "翻袋伺服零位偏移修改失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                    return;
                }
                PlcCommon.readVar = true;
                this.ActiveControl = labjiaodian;
            }
        }

        #endregion "翻袋伺服"

        #endregion "回车事件"

        #region "按钮点击事件"

        #region "送袋伺服"

        /// <summary>
        ///送袋伺服复位 114:X2
        /// </summary>
        private void btn_sdfw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 2, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送到伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdfw.BackColor = System.Drawing.Color.Lime;
                btn_sdfw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服复位 114:X2
        /// </summary>
        private void btn_sdfw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 2, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdfw.BackColor = System.Drawing.Color.DarkGray;
                btn_sdfw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服寻零 114:X4
        /// </summary>
        private void btn_sdxl_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 4, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdxl.BackColor = System.Drawing.Color.Lime;
                btn_sdxl.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服寻零 114:X4
        /// </summary>
        private void btn_sdxl_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 4, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdxl.BackColor = System.Drawing.Color.DarkGray;
                btn_sdxl.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服前移 114:X0
        /// </summary>
        private void btn_sdqy_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 0, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服前移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdqy.BackColor = System.Drawing.Color.Lime;
                btn_sdqy.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服前移 114:X0
        /// </summary>
        private void btn_sdqy_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 0, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服前移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdqy.BackColor = System.Drawing.Color.DarkGray;
                btn_sdqy.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服后移 114:X1
        /// </summary>
        private void btn_sdhy_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 1, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服后移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdhy.BackColor = System.Drawing.Color.Lime;
                btn_sdhy.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服后移 114:X1
        /// </summary>
        private void btn_sdhy_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 1, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服后移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdhy.BackColor = System.Drawing.Color.DarkGray;
                btn_sdhy.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服起始位 114:X5
        /// </summary>
        private void btn_sdqsw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 5, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服起始位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdqsw.BackColor = System.Drawing.Color.Lime;
                btn_sdqsw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服起始位 114:X5
        /// </summary>
        private void btn_sdqsw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 5, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服起始位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdqsw.BackColor = System.Drawing.Color.DarkGray;
                btn_sdqsw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服待命位 114:X6
        /// </summary>
        private void btn_sddmw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 6, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sddmw.BackColor = System.Drawing.Color.Lime;
                btn_sddmw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服待命位 114:X6
        /// </summary>
        private void btn_sddmw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 6, 0));

            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服待命位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sddmw.BackColor = System.Drawing.Color.DarkGray;
                btn_sddmw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 送袋伺服到达位 114:X7
        /// </summary>
        private void btn_sdddw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 7, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdddw.BackColor = System.Drawing.Color.Lime;
                btn_sdddw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 送袋伺服到达位 114:X7
        /// </summary>
        private void btn_sdddw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 7, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "送袋伺服到达位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sdddw.BackColor = System.Drawing.Color.DarkGray;
                btn_sdddw.ForeColor = System.Drawing.Color.Black;
            }
        }

        #endregion "送袋伺服"

        #region "升降伺服"

        /// <summary>
        /// 升降伺服复位 114:X10
        /// </summary>
        private void btn_sjfw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 10, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjfw.BackColor = System.Drawing.Color.Lime;
                btn_sjfw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 升降伺服复位 114:X10
        /// </summary>
        private void btn_sjfw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 10, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjfw.BackColor = System.Drawing.Color.DarkGray;
                btn_sjfw.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 升降伺服寻零 114:X12
        /// </summary>
        private void btn_sjxl_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 12, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjxl.BackColor = System.Drawing.Color.Lime;
                btn_sjxl.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 升降伺服寻零 114:X12
        /// </summary>
        private void btn_sjxl_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 12, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服寻零按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjxl.BackColor = System.Drawing.Color.DarkGray;
                btn_sjxl.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 升降伺服上移 114:X8
        /// </summary>
        private void btn_sjsy_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 8, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服上移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjsy.BackColor = System.Drawing.Color.Lime;
                btn_sjsy.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 升降伺服上移 114:X8
        /// </summary>
        private void btn_sjsy_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 8, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服上移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjsy.BackColor = System.Drawing.Color.DarkGray;
                btn_sjsy.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 升降伺服下移 114:X9
        /// </summary>
        private void btn_sjxy_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 9, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服下移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjxy.BackColor = System.Drawing.Color.Lime;
                btn_sjxy.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 升降伺服下移 114:X9
        /// </summary>
        private void btn_sjxy_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 9, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服下移按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjxy.BackColor = System.Drawing.Color.DarkGray;
                btn_sjxy.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 升降伺服回位 114:X13
        /// </summary>
        private void btn_sjhw_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 13, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服回位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjhw.BackColor = System.Drawing.Color.Lime;
                btn_sjhw.ForeColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 升降伺服回位 114:X13
        /// </summary>
        private void btn_sjhw_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("114", ToBinary.AddressBitToBinary("114", 13, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ServoManual(伺服手动1界面)" + "\r\n" + "升降伺服回位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                btn_sjhw.BackColor = System.Drawing.Color.DarkGray;
                btn_sjhw.ForeColor = System.Drawing.Color.Black;
            }
        }

        #endregion "升降伺服"

        #endregion "按钮点击事件"

        private void ServoManualForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            Environment.Exit(0);
        }
    }
}