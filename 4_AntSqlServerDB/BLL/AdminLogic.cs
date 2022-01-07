using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 管理员业务逻辑类
    /// </summary>
   public class AdminLogic
    {
        AdminService adminService = new AdminService();
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns></returns>
        public Admin UserLogin(Admin admin)
        {
            return adminService.UserLogin(admin);
        }
    }
}
