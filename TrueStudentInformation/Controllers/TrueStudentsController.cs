using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrueStudentInformation.Models;

namespace TrueStudentInformation.Controllers
{
    public class TrueStudentsController : Controller
    {
        private TrueStudentInformationContext db = new TrueStudentInformationContext();

        // GET: TrueStudents
        public ActionResult Index()
        {
            return View(db.TrueStudents.ToList());
        }

        // GET: TrueStudents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueStudent trueStudent = db.TrueStudents.Find(id);
            if (trueStudent == null)
            {
                return HttpNotFound();
            }
            return View(trueStudent);
        }

        // GET: TrueStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrueStudents/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num,Name,Age,Gender,Firstscore,Secondscore,Thirdscore,Classroomid")] TrueStudent trueStudent)
        {
            if (ModelState.IsValid)
            {
                db.TrueStudents.Add(trueStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trueStudent);
        }

        // GET: TrueStudents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueStudent trueStudent = db.TrueStudents.Find(id);
            if (trueStudent == null)
            {
                return HttpNotFound();
            }
            return View(trueStudent);
        }

        // POST: TrueStudents/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num,Name,Age,Gender,Firstscore,Secondscore,Thirdscore,Classroomid")] TrueStudent trueStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trueStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trueStudent);
        }

        // GET: TrueStudents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueStudent trueStudent = db.TrueStudents.Find(id);
            if (trueStudent == null)
            {
                return HttpNotFound();
            }
            return View(trueStudent);
        }

        // POST: TrueStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TrueStudent trueStudent = db.TrueStudents.Find(id);
            db.TrueStudents.Remove(trueStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
