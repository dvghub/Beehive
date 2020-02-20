using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.Models;

namespace Nest.API.Interfaces {
	interface IUserRepository {
		DbSet<User> Users { get; }

        User CreateOrUpdate(User user);
        User Create(User user);
        User Update(User user);
        User Restore(int id);
        void Delete(int id);
    }
}
