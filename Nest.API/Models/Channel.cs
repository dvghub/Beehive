using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.Models;

namespace Nest.API.Models {
    public class Channel {
        public Channel() { }
        public Channel(int id) { Id = id; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
    }
}
