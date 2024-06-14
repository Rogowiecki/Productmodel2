using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductModel.Models
{

    public class Cart
    {
        public int Id { get; set; }
        public string User { get; set; }
        public List<CartItem> Products { get; set; }
        public decimal TotalCost { get; set; }

      
       // public void DecreaseProduct(int idProduct)
       // {
       //     CartItem elem = this.TryGetByIdProduct(idProduct);
       //     if (elem == null) return;
       //     elem.Quantity -= 1;
       //     elem.Amount = elem.Quantity * elem.Product.Cost;
       //     if (elem.Quantity == 0)
       //     {
       //         Products.Remove(elem);
       //     }
       //     TotalCost = Products.Sum(k => k.Amount);
       // }

       // public void Clear()
       // {
       //     this.Products.Clear();
       //     this.TotalCost = 0;
       // }

       // public CartItem TryGetByIdProduct(int idProduct)
       // {
       //     foreach (var elem in Products)
       //     {
       //         if (elem.Product.Id == idProduct)
       //             return elem;
       //     }
       //     return null;
       // }
    }
}
