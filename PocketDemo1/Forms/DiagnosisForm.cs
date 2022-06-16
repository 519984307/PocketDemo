using System;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class DiagnosisForm : Form
    {
        public DiagnosisForm()
        {
            InitializeComponent();
        }

        private void DiagnosisForm_Load(object sender, EventArgs e)
        {
        }

        public void ReadPara()
        {
            try
            {
                #region "转袋诊断"

                // 储料状态 37
                short clzt = PlcCommon.busTcpClient1.ReadInt16("37").Content;

                //等待 储料状态==0
                if (clzt == 0)
                {
                    this.btn_dd.BackColor = System.Drawing.Color.Lime;
                    this.btn_dd.ForeColor = System.Drawing.Color.Black;
                }
                //升起 储料状态==1
                else if (clzt == 1)
                {
                    this.btn_sq.BackColor = System.Drawing.Color.Lime;
                    this.btn_sq.ForeColor = System.Drawing.Color.Black;
                }
                //旋至储袋 储料状态==2
                else if (clzt == 2)
                {
                    this.btn_xzcd.BackColor = System.Drawing.Color.Lime;
                    this.btn_xzcd.ForeColor = System.Drawing.Color.Black;
                }
                //二次升 储料状态==256
                else if (clzt == 1)
                {
                    this.btn_dd.BackColor = System.Drawing.Color.Lime;
                    this.btn_dd.ForeColor = System.Drawing.Color.Black;
                }
                //伸出 储料状态==4
                else if (clzt == 0)
                {
                    this.btn_sc.BackColor = System.Drawing.Color.Lime;
                    this.btn_sc.ForeColor = System.Drawing.Color.Black;
                }
                //抓取 储料状态==8
                else if (clzt == 8)
                {
                    this.btn_zq.BackColor = System.Drawing.Color.Lime;
                    this.btn_zq.ForeColor = System.Drawing.Color.Black;
                }
                //缩回 储料状态==16
                else if (clzt == 16)
                {
                    this.btn_sh.BackColor = System.Drawing.Color.Lime;
                    this.btn_sh.ForeColor = System.Drawing.Color.Black;
                }
                //下降 储料状态==128
                else if (clzt == 128)
                {
                    this.btn_xj.BackColor = System.Drawing.Color.Lime;
                    this.btn_xj.ForeColor = System.Drawing.Color.Black;
                }
                //旋至平台 储料状态==64
                else if (clzt == 64)
                {
                    this.btn_xzpt.BackColor = System.Drawing.Color.Lime;
                    this.btn_xzpt.ForeColor = System.Drawing.Color.Black;
                }
                //二次降 储料状态==512
                else if (clzt == 512)
                {
                    this.btn_ecj.BackColor = System.Drawing.Color.Lime;
                    this.btn_ecj.ForeColor = System.Drawing.Color.Black;
                }

                //松开 储料状态==32
                else if (clzt == 32)
                {
                    this.btn_sk.BackColor = System.Drawing.Color.Lime;
                    this.btn_sk.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    this.btn_dd.BackColor = System.Drawing.Color.Lime;
                    this.btn_dd.ForeColor = System.Drawing.Color.Black;
                }

                //送袋伺服前移 114:X0

                #endregion "转袋诊断"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", DateTime.Now + ":" + ex);
            }
        }

        #region "页面跳转 "

        /// <summary>
        /// I/O控制器
        /// </summary>
        private void Btn_IOControllerForm_Click(object sender, EventArgs e)
        {
            IOControllerForm iOControllerForm = new IOControllerForm();
            this.Hide();
            iOControllerForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 32伺服输入
        /// </summary>
        private void Btn_InputForm_Click(object sender, EventArgs e)
        {
            ServoManualForm2 inputForm = new ServoManualForm2();
            this.Hide();
            inputForm.ShowDialog();
            this.Dispose();
        }

        /// <summary>
        /// 主页页面
        /// </summary>
        private void Btn_HomePage_Click(object sender, EventArgs e)
        {
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
            AdministrationForm administration = new AdministrationForm();
            this.Hide();
            administration.ShowDialog();
            this.Dispose();
        }

        #endregion "页面跳转 "
    }
}