using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_one.Models;

namespace mvc_one.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var ctx = new GuestbookContext();

            var entry = new GuestbookEntry { Message = "TEST", Name = "TEST NAME" };

            ctx.Entries.Add(entry);

            ctx.SaveChanges();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
