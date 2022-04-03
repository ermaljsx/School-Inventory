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
    public class MungesatsController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Mungesats
        public ActionResult Index()
        {
           /* using (Sekretaria_DemoEntities db = new Sekretaria_DemoEntities())
            {
                List<Mungesat> mungesats1 = db.Mungesats.ToList();
                List<Lenda> lendas = db.Lendas.ToList();
                List<Nxene> nxenes = db.Nxenes.ToList();

                var mungesatjoin = from n in nxenes
                                   join m in mungesats1 on n.id_nxenes equals m.id_nxenes into Nxenes
                                   from m in nxenes.ToList()

                                   select new ViewModel
                                   {
                                       nxenes = n,
                                       mungesats1 = m,

                                   };
                return View(mungesatjoin);*/

                var mungesats = db.Mungesats.Include(m => m.Lenda).Include(m => m.Nxene);
            return View(mungesats.ToList());
        }

        // GET: Mungesats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mungesat mungesat = db.Mungesats.Find(id);
            if (mungesat == null)
            {
                return HttpNotFound();
            }
            return View(mungesat);
        }

        // GET: Mungesats/Create
        public ActionResult Create()
        {
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes");
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer");
            return View();
        }

        // POST: Mungesats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mungesa,id_nxenes,id_lenda,Nr_Mungesave")] Mungesat mungesat)
        {
            if (ModelState.IsValid)
            {
                db.Mungesats.Add(mungesat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mungesat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", mungesat.id_nxenes);
            return View(mungesat);
        }

        // GET: Mungesats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mungesat mungesat = db.Mungesats.Find(id);
            if (mungesat == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mungesat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", mungesat.id_nxenes);
            return View(mungesat);
        }

        // POST: Mungesats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mungesa,id_nxenes,id_lenda,Nr_Mungesave")] Mungesat mungesat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mungesat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mungesat.id_lenda);
            ViewBag.id_nxenes = new SelectList(db.Nxenes, "id_nxenes", "emer", mungesat.id_nxenes);
            return View(mungesat);
        }

        // GET: Mungesats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mungesat mungesat = db.Mungesats.Find(id);
            if (mungesat == null)
            {
                return HttpNotFound();
            }
            return View(mungesat);
        }

        // POST: Mungesats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mungesat mungesat = db.Mungesats.Find(id);
            db.Mungesats.Remove(mungesat);
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
