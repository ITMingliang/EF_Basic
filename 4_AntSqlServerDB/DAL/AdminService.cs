using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
   public class AdminService
    {
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns></returns>
        public Admin UserLogin(Admin admin)
        {
            string sql = "select LoginId,LoginPwd,AdminName from Admins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",admin.LoginId),
                new SqlParameter("@LoginPwd",admin.LoginPwd)

            };
            try
            {
                SqlDataReader reader = SQLHelper.GetDataReader(sql, parameters);
                if (reader.Read())
                {
                    admin.AdminName = reader["AdminName"].ToString();
                }
                else
                {
                    admin = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return admin;
        }
    }
}
