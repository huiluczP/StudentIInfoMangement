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

        //GET
        public ActionResult select()
        {
            List<Academy> academies=adapter.findAcademy();
            //设置下拉框值
            ViewData["selectitem"] = new SelectList(academies,"Id","Name");
            ViewBag.username = Session["username"];
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

        public ActionResult logincheck(string name,string password)
        {
            if (adapter.checkLogin(name, password))
            {
                ViewBag.username = name;
                List<Academy> academies = adapter.findAcademy();
                ViewData["selectitem"] = new SelectList(academies, "Id", "Name");
                return View("select",academies);
            }
            else
            {
                ViewBag.warning = "用户名或密码错误";
                return View("login");
            }
        }

        //GET
        public ActionResult login()
        {
            return View("login");
        }

        //GET
        public ActionResult register()
        {
            return View("register");
        }

        public ActionResult insertUser(string username,string password)
        {
            bool ready = adapter.insertUser(username,password);
            if (ready)
            {
                ViewBag.username = username;
                List<Academy> academies = adapter.findAcademy();
                //设置下拉框值
                ViewData["selectitem"] = new SelectList(academies, "Id", "Name");
                return View("select");
            }
            else
            {
                ViewBag.Warning = "注册失败";
                return View("register");
            }
        }

        //修改成绩
        public ActionResult changeScore(string num, string first, string second, string third)
        {
            if (!adapter.UpdateGrade(num, first, second, third))
            {
                ViewBag.warning = "修改错误";
            }
            StudentDetail temple = adapter.findStudentByNum(num);
            ViewBag.num = num;
            ViewBag.first = first;
            ViewBag.tip = "更新成功";
            if (num == null)
            {
                ViewBag.temple = "我服了";
            }
            if (temple == null)
                return View("error");
            else
                return View("studentdetail", temple);
        }
    }
}