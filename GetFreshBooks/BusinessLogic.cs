using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetFreshBooks
{
    using GetFreshBooks.Models;
    public static class BusinessLogic
    {
        static Mybooks context = new Mybooks(); 

        public static List<Book> GetAll
        {
            get
            {
                return context.Books.ToList<Book>();
            }
        }

        public static void AddToCart(string isbn)
        {
            if (HttpContext.Current.Session["items"] == null)
            {
                HttpContext.Current.Session["items"] = new List<CartBook>();
                HttpContext.Current.Session["total"] = 0;
            }

            List<CartBook> cBookList = (List<CartBook>)HttpContext.Current.Session["items"];

            bool found = false;

            foreach (CartBook c in cBookList)
            {
                if (c.Isbn == isbn)
                {
                    c.Quantity++;
                    found = true;
                    CalculatePrice(c.Price, 1);
                    break;
                }
            }

            if (!found)
            {
                var query = from c in context.Books where c.ISBN == isbn select c;
                Book book = query.First();
                CartBook cbook = new CartBook(book.ISBN, book.Title, book.Author, (double)book.Price);
                cBookList.Add(cbook);
                CalculatePrice(cbook.Price, 1);

            }

            HttpContext.Current.Session["items"] = cBookList;

        }

        public static void DeleteFromCart(string isbn)
        {

            List<CartBook> cBookList = (List<CartBook>)HttpContext.Current.Session["items"];
            foreach (CartBook c in cBookList)
            {
                if (c.Isbn == isbn)
                {
                    cBookList.Remove(c);
                    HttpContext.Current.Session["total"] = (double)HttpContext.Current.Session["total"] - (c.Price * c.Quantity);

                    break;
                }

            }

            HttpContext.Current.Session["items"] = cBookList;

        }

        public static void CheckoutCart()
        {
            HttpContext.Current.Session["items"] = null;
            HttpContext.Current.Session["total"] = null;
        }

        public static void CalculatePrice(double price, int quantity)
        {
            HttpContext.Current.Session["total"] = Convert.ToDouble(HttpContext.Current.Session["total"]) + price * quantity;

        }
    }
}