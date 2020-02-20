using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.Models;

namespace Nest.API.Interfaces {
	interface IChatRepository {
        DbSet<Chat> Chats { get; }

        Chat CreateOrUpdate(Chat chat);
        Chat Create(Chat chat);
        Chat Update(Chat chat);
        void Delete(int id);
    }
}
