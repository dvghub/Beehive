using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Interfaces {
    interface IMessageRepository {
        DbSet<Message> Messages { get; }

        Message Create(Message message);
        void Delete(int id);
    }
}
