using BlogProject.Entities.Dtos;

namespace BlogProject.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto  CategoryAddDto { get; set; }
        public string  CategoryAddPartial { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
