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
    public partial class FrmUpdateClass : Form
    {
        ClassLogic classLogic = new ClassLogic();//实例化对象
        public FrmUpdateClass(StudentClass studentClass)
        {
            InitializeComponent();
            this.stuClass = studentClass;
            this.txtClassName.Text = studentClass.ClassName;//显示班级名称
        }

        public StudentClass stuClass { get; set; }//接收构造方法传过来的对象

        //修改班级
        private void btnOK_Click(object sender, EventArgs e)
        {
          bool result=  classLogic.UpdateClass(stuClass.ClassId, this.txtClassName.Text);//修改对象
            this.Close();//关闭窗体
        }
    }
}
