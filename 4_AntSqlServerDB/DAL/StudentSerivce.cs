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
    /// 学生数据访问类
    /// 
    /// </summary>
   public class StudentSerivce
    {

        #region 返回学生列表

        /// <summary>
        /// 返回学生列表
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentList()
        {
            //准备SQL语句
            string sql = "select StudentId,Name,Age,Gender,Birthday," +
                "IdentityNo,StuImage,PhoneNumber,StudentAddress," +
                "ClassId from Student";
            List<Student> stuList = new List<Student>();//准备一个集合
            SqlDataReader reader= SQLHelper.GetDataReader(sql);
            while (reader.Read())
            {
                stuList.Add(new Student()
                {
                     Age=Convert.ToInt32(reader["Age"]),
                      Birthday=Convert.ToDateTime(reader["Birthday"]),
                       ClassId= Convert.ToInt32(reader["ClassId"]),
                        Gender= reader["Gender"].ToString(),
                         IdentityNo = reader["IdentityNo"].ToString(),
                           Name = reader["Name"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                             StudentAddress = reader["StudentAddress"].ToString(),
                              StudentId= Convert.ToInt32(reader["StudentId"]),
                               StuImage = reader["StuImage"].ToString(),
                });
            }
            return stuList;
        }
        #endregion

        #region 根据姓名查询
        public List<Student> GetStudentList(string name)
        {
            //准备SQL语句
            string sql = $"select StudentId,Name,Age,Gender,Birthday," +
                "IdentityNo,StuImage,PhoneNumber,StudentAddress," +
                "ClassId from Student where name={name}";
            List<Student> stuList = new List<Student>();//准备一个集合
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            while (reader.Read())
            {
                stuList.Add(new Student()
                {
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    Gender = reader["Gender"].ToString(),
                    IdentityNo = reader["IdentityNo"].ToString(),
                    Name = reader["Name"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StuImage = reader["StuImage"].ToString(),
                });
            }
            return stuList;
        }
        #endregion

        #region 根据班级ID查询
        public List<Student> GetStudentListByClassId(int classId)
        {
            //准备SQL语句
            string sql = $"select StudentId,Name,Age,Gender,Birthday," +
                $"IdentityNo,StuImage,PhoneNumber,StudentAddress," +
                $"ClassId from Student where ClassId={classId}";
            List<Student> stuList = new List<Student>();//准备一个集合
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            while (reader.Read())
            {
                stuList.Add(new Student()
                {
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    Gender = reader["Gender"].ToString(),
                    IdentityNo = reader["IdentityNo"].ToString(),
                    Name = reader["Name"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StuImage = reader["StuImage"].ToString(),
                });
            }
            return stuList;
        }
        #endregion

        #region 根据学生ID查询
        public List<Student> GetStudentByStudentId(int studentId)
        {
            //准备SQL语句
            string sql = $"select StudentId,Name,Age,Gender,Birthday," +
                $"IdentityNo,StuImage,PhoneNumber,StudentAddress," +
                $"ClassId from Student where StudentId={studentId}";
            List<Student> stuList = new List<Student>();//准备一个集合
            SqlDataReader reader = SQLHelper.GetDataReader(sql);
            while (reader.Read())
            {
                stuList.Add(new Student()
                {
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    Gender = reader["Gender"].ToString(),
                    IdentityNo = reader["IdentityNo"].ToString(),
                    Name = reader["Name"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StuImage = reader["StuImage"].ToString(),
                });
            }
            return stuList;
        }
        #endregion

        #region 添加学生对象
        /// <summary>
        /// 添加学生对象
        /// </summary>
        /// <param name="student">学生对象</param>
        /// <returns></returns>
        public bool AddStudent(Student student)
        {
            //往数据添加数据的时候数据的顺序和类型一一对应（格式化的SQL语句）
            string sql = $"insert into Student (Name,Age,Gender,Birthday,IdentityNo,PhoneNumber,StudentAddress,ClassId,StuImage)" +
                $" values(N'{ student.Name }',{student.Age},N'{ student.Gender }',N'{ student.Birthday }',N'{ student.IdentityNo }',N'{ student.PhoneNumber }'," +
                $"N'{student.StudentAddress}',{student.ClassId},N'{ student.StuImage }')";
            int result = SQLHelper.GetSingleResult(sql);
            if (result>=0)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }
        #endregion

        #region 更新学生对象
        /// <summary>
        /// 更新学生对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool UpdateStudent(Student student)
        {
            string sql = $"update Student set Name=N'{student.Name}',Age={student.Age}," +
                $"Gender=N'{student.Gender}',Birthday=N'{student.Birthday}',IdentityNo=N'{student.IdentityNo}'" +
                $",PhoneNumber=N'{student.PhoneNumber}',StudentAddress=N'{student.StudentAddress}',ClassId={student.ClassId},StuImage=N'{student.StuImage}' where StudentId={student.StudentId}";
            int result = SQLHelper.GetSingleResult(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 删除学生对象 
        /// <summary>
        /// 删除学生对象
        /// </summary>
        /// <param name="studentId">学生对象</param>
        /// <returns></returns>
        public bool DeleteStudent(int studentId)
        {
            string sql = $"delete from Student where StudentId={studentId}";
            int result = SQLHelper.GetSingleResult(sql);
            if (result >= 0)
                return true;
            else
                return false;


        }
        #endregion
    }
}
