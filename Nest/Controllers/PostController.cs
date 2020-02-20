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
        private readonly PostRepository _repository = new PostRepository();
        private const int PageSize = 10;

        public ViewResult Feed(string category, int page = 1) {
            var posts = _repository.Posts
                .Include(p => p.Channel)
                .Include(p => p.User)
                .Where(p => category == null || p.Channel.Name.Equals(category));
            var total = posts.Count();

            posts = posts.OrderByDescending(p => p.Timestamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            PostListViewModel model = new PostListViewModel {
                Posts = posts,
                PaginationInfo = new PaginationInfo {
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
