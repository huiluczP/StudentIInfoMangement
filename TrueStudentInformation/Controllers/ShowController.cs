using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueStudentInformation.Dao;
using TrueStudentInformation.Models;
using TrueStudentInformation.ViewModel;

namespace TrueStudentInformation.Controllers
{
    public class ShowController : Controller
    {
        StudentInfoAdapter adapter = new StudentInfoAdapter();

        // GET: Select
        public ActionResult Index()
        {
            return View();
        }

        //select页面,包括
        public ActionResult select()
        {
            List<Academy> academies=adapter.findAcademy();
            //设置下拉框值
            ViewData["selectitem"] = new SelectList(academies,"Id","Name");
            return View(academies);
        }

        //学生信息页面,显示树状控件
        public ActionResult showstudent(string academy)
        {
            List<Classroom> classes= adapter.findClassByAcaId(academy);
            WholeInfo info = new WholeInfo();
            info.id = academy;
            //item中包含对应班级类和学生对象
            info.Items = new List<StudentViewModel>();
            foreach(Classroom c in classes)
            {
                List<TrueStudent> stus = adapter.findStudentByclass(c);
                StudentViewModel model = new StudentViewModel();
                model.classroom = c;
                model.students = stus;
                info.Items.Add(model);
            }
            return View("showstudent",info);
        }
            
        //学生具体信息
        public ActionResult showstudentdetail(string id)
        {
            StudentDetail temple = adapter.findStudentByNum(id);
            if (temple == null)
                return View("error");
            else
                return View("studentdetail",temple);
        }


        public ActionResult test()
        {
            TrueStudent stu = new TrueStudent();
            stu.Name = "test";
            return View("test",stu);
        }
    }
}