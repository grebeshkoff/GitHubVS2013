using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_one.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("guestbook")
        {
        }

        DbSet<GuestbookEntry> Entries { get; set; }
    }
}