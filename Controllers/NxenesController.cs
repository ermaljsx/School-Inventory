using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sekretari_Demo.Models;

namespace Sekretari_Demo.Controllers
{
    public class NxenesController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Nxenes
        public ActionResult Index()
        {
            return View(db.Nxenes.ToList());
        }

        // GET: Nxenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nxene nxene = db.Nxenes.Find(id);
            if (nxene == null)
            {
                return HttpNotFound();
            }
            return View(nxene);
        }

        // GET: Nxenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nxenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nxenes,emer,mbiemer")] Nxene nxene)
        {
            if (ModelState.IsValid)
            {
                db.Nxenes.Add(nxene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nxene);
        }

        // GET: Nxenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nxene nxene = db.Nxenes.Find(id);
            if (nxene == null)
            {
                return HttpNotFound();
            }
            return View(nxene);
        }

        // POST: Nxenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nxenes,emer,mbiemer")] Nxene nxene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nxene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nxene);
        }

        // GET: Nxenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nxene nxene = db.Nxenes.Find(id);
            if (nxene == null)
            {
                return HttpNotFound();
            }
            return View(nxene);
        }

        // POST: Nxenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nxene nxene = db.Nxenes.Find(id);
            db.Nxenes.Remove(nxene);
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

        public JsonResult Search(string bookTitle)
        {
            var SearchData = !db.Nxenes.Where(x => (x.emer == bookTitle)).Any();
            return Json(SearchData, JsonRequestBehavior.AllowGet);
        }
    }
}
