using Nest.API.Interfaces;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Concrete {
    class BuzzRepository : IBuzzRepository {
        private readonly NestContext nest = new NestContext();

        public DbSet<Buzz> Buzzes { get { return nest.Buzzes; } }

        public Buzz Create(Buzz b) {
            Buzz buzz = Buzzes.Add(b);
            nest.SaveChanges();
            return buzz;
        }

        public void Delete(int id) {
            Buzz buzz = Buzzes.Find(id);
            if (buzz == null) return;
            nest.Buzzes.Remove(buzz);
            nest.SaveChanges();
        }
    }
}
