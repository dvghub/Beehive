using Nest.API.Models;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class ViewPostViewModel {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public HashSet<Buzz> Buzzes { get; set; }
        public HashSet<Comment> Comments { get; set; }
        public Comment New { get; set; }
    }
}
