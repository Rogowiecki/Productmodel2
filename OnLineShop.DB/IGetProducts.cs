using OnLineShop.DB.Models;
using System.Collections.Generic;

namespace OnLineShop.DB
{
    public interface IGetProducts
    {
        public List<ProductDB> GetProducts();
        public ProductDB TryGetById(int IdProduct);
        public void Add(ProductDB product);
    }
}
