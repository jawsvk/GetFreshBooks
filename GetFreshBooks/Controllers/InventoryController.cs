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
        BookshopEntities context = new BookshopEntities();
        // GET: Inventory
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Detail(int bookid)
        {

            return PartialView(@"~/Views/Shared/_EditPopup.cshtml", context.Books.Where(p => p.BookID == bookid).First());
        }
    }
}