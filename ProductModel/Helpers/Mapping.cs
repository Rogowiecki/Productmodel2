using Microsoft.AspNetCore.Http.Connections;
using OnLineShop.DB.Models;
using ProductModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductModel.Helpers
{
    public class Mapping
    {
        public static Product ProductDBToProduct(ProductDB product)
        {
            return new Product
            {
                Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                URLImage = product.URLImage
            };
        }
        public static List<Product> ListProductDBToListProduct(List<ProductDB> products)
        {
            //var productsView = new List<Product>();
            //foreach (var item in products)
            //    productsView.Add(ProductDBToProduct(item));
            //return productsView;

            return products.Select(ProductDBToProduct).ToList();
        }

        public static ProductDB ProductToProductDB(Product productView)
        {
            return new ProductDB
            {
                // Id = 100,
                Name = productView.Name,
                Description = productView.Description,
                Cost = productView.Cost,
                URLImage = "https://avatars.mds.yandex.net/i?id=766637e7fecd215c2916b5d4741bd5f4_l-5282144-images-thumbs&n=27&h=480&w=480"
            };
        }

        public static Cart CardDBToCart(CartDB cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new Cart
            {
                Id = cart.Id,
                User = cart.User,
                Products = ListCartDBItemToListCart(cart.Products)
            };
        }

        public static CartItem CardDBItemToCartItem(CartDBItem cart)
        {
            return new CartItem
            {
                Amount = cart.Amount,
                Id = cart.Id,
                Product = ProductDBToProduct(cart.Product)
            };
        }

        public static List<CartItem> ListCartDBItemToListCart(List<CartDBItem> cartDBItems)
        {
            return cartDBItems.Select(CardDBItemToCartItem).ToList();
        }
    }
}
