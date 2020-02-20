using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Interfaces;
using Nest.Models;

namespace Nest.API.Concrete {
	public class UserRepository : IUserRepository {
		private readonly NestContext nest = new NestContext();

		public DbSet<User> Users { get { return nest.Users; } }

		public User CreateOrUpdate(User u) {
			if (u.Id < 0) return Create(u);
			return Update(u);
		}

		public User Create(User u) {
			User user = Users.Add(u);
			nest.SaveChanges();
			return user;
		}

		public User Update(User u) {
			User user = Users.Find(u.Id);
			if (user == null) return null;
			user.Handle = u.Handle;
			user.Email = u.Email;
			user.Password = u.Password;
			user.Role = u.Role;
			user.Icon = u.Icon;
			user.Buzzing = u.Buzzing;
			nest.SaveChanges();
			return user;
		}

		public User Restore(int id) {
			User user = Users.Find(id);
			if (user == null) return null;
			user.Buzzing = true;
			nest.SaveChanges();
			return user;
		}

		public void Delete(int id) {
			User user = Users.Find(id);
			if (user == null) return;
			user.Buzzing = false;
			nest.SaveChanges();
		}
	}
}
