using BLL;
using Models;
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
    /// <summary>
    /// WinForm重点：事件
    /// </summary>
    public partial class FrmClassManage : Form
    {

        ClassLogic classLogic = new ClassLogic();

        public FrmClassManage()
        {
            InitializeComponent();
            LoadClassList();//加载班级列表
        }

        /// <summary>
        /// 添加班级事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string className = this.txtClassName.Text.Trim();
            bool result = classLogic.AddClass(className);
            if (result)
            {
                MessageBox.Show("添加成功！");
                this.txtClassName.Text = "";
                this.txtClassName.Focus();
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

       private void LoadClassList()
        {
           this.liClassList.DataSource= classLogic.GetClassList();
            this.liClassList.DisplayMember = "ClassName";//显示选项值
            this.liClassList.ValueMember = "ClassId";//设置选项的值
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentClass stuClass = (StudentClass)this.liClassList.SelectedItem;//获取选中项的值
            FrmUpdateClass frmUpdate = new FrmUpdateClass(stuClass);//通过构造方法传值
            frmUpdate.Show();//打开窗口
        }

        //刷新数据
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadClassList();//加载班级列表
        }

        //删除班级
        private void btnDelete_Click(object sender, EventArgs e)
        {
            StudentClass stuClass = (StudentClass)this.liClassList.SelectedItem;//获取选中项的值
            bool result = classLogic.DeleteClass(stuClass.ClassId);//调用业务逻辑删除班级
            if (result)
            {
                MessageBox.Show("删除成功！");
                LoadClassList();//加载班级列表
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
           
        }
    }
}
