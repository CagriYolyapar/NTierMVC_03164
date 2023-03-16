using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Author : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Relational Properties
        public virtual List<Article> Articles { get; set; }
        public virtual AuthorProfile Profile { get; set; }

    }
}
