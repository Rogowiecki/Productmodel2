using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnLineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.DB
{
    public interface IUsersRepository
    {
        public void Add(User user);
        List<User> GetAll();
        User TryGetByUserName(string userName);
		User GetLastRegisteredUser();  // метод для получения последнего зарегистрированного пользователя
	}
}
