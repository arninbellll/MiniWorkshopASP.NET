using MiniWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniWS.Controllers
{
    public class HomeController : Controller
    {
        private AppDb db = new AppDb();
        public ActionResult Index()
        {
            var product = db.Products; 

            return View(product.ToList());
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