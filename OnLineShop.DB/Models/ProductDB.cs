using System;
using System.Collections.Generic;

namespace OnLineShop.DB.Models
{
    public class ProductDB
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string URLImage { get; set; }
        public List<CartDBItem> Items { get; set; }

        public ProductDB() 
        { 
            Items= new List<CartDBItem>();  
        }
    }
}
