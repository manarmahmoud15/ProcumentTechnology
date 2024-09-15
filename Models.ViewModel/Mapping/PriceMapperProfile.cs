using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using priceModel = Domain.Entities.Entity.Price;
using Models.ViewModel.Price;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void PriceMapperProfile()
        {

            CreateMap<PriceVm, priceModel>();
            CreateMap<priceModel, PriceVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<priceModel, ResPriceVm>();

        }
    }
}


