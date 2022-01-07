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
    public partial class UserLogin : Form
    {
        AdminLogic adminLogic = new AdminLogic();
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtUserPwd.Text.Trim()
            };
            Admin adminLogin = adminLogic.UserLogin(admin);
            if (adminLogin==null)
            {
                MessageBox.Show("帐号或者密码错误，请重新输入","信息提示");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
