using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueStudentInformation.Models;
using TrueStudentInformation.ViewModel;

namespace TrueStudentInformation.Dao
{
    //学生信息处理
    public class StudentInfoAdapter
    {
        //数据存储类
        private TrueStudentInformationContext db = new TrueStudentInformationContext();
        
        //返回所有学院信息
        public List<Academy> findAcademy()
        {
            return db.Academies.ToList();
        }

        //返回学院对应班级信息
        public List<Classroom> findClassByAcaId(string temple)
        {
            //查询对应班级信息
            var info = from p in db.Classrooms
                       where p.Academy.Equals(temple)
                       select p;
            return info.ToList();
        }

        //返回班级对应学生信息
        public List<TrueStudent> findStudentByclass(Classroom temple)
        {
            //查询对应学生信息
            var info = from p in db.TrueStudents
                       where p.Classroomid.Equals(temple.Id)
                       select p;
            return info.ToList();
        }        

        public StudentDetail findStudentByNum(string num)
        {
            //查询对应学生信息
            var info = from p in db.TrueStudents join
                       b in db.Classrooms
                       on p.Classroomid equals b.Id
                       where p.Num.Equals(num)
                       select new
                       {
                           stu = p,
                           classname=b.Name
                       };

            if (info.ToList().Count > 0)
            {
                StudentDetail sd = new StudentDetail();
                sd.Stu = info.First().stu;
                sd.Classroomname = info.First().classname;
                return sd;
            }
            else
                return null;
        }
    }
}