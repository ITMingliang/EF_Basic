using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManage
{
    public partial class FrmStudentManage : Form
    {
        ClassLogic classLogic = new ClassLogic();//实例化班级业务类
        StudentLogic studentLogic = new StudentLogic();//实例化学生业务类
        public FrmStudentManage()
        {
            InitializeComponent();
            //绑定班级列表
            this.cbClass.DataSource = classLogic.GetClassList();
            this.cbClass.DisplayMember = "ClassName";
            this.cbClass.ValueMember = "ClassId";
            this.cbClass.SelectedIndex = -1;

            //绑定学生信息表
            this.dgvStudent.AutoGenerateColumns = false;//这个属性设置需要在数据绑定前
            this.dgvStudent.RowHeadersVisible = false;
            //this.dgvStudent.DataSource = studentLogic.GetStudentList();
            LoadData();//加载数据


        }

        //按班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cbClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级再进行查询！");
                return;
            }
            int classId = Convert.ToInt32(this.cbClass.SelectedValue);
            this.dgvStudent.DataSource = studentLogic.GetStudentListByClassId(classId);
        }
        //按学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //验证是否输入
            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学号进行查询");
                return;
            }
            //验证是否输入的是数字(正则表达式)
            string input = this.txtStudentId.Text.Trim();
            string str = @"^[0-9]*$";
            bool isMatch= Regex.IsMatch(input, str);
            if (!isMatch)
            {
                MessageBox.Show("请输入数字！");
                return;
            }

            #endregion

            //查询数据
            int studentId = Convert.ToInt32(this.txtStudentId.Text.Trim());
            this.dgvStudent.DataSource=studentLogic.GetStudentByStudentId(studentId);
            
        }

        //打开添加窗口
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            FrmAddStudent addStudent = new FrmAddStudent();
            addStudent.Show();
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int studentId = (int)this.dgvStudent.SelectedRows[0].Cells["StudentId"].Value;//获取单元格的值

            FrmShowStudent studentShow = new FrmShowStudent(studentId);
            studentShow.Show();//显示窗口
        }

        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int studentId = (int)this.dgvStudent.SelectedRows[0].Cells["StudentId"].Value;
            FrmEidtStudent studentEdit = new FrmEidtStudent(studentId);
            studentEdit.Show();//显示窗口
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int studentId = (int)this.dgvStudent.SelectedRows[0].Cells["StudentId"].Value;
            bool result = studentLogic.DeleteStudent(studentId);
            if (result)
            {
                MessageBox.Show("删除成功","信息提示");
                LoadData();//加载数据
            }
            else
            {
                MessageBox.Show("删除失败", "信息提示");
            }

            

        }

        //加载表格数据
        private void LoadData()
        {
            this.dgvStudent.DataSource = studentLogic.GetStudentList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
