using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest.API.Concrete;
using Nest.API.Models;
using Nest.Models;
using Nest.ViewModels;

namespace Nest.Controllers {
    public class PostController : Controller {
        private readonly PostRepository postRepository = new PostRepository();
        private readonly ChannelRepository channelRepository = new ChannelRepository();
        private readonly UserRepository userRepository = new UserRepository();
        private const int PageSize = 10;

        public ViewResult Feed(string category = null, int page = 1) {
            Debug.Write(RouteData.Values);

            var posts = postRepository.Posts
                .Include(p => p.Channel)
                .Include(p => p.User);

            if (category != null && category != "") {
                posts = posts.Where(p => p.Channel.Name.Equals(category));
            }

            var total = posts.Count();

            posts = posts.OrderByDescending(p => p.Timestamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var model = new PostListViewModel {
                Posts = posts,
                PaginationInfo = new PaginationViewModel {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = total
                },
                CurrentCategory = category,
                User = (User) HttpContext.Session["user"]
            };

            return View(model);
        }

        [Authorize]
        public ViewResult CreatePost(string channel) {
            Channel current = channelRepository.Channels.FirstOrDefault(c => c.Name == channel);
            if (current == null) channel = "General";

            var model = new EditPostViewModel {
                Post = new Post(-1),
                Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Name).Include(c => c.Parent).ToHashSet(),
                ChannelId = current == null ? 1 : current.Id
            };

            return View("EditPost", model);
        }

        [Authorize]
        public ViewResult EditPost(int id) {
            var post = postRepository.Posts.Include(p => p.Channel).First(p => p.Id == id);
            var model = new EditPostViewModel {
                Post = post,
                Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Id).Include(c => c.Parent).ToHashSet(),
                UserId = post.User == null ? 6 : post.User.Id,
                ChannelId = post.Channel == null ? 1 : post.Channel.Id
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPost(EditPostViewModel model) {
            model.Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Id).Include(c => c.Parent).ToHashSet();
            model.Post.Channel = model.Channels.First(c => c.Id == model.ChannelId);
            model.Post.Channel.Parent = model.Channels.First(c => c.Parent.Id == model.Post.Channel.Parent.Id);
            model.Post.User = userRepository.Users.Find(model.UserId);

            ModelState.Clear();

            TryValidateModel(model);
            TryValidateModel(model.Post, "Post");
            TryValidateModel(model.Post.Channel, "Post.Channel");
            TryValidateModel(model.Post.User, "Post.User");

            if (ModelState.IsValid) {
                postRepository.CreateOrUpdate(model.Post);
                TempData["message"] = "Post successful!";
                return RedirectToAction("Feed", new { category = model.Post.Channel.Name});
            }

            return View(model);
        }

        [Authorize]
        public ActionResult DeletePost(int id, string channel) {
            postRepository.Delete(id);
            TempData["message"] = "Post was deleted";
            return RedirectToAction("Feed", new { channel });
        }
    }
}
