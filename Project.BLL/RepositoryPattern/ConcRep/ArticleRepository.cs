using Project.BLL.RepositoryPattern.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.RepositoryPattern.ConcRep
{
    public class ArticleRepository:BaseRepository<Article>
    {
        public void AddArticleWithAuthor(Article a,Author author)
        {
            Article newArticle = new Article
            {
                Title = a.Title,
                Content = a.Content,
                Author = author
            };

            _db.Articles.Add(newArticle);
            Save();
        }
    }
}
