using AForge.Video.DirectShow;
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
    public partial class FrmEidtStudent : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        ClassLogic classLogic = new ClassLogic();
        StudentLogic studentLogic = new StudentLogic();
        private int studentId;
        public FrmEidtStudent(int studentId)
        {
            this.studentId = studentId;
            InitializeComponent();
            //初始化班级列表
            this.cobClassName.DataSource = classLogic.GetClassList();
            this.cobClassName.DisplayMember = "ClassName";
            this.cobClassName.ValueMember = "ClassId";
            this.cobClassName.SelectedIndex = -1;
            //显示信息
            Student student = studentLogic.GetStudentByStudentId(studentId)[0];
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

        #region 照片视频处理


        //打开视频
        private void btnStartVido_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//获取所有设备
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);//链接摄像头
            this.videoSourcePlayer.VideoSource = videoSource;//将摄像 头加载 到控件中
            this.videoSourcePlayer.Start();//启动
        }
        //关闭视频
        private void btnCloseVido_Click(object sender, EventArgs e)
        {
            this.videoSourcePlayer.SignalToStop();//关闭
        }
        //拍照
        private void btnTake_Click(object sender, EventArgs e)
        {
            //定义文件名
            string imageName = DateTime.Now.ToString("yyyyMMddHHmmss");
            string path = @"D:/Image/" + imageName + ".jpg";
            if (videoSourcePlayer==null)
            {
                return;
            }
            //获取图片
            Bitmap bitmap = this.videoSourcePlayer.GetCurrentVideoFrame();
            //保存
            bitmap.Save(path);
           
        }

        //选择图片
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
           //DialogResult result= openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
              this.picPhoto.Image= Image.FromFile(openFileDialog.FileName);
            }
        }
        //清除照片
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.picPhoto.Image = null;
        }



        #endregion

        //添加学生对象
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 数据验证

            if (this.txtName.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入姓名", "提示信息");
                this.txtName.Focus();
                return;
            }
            if (!this.rdoMale.Checked&&!this.rdoFemale.Checked)
            {
                MessageBox.Show("请选择性别", "提示信息");
                return;
            }
            if (this.cobClassName.SelectedIndex==-1)
            {
                MessageBox.Show("请选择班级列表", "提示信息");
                return;
            }

            #endregion

            #region 对象封装
            Student student = new Student()
            {
                Name = this.txtName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(this.dateTimePicker1.Text),
                ClassId = Convert.ToInt32(this.cobClassName.SelectedValue),
                IdentityNo = this.txtIdentityNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                Age = Convert.ToInt32(this.txtAge.Text.Trim()),
                StuImage = this.picPhoto.Image == null ? " " : new SerializeObjectToString().SerializeObject(this.picPhoto.Image),
                StudentId=this.studentId
            };

            #endregion

            #region 添加到数据库

            //添加到数据库
            bool result = studentLogic.UpdateStudent(student);
            if (result)
            {
                MessageBox.Show("添加成功","信息提示");
            }
            else
            {
                MessageBox.Show("添加失败", "信息提示");
            }

            #endregion

        }
        //重置
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.picPhoto.Image = null;
            this.txtName.Text = "";
            this.rdoMale.Checked = false;
            this.rdoFemale.Checked = false;
            this.cobClassName.SelectedIndex = -1;
            this.txtIdentityNo.Text = "";
            this.txtAge.Text = "";
            this.txtPhoneNumber.Text = "";
            this.txtAddress.Text = "";
        }

    }
}
