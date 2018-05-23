using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GetFreshBooks.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(string isbn)
        {
            BusinessLogic.DeleteFromCart(isbn);
            return View("Index");
        }

        public ActionResult CheckOut()
        {
            string user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            List<CartBook> clist = (List<CartBook>)System.Web.HttpContext.Current.Session[user];
            
                BusinessLogic.CheckoutCart();
                Random rnd = new Random();
                ViewBag.Invoice = rnd.Next(123456789, 987654321);
                return View();
            
        }
        
    }
}