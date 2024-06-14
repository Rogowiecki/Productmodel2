using System;

namespace OnLineShop.DB.Models
{
    public class CartDBItem
    {
        public int Id { get; set; }
        public ProductDB Product { get; set; }
        public int Amount { get; set; }
    }
}
