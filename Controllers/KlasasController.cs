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
    public class KlasasController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Klasas
        public ActionResult Index()
        {
            var klasas = db.Klasas.Include(k => k.Mesuesi);
            return View(klasas.ToList());
        }

        // GET: Klasas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        // GET: Klasas/Create
        public ActionResult Create()
        {
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer");
            return View();
        }

        // POST: Klasas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_klasa,Viti,Grupi,id_mesuesi")] Klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Klasas.Add(klasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", klasa.id_mesuesi);
            return View(klasa);
        }

        // GET: Klasas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", klasa.id_mesuesi);
            return View(klasa);
        }

        // POST: Klasas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_klasa,Viti,Grupi,id_mesuesi")] Klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", klasa.id_mesuesi);
            return View(klasa);
        }

        // GET: Klasas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klasa klasa = db.Klasas.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        // POST: Klasas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klasa klasa = db.Klasas.Find(id);
            db.Klasas.Remove(klasa);
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
