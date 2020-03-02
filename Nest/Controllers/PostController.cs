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
        private readonly UserRepository userRepository = new UserRepository();
        private const int PageSize = 10;

        public ViewResult Feed(string category = null, int page = 1) {
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
                CurrentCategory = category
            };

            return View(model);
        }

        public ViewResult CreatePost() {
            var model = new EditPostViewModel {
                Post = new Post(-1),
                Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Id).Include(c => c.Parent).ToHashSet()
            };

            return View("EditPost", model);
        }

        public ViewResult EditPost(int id) {
            var post = postRepository.Posts.Find(id);
            var model = new EditPostViewModel {
                Post = post,
                Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Id).Include(c => c.Parent).ToHashSet(),
                UserId = post.User == null ? 6 : post.User.Id,
                ChannelId = post.Channel == null ? 1 : post.Channel.Id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditPost(EditPostViewModel model) {
            model.Channels = channelRepository.Channels.Where(c => c.Name != "Blank").OrderBy(c => c.Id).Include(c => c.Parent).ToHashSet();
            model.Post.Channel = channelRepository.Channels.Find(model.ChannelId);
            model.Post.Channel.Parent = channelRepository.Channels.Find(model.Post.Channel.Parent.Id);
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

        public ActionResult DeletePost(int id) {
            postRepository.Delete(id);
            TempData["message"] = "Post was deleted";
            return RedirectToAction("Feed", new { category = postRepository.Posts.Find(id).Channel.Name });
        }
    }
}
