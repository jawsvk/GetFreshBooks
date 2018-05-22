using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetFreshBooks
{
    using GetFreshBooks.Models;
    public class BusinessLogic
    {
        Mybooks context = new Mybooks();

        public List<Book> GetAllBooks
        {
            get
            {
                return context.Books.ToList<Book>();
            }
        }
        public List<Book> GetAllCategories
        {
            get
            {
                return context.Categories.ToList<Category>();
            }
        }
    }
}