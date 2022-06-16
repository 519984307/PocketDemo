using System;
using System.Windows.Forms;
using System.Xml;

namespace PocketDemo1
{
    public partial class Register : Form
    {
        //private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "AdminiStrators.xml";

        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "XMLFile1.xml";

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            GetUserGourpForCmb();
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
            var key= ((ListItem)Cmb_UserGroup.SelectedItem).Key;
            var value= ((ListItem)Cmb_UserGroup.SelectedItem).Value;
        }

        /// <summary>
        ///// 创建节点
        ///// </summary>
        ///// <param name="xmldoc"></param>  xml文档
        ///// <param name="parentnode"></param>父节点
        ///// <param name="name"></param>  节点名
        ///// <param name="value"></param>  节点值
        /////
        //public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        //{
        //    XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
        //    node.InnerText = value;
        //    parentNode.AppendChild(node);
        //}

        //private void showInfoByElements(IEnumerable<XElement> elements)
        //{
        //    List<XmlService.AdminClass> modelList = new List<XmlService.AdminClass>();
        //    foreach (var ele in elements)
        //    {
        //        XmlService.AdminClass model = new XmlService.AdminClass();
        //        model.id = Convert.ToInt32(ele.Element("id").Value);
        //        model.name = ele.Element("adminName").Value;
        //        model.password = ele.Attribute("passWord").Value;

        //        modelList.Add(model);
        //    }
        //    dgvBookInfo.DataSource = modelList;
        //}

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Tbx_UserName.Text.Trim()))
                {
                    MessageBox.Show("账号不能为空！");
                    this.Tbx_UserName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.Tbx_Password.Text.Trim()))
                {
                    MessageBox.Show("密码不能为空！");
                    this.Tbx_Password.Focus();
                    return;
                }

                string tbx_password = MD5Helper.MD5Encrypt64(this.Tbx_Password.Text.Trim());

                //读取xml配置文件
                XmlDocument XmlDoc = new XmlDocument();
                //  Dictionary<string, string> keyValues = new Dictionary<string, string>();
                XmlDoc.Load(xmlPath);

                //XElement xe = XElement.Load(xmlPath);
                //IEnumerable<XElement> elements = from ele in xe.Elements("adminName") select ele;
                //showInfoByElements(elements);

                //XmlNamespaceManager manager = new XmlNamespaceManager(XmlDoc.NameTable);
                //manager.AddNamespace("user", "#RowsetSchema");
                //XmlNodeList xmlNodeList = XmlDoc.LastChild.LastChild.SelectNodes("user", manager);

                XmlNode xmlNode1 = XmlDoc.SelectSingleNode("/UsersInfo/Users");
                XmlNodeList xmlNodeList = xmlNode1.ChildNodes;

                foreach (XmlNode xml in xmlNodeList)
                {
                    string aname = xml.Attributes["AdminName"].Value;

                    if (aname == this.Tbx_UserName.Text.Trim())
                    {
                        MessageBox.Show("该账户名已被占用");
                        return;
                    }
                }

                XmlElement userNode = XmlDoc.CreateElement("User");

                int idKeys = XmlDoc.SelectSingleNode("/UsersInfo/Users").ChildNodes.Count;
                XmlAttribute id = XmlDoc.CreateAttribute("AdminID");
                id.InnerText = Convert.ToString(idKeys + 1);
                userNode.Attributes.Append(id);

                XmlAttribute adminName = XmlDoc.CreateAttribute("AdminName");
                adminName.InnerText = this.Tbx_UserName.Text.Trim();
                userNode.Attributes.Append(adminName);

                XmlAttribute passWord = XmlDoc.CreateAttribute("PassWord");
                passWord.InnerText = tbx_password;
                userNode.Attributes.Append(passWord);

                XmlAttribute userGroup = XmlDoc.CreateAttribute("GroupName");
                userGroup.InnerText = ((ListItem)this.Cmb_UserGroup.SelectedItem).Value;
                userNode.Attributes.Append(userGroup);

                xmlNode1.AppendChild(userNode);

                //XmlNodeList xmlNodeList1 = XmlDoc.LastChild.ChildNodes;

                //XmlNodeList xmlNodeLists = XmlDoc.GetElementsByTagName("adminName");
                ////var st = xmlNodeList.Item(1).InnerXml;

                //foreach (XmlNode item1 in xmlNodeList1)
                //{
                //    var tbx_adminName = Tbx_UserName.Text.Trim();

                //    var aaa = item1.LastChild.Attributes["adminName"].Value;

                //    var abc = item1.LastChild.InnerText.Trim();
                //    var dcc = item1.NodeType;

                //    if (abc == tbx_adminName)
                //    {
                //        MessageBox.Show("该账户名已被占用");
                //    }
                //    else
                //    {
                //        // XmlNode node = XmlDoc.DocumentElement;
                //        //XmlNode node1 = XmlDoc.CreateElement("user");
                //        int id = XmlDoc.SelectSingleNode("Users").ChildNodes.Count;
                //        //XmlNode xmlNode = XmlDoc.CreateElement("Users");
                //        //XmlDoc.AppendChild(xmlNode);
                //        XmlNode xmlNode = XmlDoc.SelectSingleNode("Users");
                //        XmlNode xmlElement = XmlDoc.CreateNode(XmlNodeType.Element, "user", null);
                //        CreateNode(XmlDoc, xmlElement, "id", Convert.ToString(id));
                //        CreateNode(XmlDoc, xmlElement, "adminName", this.Tbx_UserName.Text.Trim());
                //        CreateNode(XmlDoc, xmlElement, "passWord", password);
                //        xmlNode.AppendChild(xmlElement);
                //        //XmlDoc.SelectSingleNode("id").InnerText = Convert.ToString(id+1) ;
                //        //XmlDoc.SelectSingleNode("adminName").InnerText  = this.Tbx_UserName.Text.Trim();
                //        //XmlDoc.SelectSingleNode("Password").InnerText = password;
                //    }
                //}

                //List<object> jsonlist = new List<object>(0);

                //foreach (var item in xmlNodeList)
                //{
                //    Dictionary<string, string> keys = new Dictionary<string, string>();
                //    XmlElement xmlElement = (XmlElement)item;

                //    string name = xmlElement.GetAttribute("adminName");
                //    string pass = xmlElement.GetAttribute("passWord");

                //    keys.Add("管理员", name);
                //    keys.Add("4545454", pass);

                //    jsonlist.Add(keys);
                //}
                //XmlDoc.GetElementsByTagName("AdminName")[0].InnerText = this.Tbx_UserName.Text.Trim();
                //XmlDoc.GetElementById("Password").InnerText = password;

                XmlDoc.Save(xmlPath);//保存
                MessageBox.Show("注册成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex);
                return;
            }
        }
    }
}