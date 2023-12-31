﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Post___App.Models;

namespace Post___App.Controllers
{
   
    public class PostController : Controller
    {
        static List<Post> _post = new List<Post>();
        static int index = 1;

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
      
        public IActionResult Index(int? topicId)
        {
          
            ViewBag.AllTopics = _postService.FindAllTopics();

      
            var posts = _postService.FindAll();

            if (topicId.HasValue && topicId > 0)
            {
                posts = posts.Where(p => p.TopicId == topicId.Value).ToList();
            }

            return View(posts);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            Post model = new Post();
            model.Topics = _postService
                .FindAllTopics()
                ?.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name })
                .ToList() ?? new List<SelectListItem>();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            var contact = _postService.FindById(id);

            if (contact != null)
            {
                contact.Topics = _postService
                    .FindAllTopics()
                    ?.Select(oe => new SelectListItem()
                    {
                        Text = oe.Name,
                        Value = oe.Id.ToString(),
                    })
                    .ToList() ?? new List<SelectListItem>();

                return View(contact);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _postService.FindById(id);

            if (contact != null)
            {
                contact.Topics = _postService
                    .FindAllTopics()
                    .Select(oe => new SelectListItem()
                    {
                        Text = oe.Name,
                        Value = oe.Id.ToString(),
                    })
                    .ToList();

                return View(contact);
            }

            return View(contact);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var contact = _postService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _postService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateApi(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult PagedIndex(int? page = 1, int? size = 2)
        {

            return View(_postService.FindPage((int)page, (int)size));
        }

       



    }
}