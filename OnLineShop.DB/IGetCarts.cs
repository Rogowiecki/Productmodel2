

namespace OnLineShop.DB.Models
{
    public interface IGetCarts
    {
        public CartDB TryGetByUserId(string user);
        public void Add(ProductDB product, string userId);
    }
}
