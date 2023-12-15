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

        public IActionResult Index()
        {
            var x = _postService.FindAll();
            return View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Post model = new Post();
            model.Topics = _postService
                .FindAllTopics()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name })
                .ToList();
            return View(model);
        }

        [HttpPost]
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


    }
}
