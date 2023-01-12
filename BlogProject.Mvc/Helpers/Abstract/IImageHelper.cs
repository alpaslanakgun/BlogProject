using Microsoft.AspNetCore.Http;
using BlogProject.Entities.Dtos;
using BlogProject.Shared.Utilities.Results.Abstract;
using System.Globalization;
using System.Threading.Tasks;
using BlogProject.Entities.ComplexTypes;

namespace BlogProject.Mvc.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName=null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);

    }
}
