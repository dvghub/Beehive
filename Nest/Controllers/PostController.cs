using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest.API.Concrete;
using Nest.API.Models;
using Nest.ViewModels;

namespace Nest.Controllers {
    public class PostController : Controller {
        private readonly PostRepository postRepository = new PostRepository();
        private readonly ChannelRepository channelRepository = new ChannelRepository();
        private const int PageSize = 10;

        public ViewResult Feed(string category = null, int page = 1) {
            var posts = postRepository.Posts
                .Include(p => p.Channel)
                .Include(p => p.User);

            if (category != null && category != "") {
                posts.Where(p => p.Channel.Name.Equals(category));
            }

            var total = posts.Count();

            posts = posts.OrderByDescending(p => p.Timestamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            PostListViewModel model = new PostListViewModel {
                Posts = posts,
                PaginationInfo = new PaginationViewModel {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = total
                },
                CurrentCategory = category
            };

            Console.WriteLine("test?");

            return View(model);
        }
    }
}
