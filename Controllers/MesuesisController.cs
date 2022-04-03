using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sekretari_Demo.Models;

namespace Sekretari_Demo.Controllers
{
    public class MesuesisController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();

        // GET: Mesuesis
        public ActionResult Index()
        {
            var mesuesis = db.Mesuesis.Include(m => m.Lenda);
            return View(mesuesis.ToList());
        }

        // GET: Mesuesis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesuesi mesuesi = db.Mesuesis.Find(id);
            if (mesuesi == null)
            {
                return HttpNotFound();
            }
            return View(mesuesi);
        }

        // GET: Mesuesis/Create
        public ActionResult Create()
        {
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes");
            return View();
        }

        // POST: Mesuesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mesuesi,emer,mbiemri,Nr_Telefoni,email,id_lenda")] Mesuesi mesuesi)
        {
           
                if (ModelState.IsValid)
            {
                SqlConnection con = new SqlConnection();
                SqlCommand com = new SqlCommand();
                SqlDataReader dr;
                string b;
                
                void connectionString()
                {
                    con.ConnectionString = @"data source=GENTIGJ\SQLEXPRESS;database=Sekretaria Demo;integrated security = SSPI;";
                }
                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "select id_mesuesi from Mesuesi";
                dr = com.ExecuteReader();
                b=dr.ToString();

                com.CommandText = "insert into Mesuesis (id_mesuesi) values '" + b + "' ";
                db.Mesuesis.Add(mesuesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mesuesi.id_lenda);
            return View(mesuesi);
        }

        // GET: Mesuesis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesuesi mesuesi = db.Mesuesis.Find(id);
            if (mesuesi == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mesuesi.id_lenda);
            return View(mesuesi);
        }

        // POST: Mesuesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mesuesi,emer,mbiemri,Nr_Telefoni,email,id_lenda")] Mesuesi mesuesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesuesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_lenda = new SelectList(db.Lendas, "id_lenda", "emri_lendes", mesuesi.id_lenda);
            return View(mesuesi);
        }

        // GET: Mesuesis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesuesi mesuesi = db.Mesuesis.Find(id);
            if (mesuesi == null)
            {
                return HttpNotFound();
            }
            return View(mesuesi);
        }

        // POST: Mesuesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesuesi mesuesi = db.Mesuesis.Find(id);
            db.Mesuesis.Remove(mesuesi);
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
