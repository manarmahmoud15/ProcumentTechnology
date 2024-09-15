using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using ProductModel = Domain.Entities.Entity.Products;
using Models.ViewModel.Product;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ProductMapperProfile()
        {

            CreateMap<ProductVm, ProductModel>();
            CreateMap<ProductModel, ProductVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.Photo));

            CreateMap<ProductModel, ResProductVm>();
           //      .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.PhotoPath));


        }
    }
}


