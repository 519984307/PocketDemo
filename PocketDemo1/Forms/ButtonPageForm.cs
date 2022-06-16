using HslCommunication;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class ButtonPageForm : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;
        public ButtonPageForm()
        {
            InitializeComponent();
        }

        private void ButtonPageForm_Load(object sender, EventArgs e)
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
                #region "参数"

                //手/自动 395:X1
                //short Btn_ManualAutomatic = PlcCommon.busTcpClient1.ReadInt16("").Content;
                short addressBit395 = PlcCommon.busTcpClient1.ReadInt16("395").Content;
                int[] array395 = ToBinary.IntToBinaryDESC(addressBit395);
                if (array395[1] == 0)
                {
                    this.Btn_ManualAutomatic.BackColor = System.Drawing.Color.Lime;
                    this.Btn_ManualAutomatic.ForeColor = System.Drawing.Color.White;
                    this.Btn_ManualAutomatic.Text = "手动";
                }
                else
                {
                    this.Btn_ManualAutomatic.BackColor = System.Drawing.Color.Red;
                    this.Btn_ManualAutomatic.ForeColor = System.Drawing.Color.White;
                    this.Btn_ManualAutomatic.Text = "自动";
                }

                #endregion "参数"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        #region "按钮点击事件"

        /// <summary>
        /// 手自动按钮
        /// </summary>
        private void Btn_ManualAutomatic_Click(object sender, EventArgs e)
        {
            try
            {
                // 395:X1
                short addressBit395 = PlcCommon.busTcpClient1.ReadInt16("395").Content;
                int[] array395 = ToBinary.IntToBinaryDESC(addressBit395);

                if (Btn_ManualAutomatic.BackColor == System.Drawing.Color.Lime)
                {
                    array395[1] = 1;
                    Array.Reverse(array395);
                    StringBuilder builder = new StringBuilder(addressBit395);
                    foreach (var item in array395)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("395", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "自动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        Btn_ManualAutomatic.BackColor = System.Drawing.Color.Red;
                        Btn_ManualAutomatic.ForeColor = System.Drawing.Color.White;
                        Btn_ManualAutomatic.Text = "自动";
                    }
                }
                else
                {
                    array395[1] = 0;
                    Array.Reverse(array395);
                    StringBuilder builder = new StringBuilder(addressBit395);
                    foreach (var item in array395)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("395", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "手动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        Btn_ManualAutomatic.BackColor = System.Drawing.Color.Lime;
                        Btn_ManualAutomatic.ForeColor = System.Drawing.Color.White;
                        Btn_ManualAutomatic.Text = "手动";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "手自动操作失败：" + ex.Message);
            }
        }

        #endregion "按钮点击事件"

        #region "页面跳转"

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

        #region "按钮点击事件"

        /// <summary>
        /// 复位按钮 360:X3
        /// </summary>
        private void Btn_Reset_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 3, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
        }

        /// <summary>
        /// 复位按钮 360:X3
        /// </summary>
        private void Btn_Reset_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 3, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "复位按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
        }

        /// <summary>
        /// 启动按钮 360:X2
        /// </summary>
        private void Btn_Startover_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 2, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "启动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Startover.BackColor = System.Drawing.Color.Lime;
            }
        }

        /// <summary>
        /// 启动按钮 360:X2
        /// </summary>
        private void Btn_Startover_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 2, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "启动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Startover.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        /// <summary>
        /// 停止按钮 360:X1
        /// </summary>
        private void Btn_Cease_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 1, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "停止按钮操作失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Cease.BackColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// 停止按钮 360:X1
        /// </summary>
        private void Btn_Cease_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 1, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "停止按钮操作失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Cease.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        /// <summary>
        /// 原点 360:X4
        /// </summary>
        private void Btn_Origin_MouseDown(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 4, 1));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "原点按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Origin.BackColor = System.Drawing.Color.Yellow;
            }
        }

        /// <summary>
        /// 原点 360:X4
        /// </summary>
        private void Btn_Origin_MouseUp(object sender, MouseEventArgs e)
        {
            OperateResult operate = PlcCommon.busTcpClient1.Write("360", ToBinary.AddressBitToBinary("360", 4, 0));
            if (!operate.IsSuccess)
            {
                Log.GetLogMessage("PlcLog", "ButtonPage(按钮界面)" + "\r\n" + "原点按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                return;
            }
            else
            {
                Btn_Origin.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        #endregion "按钮点击事件"

        private void ButtonPageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            System.Environment.Exit(0);
        }
    }
}