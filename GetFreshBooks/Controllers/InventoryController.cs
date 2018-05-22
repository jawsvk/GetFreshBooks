using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetFreshBooks.Controllers
{
    using Models;
   

    public class InventoryController : Controller
    {
        BookshopEntities db = new BookshopEntities();
        // GET: Inventory
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult loaddata()
        {
          
            {
                db.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var data = db.Books.OrderBy(a => a.BookID).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        
    }
}