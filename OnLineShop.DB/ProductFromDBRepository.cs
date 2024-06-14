using Microsoft.EntityFrameworkCore;
using OnLineShop.DB.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnLineShop.DB
{
    public class ProductFromDBRepository : IGetProducts
    {
        static List<ProductDB> pp = new List<ProductDB>();
        private readonly DatabaseContext databaseContext;

        public ProductFromDBRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(ProductDB product)
        { 
            databaseContext.ProductDBs.Add(product);
            databaseContext.SaveChanges();
        }

        public List<ProductDB> GetProducts()
        {
            return databaseContext.ProductDBs.ToList();
        }

        public ProductDB TryGetById(int IdProduct)
        {
            return databaseContext.ProductDBs.FirstOrDefault(item => item.Id == IdProduct);
        }
    }
}
