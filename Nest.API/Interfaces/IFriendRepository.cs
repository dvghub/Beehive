using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Interfaces {
    interface IFriendRepository {
        DbSet<Friend> Friends { get; }

        Friend Create(Friend friend);
        void Delete(int id);
    }
}
