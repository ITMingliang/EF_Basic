using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManage
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //打开学员管理窗口(封装不变的 提取变化的作为参数)
        private void btnStuManage_Click(object sender, EventArgs e)
        {
            FrmStudentManage studentManage = new FrmStudentManage();
            this.ShowForm(studentManage);
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="form">窗口对象</param>
        private void ShowForm(Form form)
        {
            //检查窗口里面有没有其他窗口，如果有就关闭
            foreach (Form item in this.splitContainer1.Panel2.Controls)
            {
                ((Form)item).Close();//关闭窗体
            }

            //设置嵌入窗口的属性并打开窗口
            form.TopLevel = false;//设置为非项级窗口
            form.Parent = this.splitContainer1.Panel2;//设置父窗体
            form.Dock = DockStyle.Fill;//根据父容器自动调整大小
            form.FormBorderStyle = FormBorderStyle.None;//设置边框样式
            form.Show();//显示窗体
        }

        //打开班级管理窗口
        private void btnClassName_Click(object sender, EventArgs e)
        {
            FrmClassManage frmClassManage = new FrmClassManage();
            this.ShowForm(frmClassManage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult= MessageBox.Show("确定要要关闭？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes==dialogResult)
            {
                this.Close();
            }
           
        }

        private void 添加学员AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddStudent frmAddStudent = new FrmAddStudent();
            this.ShowForm(frmAddStudent);
        }

        private void 学员管理MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnStuManage_Click(null, null);
        }
    }
}
