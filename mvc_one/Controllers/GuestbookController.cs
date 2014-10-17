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
            ViewBag.Entries = GetRecentEntries();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ViewResult Show(GuestbookEntry guestbookEntry)
        {
            var entry = _db.Entries.Find(guestbookEntry);

            bool hasPermissions = User.Identity.Name == entry.Name;

            ViewData["HasPermissions"] = hasPermissions;

            return View(entry);
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            _db.Entries.Add(entry);
            _db.SaveChanges();
            ViewBag.Entries = GetRecentEntries();
            return View("Index");
        }


        private List<GuestbookEntry> GetRecentEntries()
        {
            return (from entry in _db.Entries
                    orderby entry.DateAdded descending
                    select entry).Take(20).ToList();
        }

    }
}
