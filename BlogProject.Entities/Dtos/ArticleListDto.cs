using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities.Dtos
{
    public class ArticleListDto: DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        public int? CategoryId { get; set; }


    }
}
