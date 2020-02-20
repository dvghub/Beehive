using Nest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.API.Interfaces {
    interface IBuzzRepository {
        DbSet<Buzz> Buzzes { get; }

        Buzz Create(Buzz buzz);
        void Delete(int id);
    }
}
