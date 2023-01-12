using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogProject.Entities.Concrete;
using BlogProject.Mvc.Areas.Admin.Models;
using BlogProject.Services.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexType;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        public HomeController(ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

  
        public async Task<IActionResult> Index()
        {
            var categoriesCount = await _categoryService.CountByNonDeletedAsync();
            var articlesCount = await _articleService.CountByNonDeletedAsync();
            var commentsCount = await _commentService.CountByNonDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var articlesResult = await _articleService.GetAllAsync();
            if (categoriesCount.ResultStatus==ResultStatus.Success&& articlesCount.ResultStatus==ResultStatus.Success&& commentsCount.ResultStatus==ResultStatus.Success&&usersCount>-1&& articlesResult.ResultStatus==ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount=categoriesCount.Data,
                    ArticlesCount=articlesCount.Data,
                    CommentsCount=commentsCount.Data,
                    UsersCount=usersCount,
                    Articles= articlesResult.Data
                });
            }
            return NotFound();
       
        }
      
    }
}
