using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1_SailorMoon.Models;

namespace S1_SailorMoon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new SailorMoonContext())
            {
                ViewBag.SailorSenshis = db.SailorSenshis
                    .OrderBy(s => s.Nombre)
                    .ToList();

                ViewBag.Aliados = db.Aliados
                    .OrderBy(a => a.NombreAliado)
                    .ToList();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}