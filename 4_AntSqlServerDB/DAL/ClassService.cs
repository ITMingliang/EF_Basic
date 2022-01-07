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
    /// 班级数据访问类
    /// 这里就是写班级CURD方法
    /// </summary>
    public class ClassService
    {

        #region 返回班级列表

        /// <summary>
        /// 返回班级列表
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClassList()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            List<StudentClass> stuList = new List<StudentClass>();
            while (reader.Read())
            {
                stuList.Add(new StudentClass()
                {
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString()
                });
            }
            reader.Close();
            return stuList;
        }

        #endregion

        #region 根据班级ID查询

        /// <summary>
        /// 根据班级ID查询
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public StudentClass GetClassoObject(int id)
        {
            string sql = $"select ClassId,ClassName from StudentClass where ClassId={id}";
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            StudentClass objClass = new StudentClass();
            while (reader.Read())
            {
                objClass=new StudentClass()
                {
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString()
                };
            }
            reader.Close();
            return objClass;
        }

        #endregion

        #region 根据班级名称查询

        /// <summary>
        /// 根据班级名称查询
        /// </summary>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        public StudentClass GetClassoObject(string className)
        {
            string sql = $"select ClassId,ClassName from StudentClass where ClassId={className}";
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            StudentClass objClass = new StudentClass();
            while (reader.Read())
            {
                objClass = new StudentClass()
                {
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString()
                };
            }
            reader.Close();
            return objClass;
        }

        #endregion

        #region 根据ID删除
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public bool DeleteClass(int id)
        {
            string sql = $"delete from StudentClass where ClassId={id}";
            int result = SQLHelper.GetSingleResult(sql);
            if (result > 0)
                return true;
            else
                return false;

        }
        #endregion

        #region 修改班级
        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        public bool UpdateClass(int id,string className)
        {
            string sql = $"update StudentClass set ClassName=N'{className}' where ClassId={id}";
            int result = SQLHelper.GetSingleResult(sql);
            if (result >= 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 添加班级
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        public bool AddClass(string className)
        {
            string sql = $"insert into StudentClass (ClassName) values(N'{className}')";
            int result = SQLHelper.GetSingleResult(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        #endregion

    }
}
