using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Interfaces;
using Nest.API.Models;

namespace Nest.API.Concrete {
    public class ChannelRepository : IChannelRepository {
        private readonly NestContext nest = new NestContext();
        private readonly PostRepository postRepository = new PostRepository();
        private readonly CommentRepository commentRepository = new CommentRepository();
        private readonly BuzzRepository buzzRepository = new BuzzRepository();

        public DbSet<Channel> Channels { get { return nest.Channels; } }

        public Channel CreateOrUpdate(Channel c) {
            if (c.Id < 0) return Create(c);
            return Update(c);
        }

        public Channel Create(Channel c) {
            Channel channel = Channels.Add(c);
            nest.SaveChanges();
            return channel;
        }

        public Channel Update(Channel c) {
            Channel channel = Channels.Find(c.Id);
            if (channel == null) return null;
            channel.Name = c.Name;
            channel.Parent = c.Parent;
            nest.SaveChanges();
            return channel;
        }

        public void Delete(int id) {
            Channel channel = Channels.Find(id);
            if (channel == null) return;
            Channels
                .Where(c => c.Parent.Id == id)
                .ToList()
                .ForEach(c => Delete(c.Id));
            postRepository.Posts.Where(p => p.Channel.Id == id)
                .ForEachAsync(p => {
                    nest.Comments
                        .Where(c => c.Post.Id == p.Id)
                        .ToList()
                        .ForEach(c => commentRepository.Delete(c.Id));
                    nest.Buzzes
                        .Where(b => b.Post.Id == p.Id)
                        .ToList()
                        .ForEach(b => buzzRepository.Delete(b.Id));
                    postRepository.Delete(p.Id);
                });
            nest.Channels.Remove(channel);
            nest.SaveChanges();
        }
    }
}
