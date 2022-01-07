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
    /// 班级业务逻辑
    /// </summary>
   public class ClassLogic
    {

     ClassService classService = new ClassService();

        #region 返回班级列表

        /// <summary>
        /// 返回班级列表
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClassList()
        {
            return classService.GetClassList();
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
            return classService.GetClassoObject(id);
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
            return classService.GetClassoObject(className);
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
            return classService.DeleteClass( id);

        }
        #endregion

        #region 修改班级
        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        public bool UpdateClass(int id, string className)
        {
            return classService.UpdateClass(id, className);
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
            return classService.AddClass(className);
        }
        #endregion
    }
}
