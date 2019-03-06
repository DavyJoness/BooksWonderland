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
        public string Price { get; set; }
        public string Pages { get; set; }
        public string Describe { get; set; }



    }
}
