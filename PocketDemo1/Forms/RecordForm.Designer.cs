
namespace PocketDemo1
{
    partial class RecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Administration = new System.Windows.Forms.Button();
            this.Btn_Diagnosis = new System.Windows.Forms.Button();
            this.Btn_Warning = new System.Windows.Forms.Button();
            this.Btn_ParaMeter = new System.Windows.Forms.Button();
            this.Btn_AutoMatic = new System.Windows.Forms.Button();
            this.Btn_Manual = new System.Windows.Forms.Button();
            this.Btn_HomePage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.14425F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.85575F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1165, 617);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1159, 507);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 24;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日期";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.Width = 159;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "信息";
            this.columnHeader4.Width = 490;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "状态";
            this.columnHeader5.Width = 162;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel4.Controls.Add(this.Btn_Administration, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_Diagnosis, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_Warning, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_ParaMeter, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_AutoMatic, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_Manual, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_HomePage, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 516);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1159, 92);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // Btn_Administration
            // 
            this.Btn_Administration.BackColor = System.Drawing.Color.Lime;
            this.Btn_Administration.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Administration.Location = new System.Drawing.Point(963, 3);
            this.Btn_Administration.Name = "Btn_Administration";
            this.Btn_Administration.Size = new System.Drawing.Size(150, 83);
            this.Btn_Administration.TabIndex = 0;
            this.Btn_Administration.Text = "权限";
            this.Btn_Administration.UseVisualStyleBackColor = false;
            this.Btn_Administration.Click += new System.EventHandler(this.Btn_Administration_Click);
            // 
            // Btn_Diagnosis
            // 
            this.Btn_Diagnosis.BackColor = System.Drawing.Color.Lime;
            this.Btn_Diagnosis.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Diagnosis.Location = new System.Drawing.Point(803, 3);
            this.Btn_Diagnosis.Name = "Btn_Diagnosis";
            this.Btn_Diagnosis.Size = new System.Drawing.Size(145, 83);
            this.Btn_Diagnosis.TabIndex = 0;
            this.Btn_Diagnosis.Text = "诊断";
            this.Btn_Diagnosis.UseVisualStyleBackColor = false;
            this.Btn_Diagnosis.Click += new System.EventHandler(this.Btn_Diagnosis_Click);
            // 
            // Btn_Warning
            // 
            this.Btn_Warning.BackColor = System.Drawing.Color.Lime;
            this.Btn_Warning.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Warning.Location = new System.Drawing.Point(643, 3);
            this.Btn_Warning.Name = "Btn_Warning";
            this.Btn_Warning.Size = new System.Drawing.Size(151, 83);
            this.Btn_Warning.TabIndex = 0;
            this.Btn_Warning.Text = "报警";
            this.Btn_Warning.UseVisualStyleBackColor = false;
            this.Btn_Warning.Click += new System.EventHandler(this.Btn_Warning_Click);
            // 
            // Btn_ParaMeter
            // 
            this.Btn_ParaMeter.BackColor = System.Drawing.Color.Lime;
            this.Btn_ParaMeter.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ParaMeter.Location = new System.Drawing.Point(483, 3);
            this.Btn_ParaMeter.Name = "Btn_ParaMeter";
            this.Btn_ParaMeter.Size = new System.Drawing.Size(144, 83);
            this.Btn_ParaMeter.TabIndex = 0;
            this.Btn_ParaMeter.Text = "参数";
            this.Btn_ParaMeter.UseVisualStyleBackColor = false;
            this.Btn_ParaMeter.Click += new System.EventHandler(this.Btn_ParaMeter_Click);
            // 
            // Btn_AutoMatic
            // 
            this.Btn_AutoMatic.BackColor = System.Drawing.Color.Lime;
            this.Btn_AutoMatic.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_AutoMatic.Location = new System.Drawing.Point(323, 3);
            this.Btn_AutoMatic.Name = "Btn_AutoMatic";
            this.Btn_AutoMatic.Size = new System.Drawing.Size(144, 83);
            this.Btn_AutoMatic.TabIndex = 0;
            this.Btn_AutoMatic.Text = "自动";
            this.Btn_AutoMatic.UseVisualStyleBackColor = false;
            this.Btn_AutoMatic.Click += new System.EventHandler(this.Btn_AutoMatic_Click);
            // 
            // Btn_Manual
            // 
            this.Btn_Manual.BackColor = System.Drawing.Color.Lime;
            this.Btn_Manual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Manual.Location = new System.Drawing.Point(163, 3);
            this.Btn_Manual.Name = "Btn_Manual";
            this.Btn_Manual.Size = new System.Drawing.Size(145, 83);
            this.Btn_Manual.TabIndex = 0;
            this.Btn_Manual.Text = "手动";
            this.Btn_Manual.UseVisualStyleBackColor = false;
            this.Btn_Manual.Click += new System.EventHandler(this.Btn_Manual_Click);
            // 
            // Btn_HomePage
            // 
            this.Btn_HomePage.BackColor = System.Drawing.Color.Lime;
            this.Btn_HomePage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_HomePage.Location = new System.Drawing.Point(3, 3);
            this.Btn_HomePage.Name = "Btn_HomePage";
            this.Btn_HomePage.Size = new System.Drawing.Size(142, 83);
            this.Btn_HomePage.TabIndex = 0;
            this.Btn_HomePage.Text = "主页";
            this.Btn_HomePage.UseVisualStyleBackColor = false;
            this.Btn_HomePage.Click += new System.EventHandler(this.Btn_HomePage_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1165, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备启停记录";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Btn_Administration;
        private System.Windows.Forms.Button Btn_Diagnosis;
        private System.Windows.Forms.Button Btn_Warning;
        private System.Windows.Forms.Button Btn_ParaMeter;
        private System.Windows.Forms.Button Btn_AutoMatic;
        private System.Windows.Forms.Button Btn_Manual;
        private System.Windows.Forms.Button Btn_HomePage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}