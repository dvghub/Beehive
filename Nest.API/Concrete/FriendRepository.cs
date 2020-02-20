using Nest.API.Interfaces;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Concrete {
    class FriendRepository : IFriendRepository {
        private readonly NestContext nest = new NestContext();

        public DbSet<Friend> Friends { get { return nest.Friends; } }

        public Friend Create(Friend f) {
            Friend friend = Friends.Add(f);
            nest.SaveChanges();
            return friend;
        }

        public void Delete(int id) {
            Friend friend = Friends.Find(id);
            if (friend == null) return;
            Friends.Remove(friend);
            nest.SaveChanges();
        }
    }
}
