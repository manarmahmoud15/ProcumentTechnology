using Medianesta.DataLayer.Base;
using System.Net.Mail;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Price : PrimEntityDto<int>
    {
        public int Id { get; set; }
        public string? Quantity  { get; set; }
        public string? price  { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Phone   { get; set; }
        public string? Detailes { get; set; }
        public string? Email { get; set; }
    }
}