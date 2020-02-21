using System.Collections.Generic;
using Nest.API.Models;

namespace Nest.ViewModels {
    public class PostListViewModel {
        public IEnumerable<Post> Posts { get; set; }
        public PaginationViewModel PaginationInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
