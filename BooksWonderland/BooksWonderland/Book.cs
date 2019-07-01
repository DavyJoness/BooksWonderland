using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWonderland
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string _price;
        public string Pages { get; set; }
        public string Describe { get; set; }

        public string Price
        {
            get
            {
                return Convert.ToDecimal(_price).ToString("0.00");
            }
            set
            {
                _price = value;
            }
        }
    }

    public class Authors
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public Authors(int i, string a)
        {
            Id = i;
            Author = a;
        }
    }

    public class Genres
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public Genres(int i, string a)
        {
            Id = i;
            Genre = a;
        }
    }

    public class Publishers
    {
        public int Id { get; set; }
        public string Publisher { get; set; }

        public Publishers(int i, string a)
        {
            Id = i;
            Publisher = a;
        }
    }
}
