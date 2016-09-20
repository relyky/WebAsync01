using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebAsync01.Models;

namespace WebAsync01.Controllers
{ 
    public class MyTable01Controller : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: MyTable01
        public ActionResult Index()
        {
            return View(db.MyTable01.ToList());
        }

        // GET: MyTable01/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = db.MyTable01.Find(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // GET: MyTable01/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTable01/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Value")] MyTable01 myTable01)
        {
            if (ModelState.IsValid)
            {
                db.MyTable01.Add(myTable01);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myTable01);
        }

        // GET: MyTable01/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = db.MyTable01.Find(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // POST: MyTable01/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Value")] MyTable01 myTable01)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTable01).State = EntityState.Modified;

                Thread.Sleep(10000); // wait 10 seconds.

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myTable01);
        }

        // GET: MyTable01/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = db.MyTable01.Find(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // POST: MyTable01/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyTable01 myTable01 = db.MyTable01.Find(id);
            db.MyTable01.Remove(myTable01);
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
