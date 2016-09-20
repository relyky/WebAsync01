using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAsync01.Models;

namespace WebAsync01.Controllers
{
    public class MyTable01AsyncController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: MyTable01Async
        public async Task<ActionResult> Index()
        {
            return View(await db.MyTable01.ToListAsync());
        }

        // GET: MyTable01Async/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = await db.MyTable01.FindAsync(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // GET: MyTable01Async/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTable01Async/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Value")] MyTable01 myTable01)
        {
            if (ModelState.IsValid)
            {
                db.MyTable01.Add(myTable01);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myTable01);
        }

        // GET: MyTable01Async/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = await db.MyTable01.FindAsync(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // POST: MyTable01Async/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Value")] MyTable01 myTable01)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTable01).State = EntityState.Modified;

                await Task.Delay(10000); // wait 10 seconds.

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(myTable01);
        }

        // GET: MyTable01Async/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTable01 myTable01 = await db.MyTable01.FindAsync(id);
            if (myTable01 == null)
            {
                return HttpNotFound();
            }
            return View(myTable01);
        }

        // POST: MyTable01Async/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyTable01 myTable01 = await db.MyTable01.FindAsync(id);
            db.MyTable01.Remove(myTable01);
            await db.SaveChangesAsync();
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
