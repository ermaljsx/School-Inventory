using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sekretari_Demo.Controllers
{
    public class HomeSekretareController : Controller
    {
        // GET: HomeSekretare
        public ActionResult Index()
        {
            return View();
        }
    }
}