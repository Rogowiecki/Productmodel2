using Microsoft.AspNetCore.Mvc;
using ProductModel.Models;
using OnLineShop.DB.Models;
using OnLineShop.DB;
using ProductModel.Helpers;
using System.Collections.Generic;

namespace ProductModel.Controllers
{
    public class AdminController : Controller
    {
        public readonly IGetProducts RepositoryProductDBs;
        public readonly IUsersRepository usersRepository;

        public AdminController(IGetProducts repositoryProductDBs, IUsersRepository usersRepository)
        {
            RepositoryProductDBs = repositoryProductDBs;
            this.usersRepository = usersRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
			var users = usersRepository.GetAll();

			var UsersViewModel = new List<UserViewModel>();
			foreach (var user in users)
			{
				UsersViewModel.Add(new UserViewModel { Id = user.Id, UserName = user.UserName, Password = user.Password });
			}
			return View(UsersViewModel);
		}

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {

            return View(Mapping.ListProductDBToListProduct(RepositoryProductDBs.GetProducts()));
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // если не прошел валидацию возвращаем на ту же вьюшку для редактирования
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            // тут сохранить продукт в product DB
            RepositoryProductDBs.Add(Mapping.ProductToProductDB(product));
            return RedirectToAction("Index", "Product");
        }
    }

}
