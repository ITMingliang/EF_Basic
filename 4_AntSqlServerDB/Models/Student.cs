using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 学生实体类
    /// 
    /// 实体是用来作数据传递的   一、数据往---》UI层        二、UI层向--》数据库传递
    /// </summary>
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentityNo { get; set; }
        public string StuImage { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentAddress { get; set; }
        public int ClassId { get; set; }
    }
}
