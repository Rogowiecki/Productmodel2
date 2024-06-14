using System;
using System.Collections.Generic;
using System.Linq;

namespace OnLineShop.DB.Models
{

    public class CartDB
    {
        public int Id { get; set; }
        public string User { get; set; }
        public List<CartDBItem> Products { get; set; }
       
        public CartDB()
        {
            Products = new List<CartDBItem>();
        }
    }
}
