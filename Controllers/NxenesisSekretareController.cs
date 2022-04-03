using Sekretari_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sekretari_Demo.Controllers
{
    public class NxenesisSekretareController : Controller
    {
        private Sekretaria_DemoEntities db = new Sekretaria_DemoEntities();
        // GET: NxenesisSekretare
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }

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
    }
}