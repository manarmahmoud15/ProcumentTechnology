using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;

using TransactionModel = Domain.Entities.Entity.Communications;
using Models.ViewModel.Communications;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void TransactionMapperProfile()
        {

            //CreateMap<TransactionVm, TransactionModel>();
            //CreateMap<TransactionModel, TransactionVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<TransactionModel, ResTransactionVm>();

            CreateMap<CommunicationsVm, UsersJob>();
            CreateMap<UsersJob, CommunicationsVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UsersJob, ResCommunicationsVm>();

        }
    }
}


