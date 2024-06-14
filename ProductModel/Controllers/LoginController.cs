using Microsoft.AspNetCore.Mvc;
using ProductModel.Models;
using System;
using System.Linq;
using OnLineShop.DB.Models;
using OnLineShop.DB;

namespace ProductModel.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public LoginController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login data)
        {
            var user = usersRepository.TryGetByUserName(data.UserName);
            if (ModelState.IsValid && user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(Register data)
        {
            var user = usersRepository.TryGetByUserName(data.UserName);
          
            
            if (data.UserName==data.Password) 
            {
                ModelState.AddModelError("","Пароль и логин не должны совпадать!");
            }

            if (user != null)
            {
                ModelState.AddModelError("", "Аккаунт уже зарегистрирован!");
            }

            if (ModelState.IsValid)
            {
                var newUser = new OnLineShop.DB.Models.User
                {
                    UserName = data.UserName,
                    Password = data.Password
                };
                usersRepository.Add(newUser);
                return RedirectToAction("Index", "Home");
            }

            //ModelState.AddModelError("", String.Join("\n", ModelState.Values.SelectMany(e=>e.Errors).Select(e=>e.ErrorMessage)));
            return View("RegForm");
        }
    }
}
