using AutoMapper;
using BlogProject.Entities.Dtos;
using BlogProject.Mvc.Areas.Admin.Models;

namespace BlogProject.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>().ReverseMap();
     
        }
    }
}
