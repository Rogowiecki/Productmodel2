using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OnLineShop.DB.Models
{
    public class CartsFromDBRepository:IGetCarts
    {
        DatabaseContext dbContext;

        public CartsFromDBRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(ProductDB product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Products.FirstOrDefault(item => item.Product == product);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    var newCartItem = new CartDBItem
                    {
                        Amount = 1,
                        Product = product
                    };
                    existingCart.Products.Add(newCartItem);
                }
            }
            else 
            {
                var newCartItem = new CartDBItem
                {
                    Amount = 1,
                    Product = product
                };
                var newCart = new CartDB
                {
                    User = userId,
                    Products = new List<CartDBItem>() { newCartItem }
                };
                
                dbContext.CartDBs.Add(newCart);
            }
            dbContext.SaveChanges();
        }

        public CartDB TryGetByUserId(string user)
        {
            return dbContext.CartDBs.Include(x => x.Products)
                                    .ThenInclude(x => x.Product)
                                    .FirstOrDefault(item => item.User == user);
        }
    }
}
