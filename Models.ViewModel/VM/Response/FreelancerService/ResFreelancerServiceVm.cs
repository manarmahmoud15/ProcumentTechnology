using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.FreelancerService
{
    public class ResFreelancerServiceVm : ViewModel, IEntityDto<int>
    {


        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int FreelancerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderStatusId { get; set; }



    }

}
