using HslCommunication;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CustomControlH.Forms;
namespace PocketDemo1
{
    public partial class HomePage : Form
    {
        private delegate void SetDataDelegate();

        public Thread thread;
        public System.Timers.Timer timer;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            if (PlcCommon.variable == false)
            {
                DisableButton();
            }

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
                if (PlcCommon.variable == true)
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
        }

        public void ReadPara()
        {
            try
            {
                short addressBit372 = PlcCommon.busTcpClient1.ReadInt16("372").Content;
                int[] array372 = ToBinary.IntToBinaryDESC(addressBit372);
                //储袋点动 372:X0

                //short Btn_Cddd = PlcCommon.busTcpClient1.ReadInt16("").Content;
                if (array372[0] == 0)
                {
                    this.Btn_Cddd.BackColor = System.Drawing.Color.DarkGray;
                    this.Btn_Cddd.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.Btn_Cddd.BackColor = System.Drawing.Color.Lime;
                    this.Btn_Cddd.ForeColor = System.Drawing.Color.White;
                }

                //包机速度 302
                short bJzs = PlcCommon.busTcpClient1.ReadInt16("302").Content;
                tbx_Bjzs.Text = (bJzs + "吨/小时").ToString();

                //主轴位置 19
                short zzwz = PlcCommon.busTcpClient1.ReadInt16("19").Content;
                tbx_zzwz.Text = (zzwz).ToString();

                //摆臂角度    20
                short bbjd = PlcCommon.busTcpClient1.ReadInt16("20").Content;
                tbx_bbjd.Text = (bbjd).ToString();

                //角调整角度
                short jtzjd = PlcCommon.busTcpClient1.ReadInt16("21").Content;
                tbx_jtzjd.Text = (jtzjd).ToString();

                //摆臂电流
                int bbdl = PlcCommon.busTcpClient1.ReadInt32("346").Content;
                tbx_bbdl.Text = (bbdl + "mA").ToString();

                //储袋点动

                //byte[] cddd=PlcCommon.busTcpClient1.Read("",)
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "HomePage(主页界面)" + "\r\n" + "读取参数失败：" + ex.Message);
            }
        }

        #endregion "读取方法"

        /// <summary>
        /// 打开按钮，打开plc,启用按键
        /// </summary>
        private void Btn_OpenPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlcCommon.PlcConnect() == true)
                {
                    PlcCommon.variable = true;
                    //
                    EnableButton();
                    FrmDialog.ShowDialog(this, "PLC连接成功！", "打开提示",false,true,true);

                    //MessageBox.Show("PLC连接成功！", "提示");
                }
                else
                {
                    MessageBox.Show("PLC连接失败！", "提示");
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "HomePage(主页界面)" + "\r\n" + "打开按钮操作失败：" + ex.Message);
            }

            //
            //ReadPara();
        }

        /// <summary>
        /// 关闭按钮，关闭plc,弃用按键
        /// </summary>
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (PlcCommon.variable == true)
            {
                DisableButton();
                PlcCommon.variable = false;
                PlcCommon.busTcpClient1.ConnectClose();
            }
        }

        #region "页面跳转 "

        /// <summary>
        /// 按钮页面
        /// </summary>
        private void Btn_BtnPage_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ButtonPageForm buttonPageForm = new ButtonPageForm();
            this.Hide();
            buttonPageForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 主页页面
        /// </summary>
        private void Btn_HomePage_Click(object sender, EventArgs e)
        {
            //HomePage homePage = new HomePage();
            //this.Hide();
            //homePage.ShowDialog();
            //this.Dispose();
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

        #region "按钮方法"

        /// <summary>
        /// 按钮禁用
        /// </summary>
        public void DisableButton()
        {
            Btn_ShowBook.Enabled = false;
            Btn_Cddd.Enabled = false;
            Btn_HomePage.Enabled = false;
            Btn_Manual.Enabled = false;
            Btn_AutoMatic.Enabled = false;
            Btn_ParaMeter.Enabled = false;
            Btn_Warning.Enabled = false;
            Btn_Diagnosis.Enabled = false;
            Btn_Administration.Enabled = false;
            Btn_BtnPage.Enabled = false;
        }

        /// <summary>
        /// 按钮启用
        /// </summary>
        public void EnableButton()
        {
            Btn_ShowBook.Enabled = true;
            Btn_Cddd.Enabled = true;
            Btn_HomePage.Enabled = true;
            Btn_Manual.Enabled = true;
            Btn_AutoMatic.Enabled = true;
            Btn_ParaMeter.Enabled = true;
            Btn_Warning.Enabled = true;
            Btn_Diagnosis.Enabled = true;
            Btn_Administration.Enabled = true;
            Btn_BtnPage.Enabled = true;
        }

        #endregion "按钮方法"

        /// <summary>
        ///  储袋点动
        /// </summary>
        private void Btn_Cddd_Click(object sender, EventArgs e)
        {
            try
            {
                short addressBit372 = PlcCommon.busTcpClient1.ReadInt16("372").Content;
                int[] array372 = ToBinary.IntToBinaryDESC(addressBit372);

                //372:X0
                if (Btn_Cddd.BackColor == System.Drawing.Color.DarkGray)
                {
                    array372[0] = 1;
                    Array.Reverse(array372);
                    StringBuilder builder = new StringBuilder(addressBit372);
                    foreach (var item in array372)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("372", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "HomePage(主页界面)" + "\r\n" + "储袋点动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        Btn_Cddd.BackColor = System.Drawing.Color.Lime;
                        Btn_Cddd.ForeColor = System.Drawing.Color.White;
                        //
                    }
                    //
                }
                else
                {
                    array372[0] = 0;
                    Array.Reverse(array372);
                    StringBuilder builder = new StringBuilder(addressBit372);
                    foreach (var item in array372)
                    {
                        builder.Append(item);
                    }
                    OperateResult operate = PlcCommon.busTcpClient1.Write("372", Convert.ToUInt16(builder.ToString(), 2));
                    if (!operate.IsSuccess)
                    {
                        Log.GetLogMessage("PlcLog", "HomePage(主页界面)" + "\r\n" + "储袋点动按钮写入失败，失败代码：" + operate.ErrorCode + ",失败原因：" + operate.Message);
                        return;
                    }
                    else
                    {
                        Btn_Cddd.BackColor = System.Drawing.Color.DarkGray;
                        Btn_Cddd.ForeColor = System.Drawing.Color.Black;
                        //
                    }
                    //
                }
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", "HomePage(主页界面)" + "\r\n" + "储袋点动按钮操作失败：" + ex.Message);
            }
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            System.Environment.Exit(0);
        }
    }
}