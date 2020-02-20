using Nest.API.Interfaces;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Concrete {
    class MessageRepository : IMessageRepository {
        private readonly NestContext nest = new NestContext();

        public DbSet<Message> Messages { get { return nest.Messages; } }

        public Message Create(Message m) {
            Message message = Messages.Add(m);
            nest.SaveChanges();
            return message;
        }

        public void Delete(int id) {
            Message message = Messages.Find(id);
            if (message == null) return;
            Messages.Remove(message);
            nest.SaveChanges();
        }
    }
}
