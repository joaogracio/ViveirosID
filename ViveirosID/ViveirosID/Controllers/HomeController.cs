using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViveirosID.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Como chegamos até aqui.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Como entrar em contacto com nosco.";

            return View();
        }
    }
}