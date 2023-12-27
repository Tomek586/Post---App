using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Posts")]
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime publishDate { get; set; }
        public string Tags { get; set; }
        public string Comment { get; set; }
        public int TopicId { get; set; }
        public TopicEntity? Topic { get; set; }
        
    }
}