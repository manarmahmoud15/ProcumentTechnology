using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using ElectronicModel = Domain.Entities.Entity.Electronics;
using Models.ViewModel.Electronics;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ElectronicMapperProfile()
        {

            CreateMap<ElectronicsVm, ElectronicModel>();
            CreateMap<ElectronicModel, ElectronicsVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ElectronicModel, ResElectronicsVm>();

        }
    }
}


