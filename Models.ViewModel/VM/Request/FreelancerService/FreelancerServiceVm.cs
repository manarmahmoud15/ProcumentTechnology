using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.FreelancerService
{
    public class FreelancerServiceVm : ViewModel, IEntityDto<int>
    {

        public int FreelancerId { get; set; }
        public string ServiceName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string DeliveryTime { get; set; }
        public string Revisions { get; set; }
    }
    public class FreelancerServiceFilter
    {
    }

}
