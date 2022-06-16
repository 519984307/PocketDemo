using System;
using System.Windows.Forms;

namespace PocketDemo1
{
    public partial class WarningForm2 : Form
    {
        public WarningForm2()
        {
            InitializeComponent();
        }

        public void ReadPara()
        {
            try
            {
                #region "故障代码"

                //LXM52故障代码1 40
                short LXM521 = PlcCommon.busTcpClient1.ReadInt16("40").Content;
                tbx_LXM521.Text = (LXM521 + "").ToString();

                //夹LXM52故障代码2 41
                short LXM522 = PlcCommon.busTcpClient1.ReadInt16("41").Content;
                tbx_LXM522.Text = (LXM522 + "").ToString();

                //LXM32故障代码1 217
                short LXM321 = PlcCommon.busTcpClient1.ReadInt16("217").Content;
                tbx_LXM321.Text = (LXM321 + "").ToString();

                //LXM32故障代码2 219
                short LXM322 = PlcCommon.busTcpClient1.ReadInt16("219").Content;
                tbx_LXM322.Text = (LXM322 + "").ToString();

                #endregion "故障代码"
            }
            catch (Exception ex)
            {
                Log.GetLogMessage("PlcLog", DateTime.Now + ":" + ex);
            }
        }

        #region "按钮点击事件 "

        /// <summary>
        /// 参数1按钮
        /// </summary>
        private void Btn_Return_Click(object sender, EventArgs e)
        {
            WarningForm1 warningForm1 = new WarningForm1();
            this.Hide();
            warningForm1.ShowDialog();
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

        #endregion "按钮点击事件 "

        private void WarningForm2_Load(object sender, EventArgs e)
        {
        }
    }
}