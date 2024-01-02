using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Post___App.Models
{
    public class Post
    {
        
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Content { get; set; }
        [StringLength(maximumLength: 50)]
        public string Author { get; set; }

        public DateTime publishDate { get; set; }
        public string Tags { get; set; }
        [StringLength(maximumLength: 150)]
        public string Comment { get; set; }
        
        public int? TopicId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Topics { get; set; }

       
    }
}
