using AutoMapper;
using Virevox.application.core;
using Virevox.ViewModels;

namespace Virevox.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}