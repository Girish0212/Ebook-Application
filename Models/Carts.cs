using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebook_Application.Models
{
    public class Carts
    {
        public  List<CartModel> CartModels { get; set; }
        public double CartTotal { get; set; }

    }
}