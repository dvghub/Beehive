using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Interfaces {
    interface ICommentRepository {
        DbSet<Comment> Comments { get; }

        Comment CreateOrUpdate(Comment comment);
        Comment Create(Comment comment);
        Comment Update(Comment comment);
        void Delete(int id);
    }
}
