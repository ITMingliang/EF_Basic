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
    /// 学生逻辑业务
    /// </summary>
   public class StudentLogic
    {
        StudentSerivce studentSerivce = new StudentSerivce();

        #region 返回学生列表

        /// <summary>
        /// 返回学生列表
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentList()
        {
            return studentSerivce.GetStudentList();
        }
        #endregion

        #region 根据姓名查询
        public List<Student> GetStudentList(string name)
        {
            return studentSerivce.GetStudentList(name);
        }
        #endregion

        #region 根据班级ID查询
        public List<Student> GetStudentListByClassId(int classId)
        {
            return studentSerivce.GetStudentListByClassId(classId);
        }
        #endregion

        #region 根据学生ID查询
        public List<Student> GetStudentByStudentId(int studentId)
        {
            return studentSerivce.GetStudentByStudentId(studentId);
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
            return studentSerivce.AddStudent(student);
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
            return studentSerivce.UpdateStudent(student);
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
            return studentSerivce.DeleteStudent(studentId);
        }
        #endregion
    }
}
