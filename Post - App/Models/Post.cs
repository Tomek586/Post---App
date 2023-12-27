using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Post___App.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime publishDate { get; set; }
        public string Tags { get; set; }
        public string Comment { get; set; }

        [HiddenInput]
        public int? TopicId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Topics { get; set; }
    }
}
