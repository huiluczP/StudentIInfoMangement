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
    public class ClassroomsController : Controller
    {
        private TrueStudentInformationContext db = new TrueStudentInformationContext();

        // GET: Classrooms
        public ActionResult Index()
        {
            return View(db.Classrooms.ToList());
        }

        // GET: Classrooms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: Classrooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classrooms/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Academy")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classroom);
        }

        // GET: Classrooms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Academy")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classroom);
        }

        // GET: Classrooms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Classroom classroom = db.Classrooms.Find(id);
            db.Classrooms.Remove(classroom);
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
