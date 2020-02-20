using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Interfaces;
using Nest.Models;

namespace Nest.API.Concrete {
    public class ChatRepository : IChatRepository {
        private readonly NestContext nest = new NestContext();
        private readonly MessageRepository messageRepository = new MessageRepository();

        public DbSet<Chat> Chats { get { return nest.Chats; } }

        public Chat CreateOrUpdate(Chat c) {
            if (c.Id < 0) return Create(c);
            return Update(c);
        }

        public Chat Create(Chat c) {
            Chat chat = Chats.Add(c);
            nest.SaveChanges();
            return chat;
        }

        public Chat Update(Chat c) {
            Chat chat = Chats.Find(c.Id);
            if (chat == null) return null;
            chat.Name = c.Name;
            nest.SaveChanges();
            return chat;
        }

        public void Delete(int id) {
            Chat chat = Chats.Find(id);
            if (chat == null) return;
            nest.Messages
                .Where(m => m.Chat.Id == id)
                .ToList()
                .ForEach(m => messageRepository.Delete(m.Id));
            nest.Chats.Remove(chat);
            nest.SaveChanges();
        }
    }
}
