using Nest.API.Interfaces;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Concrete {
    class CommentRepository : ICommentRepository {
        private readonly NestContext nest = new NestContext();
        private readonly BuzzRepository buzzRepository = new BuzzRepository();

        public DbSet<Comment> Comments { get { return nest.Comments; } }

        public Comment CreateOrUpdate(Comment c) {
            if (c.Id < 0) return Create(c);
            return Update(c);
        }

        public Comment Create(Comment c) {
            Comment comment = Comments.Add(c);
            nest.SaveChanges();
            return comment;
        }

        public Comment Update(Comment c) {
            Comment comment = Comments.Find(c.Id);
            if (comment == null) return null;
            comment.Text = c.Text;
            nest.SaveChanges();
            return comment;
        }

        public void Delete(int id) {
            Comment comment = Comments.Find(id);
            if (comment == null) return;
            Comments
                .Where(c => c.Com.Id == id)
                .ToList()
                .ForEach(c => Delete(c.Id));
            nest.Buzzes
                .Where(b => b.Comment.Id == id)
                .ToList()
                .ForEach(b => buzzRepository.Delete(b.Id));
            nest.Comments.Remove(comment);
            nest.SaveChanges();
        }
    }
}
