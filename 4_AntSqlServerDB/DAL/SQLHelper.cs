using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// SQL助手
    /// 封装：抽取变化的   封装不变的
    /// </summary>
   public  class SQLHelper
    {

        #region 链接
        ////链接字符串---链接数据库用
        private static  readonly string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private static readonly string connString = @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\ADMINISTRATOR\DESKTOP\ANTSQLSERVERDB\STUDENTMANAGE\DATABASE\STUDENTMANAGER.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        ////独立数据库方式登陆
        //private static readonly string connString = $"Server=PC-201902191642;DataBase=EFDB;Uid=sa;Pwd=ant123456";
        #endregion

        ////独立数据库方式登陆
        //private static readonly string connString = $"Server=49.234.233.41,1433;DataBase=EFDB;Uid=sa;Pwd=123456789";


        ////链接字符串放配置文件
        //private static readonly string connString = ConfigurationManager.ConnectionStrings["efdbString"].ToString();

        #region  格式化的SQL语句
        #region 增、删、改

        /// <summary>
        /// 增、删、改（insert/delete/update）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static int GetSingleResult(string sql)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                //这部分是写需要检测的语句
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //处理异常
                //会直接显示或者可以写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错"+ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的问题
                conn.Close();
            }
            
        }

        #endregion

        #region 读取单一结果

        /// <summary>
        /// 读取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleObject(string sql)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                //CommandBehavior.CloseConnection 检测并自动关闭数据库链接
                object  obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                //在这里可以写入系统日志
                Console.WriteLine("执行GetSingleObject(string sql)"+ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
         
        }



        #endregion

        #region 读取多个对象

        /// <summary>
        /// 读取多个对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                //CommandBehavior.CloseConnection 检测并自动关闭数据库链接
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行GetDataReader(string sql)方法时出错："+ex.Message);
                throw ex;
            }
         
        }



        #endregion

        #region 事务
        /// <summary>
        /// 事务：显示事务和隐示事务
        /// 显示事务：手动操作的
        /// 隐示事务：平常的一条SQL语句 
        /// 
        /// </summary>
        /// <param name="sqlList">SQL语句List</param>
        /// <returns></returns>
        public static int UpdateByTransaction(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                int result = 0;
                foreach (string sql in sqlList)//循环提交 SQL语句
                {
                    cmd.CommandText = sql;
                   result+= cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交数据库事务（并且自动清除事务）
                return result;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction.Rollback();//回滚事务（意思就是撤销所有SQL语句执行）并且自动清除事务
                }
                throw new Exception("执行UpdateByTransaction(List<string> sqlList)方法时出错："+ex.Message) ;
            }
            finally
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction = null;//清除事务
                }
                conn.Close();
            }

          
        }
        #endregion

        #endregion

        #region 带参数的SQL语句

        #region 增、删、改

        /// <summary>
        /// 增、删、改（insert/delete/update）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static int GetSingleResult(string sql,SqlParameter[] param)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这部分是写需要检测的语句
                conn.Open();
                cmd.Parameters.AddRange(param);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //处理异常
                //会直接显示或者可以写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错" + ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的问题
                conn.Close();
            }

        }

        #endregion

        #region 读取单一结果

        /// <summary>
        /// 读取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleObject(string sql, SqlParameter[] param)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                //CommandBehavior.CloseConnection 检测并自动关闭数据库链接
                object obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                //在这里可以写入系统日志
                Console.WriteLine("执行GetSingleObject(string sql)" + ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }



        #endregion

        #region 读取多个对象

        /// <summary>
        /// 读取多个对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql, SqlParameter[] param)
        {
            //链接ADO.NET做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                //CommandBehavior.CloseConnection 检测并自动关闭数据库链接
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行GetDataReader(string sql)方法时出错：" + ex.Message);
                throw ex;
            }

        }



        #endregion
        #endregion
    }
}
