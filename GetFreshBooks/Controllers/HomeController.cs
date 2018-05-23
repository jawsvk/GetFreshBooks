using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GetFreshBooks.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session[System.Web.HttpContext.Current.User.Identity.GetUserId()] == null)
            {
                System.Web.HttpContext.Current.Session[System.Web.HttpContext.Current.User.Identity.GetUserId()] = new List<CartBook>();
                System.Web.HttpContext.Current.Session["total"+ System.Web.HttpContext.Current.User.Identity.GetUserId()] = 0;

            }

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