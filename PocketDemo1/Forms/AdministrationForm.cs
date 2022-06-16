using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PocketDemo1
{
    public partial class AdministrationForm : Form
    {
        // private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "AdminiStrators.xml";
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "XMLFile1.xml";

        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            GetUserGourpForCmb();

            int aa = 16952;
            int[] a = ToBinary.IntToBinaryDESC(aa);
            //MessageBox.Show(""+a[2]);
            a[0] = 0;
            Array.Reverse(a);

            StringBuilder result = new StringBuilder(aa);

            //for (int i = 0; i < a.Length; i++)
            //{
            //    result.Append(a[i]);
            //    // MessageBox.Show(a[i].ToString());
            //}
            foreach (var item in a)
            {
                result.Append(item);
            }

            int b = Convert.ToInt16(result.ToString(), 2);
            string c = b.ToString();

            //aa = 99;
            MessageBox.Show(c);
            //MessageBox.Show("short:" + aa + "\r\n" + "二进制：" + bb + "\r\n" + result);
        }

        /// <summary>
        /// 获取用户组信息绑定ComboBox控件
        /// </summary>
        public void GetUserGourpForCmb()
        {
            //读取xml配置文件
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(xmlPath);

            XmlNode xmlNode1 = XmlDoc.SelectSingleNode("/UsersInfo/UserGrouping");
            XmlNodeList xmlNodeList = xmlNode1.ChildNodes;

            this.Cmb_UserGroup.Items.Add(new ListItem("", "--XXXX--"));

            foreach (XmlNode item in xmlNodeList)
            {
                this.Cmb_UserGroup.Items.Add(new ListItem(item.Attributes["GroupID"].Value, item.Attributes["GroupName"].Value));
            }
            this.Cmb_UserGroup.SelectedIndex = 0;
            if (this.Cmb_UserGroup.SelectedIndex != 0)
            {
                GetUserName(((ListItem)this.Cmb_UserGroup.SelectedItem).Value);
            }
        }

        /// <summary>
        /// 选定用户组后显示用户
        /// </summary>
        /// <param name="UserGourp">用户组</param>
        public void GetUserName(string UserGourp)
        {
            //读取xml配置文件
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(xmlPath);

            XmlNode xmlNode = XmlDoc.SelectSingleNode("/UsersInfo/Users");
            XmlNodeList xmlNodeList = xmlNode.ChildNodes;

            foreach (XmlNode item in xmlNodeList)
            {
                string gourpName = item.Attributes["GroupName"].Value;
                if (UserGourp == gourpName)
                {
                    this.Cmb_UserName.Items.Add(new ListItem(item.Attributes["AdminID"].Value, item.Attributes["AdminName"].Value));
                }
            }
            this.Cmb_UserName.SelectedIndex = 0;
        }

        private void Btn_SignIn_Click(object sender, EventArgs e)
        {
            //读取xml配置文件
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(xmlPath);

            if (this.Cmb_UserName.SelectedIndex == 0 && this.Cmb_UserGroup.SelectedIndex == 0)
            {
                MessageBox.Show("请选择用户和用户组");
                return;
            }
            else
            {
                XmlNode xmlNode = XmlDoc.SelectSingleNode("/UsersInfo/Users");
                XmlNodeList xmlNodeList = xmlNode.ChildNodes;

                string cmbUserName = ((ListItem)this.Cmb_UserName.SelectedItem).Value;
                string tbxPassWord1 = MD5Helper.MD5Encrypt64(Tbx_PassWord1.Text.Trim());
                string tbxPassWord2 = MD5Helper.MD5Encrypt64(Tbx_PassWord2.Text.Trim());

                if (tbxPassWord1 == tbxPassWord2)
                {
                    foreach (XmlNode xml in xmlNodeList)
                    {
                        string adminName = xml.Attributes["AdminName"].Value;
                        if (adminName == cmbUserName)
                        {
                            string passWord = xml.Attributes["PassWord"].Value;

                            if (passWord == tbxPassWord1)
                            {
                                MessageBox.Show("登录成功！");
                            }
                            else
                            {
                                MessageBox.Show("密码错误！");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致！");
                }
            }
        }

        #region "页面跳转 "

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
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

        private void Cmb_UserGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            Cmb_UserName.Items.Clear();

            if (this.Cmb_UserGroup.SelectedIndex != 0)
            {
                GetUserName(((ListItem)this.Cmb_UserGroup.SelectedItem).Value);
            }
        }
    }
}