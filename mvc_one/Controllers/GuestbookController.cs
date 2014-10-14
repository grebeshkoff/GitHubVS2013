using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_one.Models;

namespace mvc_one.Controllers
{
    public class GuestbookController : Controller
    {
        GuestbookContext _db = new GuestbookContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return View();
        }

    }
}
