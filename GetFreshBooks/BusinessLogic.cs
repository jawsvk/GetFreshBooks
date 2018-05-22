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

        public List<Book> GetAll
        {
            get
            {
                return context.Books.ToList<Book>();
            }
        }
    }
}