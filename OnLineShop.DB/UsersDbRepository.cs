using OnLineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OnLineShop.DB
{
    public class UsersDbRepository : IUsersRepository
    {
        private readonly DatabaseContext databaseContext;

        public UsersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return databaseContext.Users.ToList();
        }

        public User TryGetByUserName(string userName)
        {
            return databaseContext.Users.FirstOrDefault(x => x.UserName == userName);
        }

		public User GetLastRegisteredUser()
		{
			return databaseContext.Users.OrderByDescending(x => x.Id).FirstOrDefault();
		}
	}
}
