
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
    public partial class FrmShowStudent : Form
    {


        ClassLogic classLogic = new ClassLogic();
        StudentLogic studentLogic = new StudentLogic();
        public FrmShowStudent(int studnetId)
        {
            InitializeComponent();
            //初始化班级列表
            this.cobClassName.DataSource = classLogic.GetClassList();
            this.cobClassName.DisplayMember = "ClassName";
            this.cobClassName.ValueMember = "ClassId";
            this.cobClassName.SelectedIndex = -1;
            //根据ID查询学生信息
            Student student = studentLogic.GetStudentByStudentId(studnetId)[0];
            #region 显示信息
            this.picPhoto.Image = student.StuImage.Length == 0 ? null : (Image)
            new SerializeObjectToString().DeserializeObject(student.StuImage);
            this.txtName.Text = student.Name;
            if (student.Gender == "男")
                this.rdoMale.Checked = true;
            else
                this.rdoFemale.Checked = true;
            this.dateTimePicker1.Value = student.Birthday;
            this.cobClassName.SelectedValue = student.ClassId;
            this.txtAddress.Text = student.StudentAddress;
            this.txtAge.Text = student.Age.ToString();
            this.txtPhoneNumber.Text = student.PhoneNumber;
            this.txtIdentityNo.Text = student.IdentityNo;
            #endregion
        }

        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
