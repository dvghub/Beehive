using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Interfaces;
using Nest.API.Models;
using Nest.Models;

namespace Nest.API.Concrete {
    public class PostRepository : IPostRepository {
        private readonly NestContext nest = new NestContext();
        private readonly CommentRepository commentRepository = new CommentRepository();
        private readonly BuzzRepository buzzRepository = new BuzzRepository();

        public DbSet<Post> Posts { get { return nest.Posts; } }

        public Post CreateOrUpdate(Post p) {
            if (p.Id < 0) return Create(p);
            return Update(p);
        }

        public Post Create(Post p) {
            Post post = Posts.Add(p);
            nest.SaveChanges();
            return post;
        }

        public Post Update(Post p) {
            Post post = Posts.Find(p.Id);
            if (post == null) return null;
            post.Title = p.Title;
            post.Message = p.Message;
            nest.SaveChanges();
            return post;
        }

        public void Delete(int id) {
            Post post = Posts.Find(id);
            if (post == null) return;
            nest.Comments
                .Where(c => c.Post.Id == id)
                .ToList()
                .ForEach(c => commentRepository.Delete(c.Id));
            nest.Buzzes
                .Where(b => b.Post.Id == id)
                .ToList()
                .ForEach(b => buzzRepository.Delete(b.Id));
            nest.Posts.Remove(post);
            nest.SaveChanges();
        }
    }
}
