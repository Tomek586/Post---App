using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Topics")]
    public class TopicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         public ISet<PostEntity> Posts { get; set; }
    }
}
