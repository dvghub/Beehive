using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Models;

namespace Nest.API.Interfaces{
    interface IChannelRepository {
        DbSet<Channel> Channels { get; }

        Channel CreateOrUpdate(Channel channel);
        Channel Create(Channel channel);
        Channel Update(Channel channel);
        void Delete(int id);
    }
}
