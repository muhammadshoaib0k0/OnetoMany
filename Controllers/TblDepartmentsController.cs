using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnetoMany;

namespace OnetoMany.Controllers
{
    public class TblDepartmentsController : Controller
    {
        private OnetoManyDBEntities db = new OnetoManyDBEntities();

        // GET: TblDepartments
        public ActionResult Index()
        {
            return View(db.TblDepartments.ToList());
        }

        // GET: TblDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDepartment tblDepartment = db.TblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // GET: TblDepartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dept_Id,Dept_Name,Dept_Head,Location")] TblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.TblDepartments.Add(tblDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDepartment);
        }

        // GET: TblDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDepartment tblDepartment = db.TblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: TblDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dept_Id,Dept_Name,Dept_Head,Location")] TblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDepartment);
        }

        // GET: TblDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDepartment tblDepartment = db.TblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: TblDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblDepartment tblDepartment = db.TblDepartments.Find(id);
            db.TblDepartments.Remove(tblDepartment);
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
