using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;

namespace BlogProject.Entities.Dtos
{
    public class ArticleDto: DtoGetBase
    {
        public Article Article { get; set; }
    }
}
