using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Article:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? CategoryID { get; set; }
        public int? AuthorID { get; set; }
        public int? EditorID { get; set; }


        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual Editor Editor { get; set; }
        public virtual List<ArticleTag> ArticleTags { get; set; }


    }
}
