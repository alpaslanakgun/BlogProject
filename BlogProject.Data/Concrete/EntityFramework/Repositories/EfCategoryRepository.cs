using Microsoft.EntityFrameworkCore;
using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EntityFramework.Contexts;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }


        private BlogProjectContext BlogProjectContext
        {
            get
            {
                return _context as BlogProjectContext;
            }
        }


        public async Task<Category>GetById(int categoryId)
        {
            return await BlogProjectContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }



    }
}
