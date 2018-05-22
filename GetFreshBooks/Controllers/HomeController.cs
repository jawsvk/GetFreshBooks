using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetFreshBooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Books = BusinessLogic.GetAll;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string isbn)
        {
            System.Diagnostics.Debug.WriteLine(isbn);
            BusinessLogic.AddToCart(isbn);
            ViewBag.Books = BusinessLogic.GetAll;
            return View("Index");         
        }

        // [Authorize(Roles ="User,Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "GetFreshBooks";

            return View();
        }
    }
}