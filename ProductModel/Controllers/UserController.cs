using Microsoft.AspNetCore.Mvc;
using OnLineShop.DB;
using OnLineShop.DB.Models;

namespace ProductModel.Controllers
{
	public class UserController : Controller
	{
		private readonly IUsersRepository usersRepository;

		public UserController(IUsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
		}

		public IActionResult Index()
		{
			var lastUser = usersRepository.GetLastRegisteredUser();
			return View(lastUser);
		}
	}
}
