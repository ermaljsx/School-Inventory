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
    public class NotatsController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Notats
        public ActionResult Index()
        {
            var notats = db.Notats.Include(n => n.Lenda).Include(n => n.Nxene);
            return View(notats.ToList());
        }

        // GET: Notats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notat notat = db.Notats.Find(id);
            if (notat == null)
            {
                return HttpNotFound();
            }
            return View(notat);
        }

        // GET: Notats/Create
        public ActionResult Create()
        {
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes");
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer");
            return View();
        }

        // POST: Notats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nota,id_nxenes,id_lenda,Nota")] Notat notat)
        {
            if (ModelState.IsValid)
            {
                db.Notats.Add(notat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", notat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", notat.id_nxenes);
            return View(notat);
        }

        // GET: Notats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notat notat = db.Notats.Find(id);
            if (notat == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", notat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", notat.id_nxenes);
            return View(notat);
        }

        // POST: Notats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nota,id_nxenes,id_lenda,Nota")] Notat notat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", notat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", notat.id_nxenes);
            return View(notat);
        }

        // GET: Notats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notat notat = db.Notats.Find(id);
            if (notat == null)
            {
                return HttpNotFound();
            }
            return View(notat);
        }

        // POST: Notats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notat notat = db.Notats.Find(id);
            db.Notats.Remove(notat);
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
