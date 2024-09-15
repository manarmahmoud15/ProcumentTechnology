using Medianesta.DataLayer.Base;


#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Company : PrimEntityDto<int>
    {
        public int Id  { get; set; }
        public string? Details   { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
