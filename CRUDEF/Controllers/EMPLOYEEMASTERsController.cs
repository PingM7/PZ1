using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDEF.Models;

namespace CRUDEF.Controllers
{
    public class EMPLOYEEMASTERsController : Controller
    {
        private CrudEFEntities db = new CrudEFEntities();

        // GET: EMPLOYEEMASTERs
        public ActionResult Index()
        {
            return View(db.EMPLOYEEMASTERs.ToList());
        }

        // GET: EMPLOYEEMASTERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // GET: EMPLOYEEMASTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLOYEEMASTERs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEEMASTERs.Add(eMPLOYEEMASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEEMASTER);
        }

        // GET: EMPLOYEEMASTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // POST: EMPLOYEEMASTERs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEEMASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEEMASTER);
        }

        // GET: EMPLOYEEMASTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // POST: EMPLOYEEMASTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            db.EMPLOYEEMASTERs.Remove(eMPLOYEEMASTER);
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
