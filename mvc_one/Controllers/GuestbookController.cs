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

        private List<GuestbookEntry> GetRecentEntries()
        {
            return (from entry in _db.Entries
                orderby entry.DateAdded descending
                select entry).Take(20).ToList();
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
            ViewBag.Entries = GetRecentEntries();
            return View("Index");
        }

    }
}
