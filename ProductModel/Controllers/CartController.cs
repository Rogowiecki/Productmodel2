using Microsoft.AspNetCore.Mvc;
using OnLineShop.DB;
using OnLineShop.DB.Models;
using ProductModel.Helpers;
using ProductModel.Models;


namespace ProductModel.Controllers
{
    public class CartController : Controller
    {
        public readonly IGetProducts ProductRepository;
        public readonly IGetCarts CartRepository; 
        public CartController(IGetProducts products, IGetCarts carts)
        {
            this.ProductRepository = products;
            this.CartRepository = carts;
        }

        public IActionResult Index()
        {
            CartDB cart = CartRepository.TryGetByUserId("md");
            return View(Mapping.CardDBToCart(cart));
        }

        public IActionResult Add(int idProduct)
        {
            ProductDB item = ProductRepository.TryGetById(idProduct);
            CartRepository.Add(item,"md");
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseProduct(int idProduct)
        {
            //Cart cart = carts.GetCart(Constants.MD);
            //cart.DecreaseProduct(idProduct);
            //return RedirectToAction("Index");
            return View();
        }

        public IActionResult Delete()
        {
            //Cart cart = carts.GetCart(Constants.MD);
            //cart.Clear();
            //return RedirectToAction("Index");
            return View();
        }
    }
}
