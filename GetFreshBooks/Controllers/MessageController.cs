using GetFreshBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetFreshBooks.Controllers
{
    public class MessageController : Controller
    {
        Mybooks context = new Mybooks();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.MessageDateTime = DateTime.Now;

                context.Messages.Add(message);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(message);
        }
    }
}