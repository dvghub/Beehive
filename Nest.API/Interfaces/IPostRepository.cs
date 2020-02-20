using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Models;
using Nest.Models;

namespace Nest.API.Interfaces {
	interface IPostRepository {
        DbSet<Post> Posts { get; }

        Post CreateOrUpdate(Post post);
        Post Create(Post post);
        Post Update(Post post);
        void Delete(int id);
    }
}
