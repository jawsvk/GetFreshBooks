using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetFreshBooks
{
    public class CartBook
    {
        string isbn;
        string bookName;
        string author;
        double price;
        int quantity;



        public CartBook(string isbn, string name, string author, double price)
        {
            this.isbn = isbn;
            bookName = name;
            this.author = author;
            this.price = price;
            this.quantity = 1;
        }

        public CartBook() : this("", "", "", 0.0)
        {
            this.quantity = 0;
        }

        public string Isbn
        {
            get { return isbn; }
        }
        public string BookName
        {
            get { return bookName; }

        }

        public string Author
        {
            get { return author; }
        }

        public double Price
        {
            get { return price; }

        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}