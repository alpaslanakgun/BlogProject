using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos;
using System.Collections.Generic;

namespace BlogProject.Mvc.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ArticlesCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public ArticleListDto Articles { get; set; }


    }
}
