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
    public class LendasController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Lendas
        public ActionResult Index()
        {
            return View(db.Lendas.ToList());
        }

        // GET: Lendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenda lenda = db.Lendas.Find(id);
            if (lenda == null)
            {
                return HttpNotFound();
            }
            return View(lenda);
        }

        // GET: Lendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lenda,emri_lendes,oret_javore,semestri")] Lenda lenda)
        {
            if (ModelState.IsValid)
            {
                db.Lendas.Add(lenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lenda);
        }

        // GET: Lendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenda lenda = db.Lendas.Find(id);
            if (lenda == null)
            {
                return HttpNotFound();
            }
            return View(lenda);
        }

        // POST: Lendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lenda,emri_lendes,oret_javore,semestri")] Lenda lenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lenda);
        }

        // GET: Lendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenda lenda = db.Lendas.Find(id);
            if (lenda == null)
            {
                return HttpNotFound();
            }
            return View(lenda);
        }

        // POST: Lendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lenda lenda = db.Lendas.Find(id);
            db.Lendas.Remove(lenda);
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
