using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    /// <summary>
    /// 交流群：737763054
    /// 官网：https://www.antprograming.com
    /// 前置课程Linq/ADO.NET
    /// 
    /// 系列课程规划--》ef基础--》EFCodeFirst-->EF Core
    /// 
    /// Database-First开发方式
    /// 1-创建
    /// 更新时顺序 ---修改数据库—》从数据库刷新数据数据—》保存设计器
    /// 
    /// 2-EF原理
    /// ef核心文件edmx
    /// 数据库上下文基类ObjectContext
    /// 执行原理：通过反射获取数据库结构，通过CRUD方法生成SQL语句--》通过ADO.NET执行到数据库
    /// 
    /// 3-上下文类的使用和数据的添加。
    /// 
    /// 4-批处理（事务）
    /// 
    /// 5-查询、根据ID根据、根据条件查询 、查询所有、延迟查询
    /// 延迟查询用于分页、多条件查询
    /// 
    /// 6-数据修改
    /// 
    /// 7--删除数据
    /// 
    /// 
    /// 8--Model-First开发方式
    /// 
    /// </summary>
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            //Add();
            //AddBatch();
            //Query();
            //PagingQuery(3, 3);
            //Update();
            Delete();
            Console.ReadKey();
        }
        //添加数据
        static void Add()
        {

            using (var db = new Entities())
            {

                Student stu1 = new Student
                {
                    Name = "Ant编程2",
                    Address = "杭州2",
                    Age = 20,
                    PhoneNumber = "1234567890"
                };
                //方式一
                //db.Student.Add(stu1);//要把这个实体对象附加到数据库上下文

                //方式二
                db.Entry(stu1).State = System.Data.Entity.EntityState.Added;
                int result = db.SaveChanges();//这一步才是真正执行到数据库
                if (result > 0)
                {
                    Console.WriteLine("添加数据成功");
                }

            }

        }
        //批量处理
        static void AddBatch()
        {
            using (var db = new Entities())
            {
                for (int i = 0; i < 5; i++)
                {
                    Student stu1 = new Student
                    {
                        Name = "Ant编程2" + i,
                        Address = "杭州2" + i,
                        Age = 20 + 1,
                        PhoneNumber = "1234567890"
                    };
                    db.Student.Add(stu1);

                }
                //这里还可以写上各种数据库的操作修改、删除、



                db.SaveChanges();//这个方法会自动开启一个事务，进行批处理。
            }
        }

        static void Query()
        {
            //根据ID根据、根据条件查询 、查询所有、延迟查询，分页查询 


            using (var db = new Entities())
            {
                //根据ID根据
                //var sut1 = db.Student.Find(1);
                //var sut1 = db.Student.Where(s => s.Name == "Ant编程20").FirstOrDefault();
                //Console.WriteLine(sut1.Name);

                ////根据条件查询如果数据返回类型是IQueryable说明是延迟查询
                //var query = db.Student.Where(s => s.Id > 3);//这里还没有真正进行查询 
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}


                ////查询所有
                //var query = db.Student.ToList();
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}

                //分页查询

            }

        }

        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页几条</param>
        static void PagingQuery(int pageIndex,int pageSize)
        {
            using (var db=new Entities())
            {
                //分页查询一定要排序
                var query = db.Student.OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        static void Update()
        {
            using ( var db=new Entities())
            {
                #region 官方推荐---只会修改需要修改的字段
                //Student stu = db.Student.Where(s => s.Id == 1).FirstOrDefault();//返回的是Student的代理类（包装类）

                //stu.Name = "测试";//到这一步时，包装类会给真实的类修改属性，并且会给他状态设置为已修改状态

                //db.SaveChanges();
                #endregion



                #region 方式二---会修改全部字段
                //Student stu = db.Student.Where(s => s.Id == 1).FirstOrDefault();
                //stu.Age = 10;
                //db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
                #endregion
            }
        }

        static void Delete()
        {
            using (var db=new Entities())
            {
                Student stu = new Student { Id = 7 };//也可以从数据库查询 到
                //方式一
                //db.Student.Attach(stu);
                //db.Student.Remove(stu);

                //方式二
                db.Entry(stu).State = System.Data.Entity.EntityState.Deleted;

               int result= db.SaveChanges();
                Console.WriteLine(result);

            }
        }
    }



}
