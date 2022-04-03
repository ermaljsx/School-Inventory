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
    public class AuditorisController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Auditoris
        public ActionResult Index()
        {
            var auditoris = db.Auditoris.Include(a => a.Klasa).Include(a => a.Mesuesi).Include(a => a.Nxene);
            return View(auditoris.ToList());
        }

        // GET: Auditoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditori auditori = db.Auditoris.Find(id);
            if (auditori == null)
            {
                return HttpNotFound();
            }
            return View(auditori);
        }

        // GET: Auditoris/Create
        public ActionResult Create()
        {
            ViewBag.id_klasa = new SelectList(db.Klasas, "id_klasa", "Grupi");
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer");
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer");
            return View();
        }

        // POST: Auditoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_auditori,id_klasa,id_nxenes,id_mesuesi")] Auditori auditori)
        {
            if (ModelState.IsValid)
            {
                db.Auditoris.Add(auditori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_klasa = new SelectList(db.Klasas, "id_klasa", "Grupi", auditori.id_klasa);
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", auditori.id_mesuesi);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", auditori.id_nxenes);
            return View(auditori);
        }

        // GET: Auditoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditori auditori = db.Auditoris.Find(id);
            if (auditori == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_klasa = new SelectList(db.Klasas, "id_klasa", "Grupi", auditori.id_klasa);
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", auditori.id_mesuesi);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", auditori.id_nxenes);
            return View(auditori);
        }

        // POST: Auditoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_auditori,id_klasa,id_nxenes,id_mesuesi")] Auditori auditori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_klasa = new SelectList(db.Klasas, "id_klasa", "Grupi", auditori.id_klasa);
            ViewBag.id_mesuesi = new SelectList(db.Mesuesis, "id_mesuesi", "emer", auditori.id_mesuesi);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", auditori.id_nxenes);
            return View(auditori);
        }

        // GET: Auditoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditori auditori = db.Auditoris.Find(id);
            if (auditori == null)
            {
                return HttpNotFound();
            }
            return View(auditori);
        }

        // POST: Auditoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditori auditori = db.Auditoris.Find(id);
            db.Auditoris.Remove(auditori);
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
