using Medianesta.DataLayer.Base;


#nullable disable

namespace Domain.Entities.Entity
{
    public partial class FreelancerService : PrimEntityDto<int>
    {
        public int FreelancerId   { get; set; }
        public string ServiceName { get; set; }
        public int CategoryId { get; set; }
        public string Description   { get; set; }
        public decimal Price { get; set; }
        public string DeliveryTime  { get; set; }
        public string Revisions  { get; set; }


    }
}
