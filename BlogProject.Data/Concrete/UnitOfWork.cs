using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EntityFramework.Contexts;
using BlogProject.Data.Concrete.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogProjectContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(BlogProjectContext context)
        {
            _context = context;
        }
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository?? new EfCommentRepository(_context);



        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
