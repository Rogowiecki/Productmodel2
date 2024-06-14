using Microsoft.AspNetCore.Mvc;
using OnLineShop.DB;
using OnLineShop.DB.Models;
using ProductModel.Helpers;
using ProductModel.Models;
using System.Collections.Generic;

namespace ProductModel.Controllers
{
    public class ProductController : Controller
    {
        public readonly IGetProducts listProductDBs;

        public ProductController(IGetProducts list_ProductDBs)
        { 
            this.listProductDBs = list_ProductDBs;
        }

        public IActionResult Index()
        {
           return View(Mapping.ListProductDBToListProduct(listProductDBs.GetProducts()));
           //return View();
        }

        public IActionResult Details(int id)
        {
            //return View(listProducts.TryGetById(id));
            return View();
        }
    }
}
