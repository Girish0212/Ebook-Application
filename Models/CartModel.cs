using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebook_Application.Models
{
    public class CartModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        


    }
}