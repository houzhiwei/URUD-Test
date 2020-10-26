using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pazzo_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "應用程式";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "聯絡窗口";

            return View();
        }
    }
}