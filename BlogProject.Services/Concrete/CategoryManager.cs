using AutoMapper;
using BlogProject.Data.Abstract;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos;
using BlogProject.Services.Abstract;
using BlogProject.Services.Utilities;
using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexType;
using BlogProject.Shared.Utilities.Results.Concrete;
using System;
using System.Threading.Tasks;

namespace BlogProject.Services.Concrete
{
    public class CategoryManager :ManagerBase, ICategoryService

    {


        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
          
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = Mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var categoryAdded=  await UnitOfWork.Categories.AddAsync(category);
            await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success,Messages.CategoryMessage.Add(categoryAddDto.Name),new CategoryDto
            {
                Category= categoryAdded,
                ResultStatus=ResultStatus.Success,
                Message = Messages.CategoryMessage.Add(categoryAddDto.Name)
            });
        }
        /// <summary>
        /// Soft Delete
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="modifiedByName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, Messages.CategoryMessage.Delete(category.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.CategoryMessage.Delete(category.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.CategoryMessage.NotFound(isPlural: false)
            });
        }
        public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(x => x.Id == categoryId, c => c.Articles);
            if (category != null)
            {

                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {

                return new DataResult<CategoryDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(false), new CategoryDto
                {
                    Category=null,
                    ResultStatus=ResultStatus.Error,
                    Message= Messages.CategoryMessage.NotFound(false)
                });
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync();
            if (categories.Count > -1)
            {

                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {

                return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural:true), new CategoryListDto
                {
                    Categories = null,
                    ResultStatus = ResultStatus.Error,
                    Message = Messages.CategoryMessage.NotFound(isPlural: true)
                });
            }


        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c=>!c.IsDeleted);
            if (categories.Count > -1)
            {

                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {

                return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural: true), new CategoryListDto
                {
                    Categories = null,
                    ResultStatus = ResultStatus.Error,
                    Message = Messages.CategoryMessage.NotFound(isPlural: true)
                });
            }
        }
        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync()
        {


            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (categories.Count > -1)
            {

                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories
                });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural: true), null);

            }


        }
        public async Task<IResult> HardDeleteAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;

                await UnitOfWork.Categories.DeleteAsync(category);
                await UnitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, Messages.CategoryMessage.HardDelete(category.Name));
            }
            return new Result(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural: false));

        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            var category = Mapper.Map<CategoryUpdateDto,Category>(categoryUpdateDto,oldCategory);
            category.ModifiedByName = modifiedByName;
            var updatedCategory= await UnitOfWork.Categories.UpdateAsync(category);
            await UnitOfWork.SaveAsync();
            return new  DataResult<CategoryDto>(ResultStatus.Success,Messages.CategoryMessage.Update(categoryUpdateDto.Name), new CategoryDto
            {
                Category=updatedCategory,
                ResultStatus=ResultStatus.Success,
                Message= Messages.CategoryMessage.Update(categoryUpdateDto.Name)
            });

        }

       
        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDto temsilini geriye döner
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucu DataResult tipinde Geriye Döner</returns>
        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                var categoryUpdateDto = Mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, Messages.CategoryMessage.NotFound(isPlural:false), null);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync();
            if (categoriesCount>-1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync(c=>!c.IsDeleted);
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı", -1);
            }
        }

    } 
}
