using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetFreshBooks.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Categories = BusinessLogic.GetAllCategories;
            ViewBag.Books = BusinessLogic.GetAllBooks;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string isbn)
        {
            System.Diagnostics.Debug.WriteLine(isbn);
            BusinessLogic.AddToCart(isbn);
            ViewBag.Categories = BusinessLogic.GetAllCategories;
            ViewBag.Books = BusinessLogic.GetAllBooks;
            ViewData["addedToCart"] = true;
            return View("Index");         
        }

        public ActionResult About()
        {
            ViewBag.Message = "GetFreshBooks";

            return View();
        }
    }
}