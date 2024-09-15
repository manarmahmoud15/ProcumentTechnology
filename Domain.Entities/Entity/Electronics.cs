using Medianesta.DataLayer.Base;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Electronics : PrimEntityDto<int>
    {
        public int Id { get; set; }
        public string? ProductName  { get; set; }
        public string? ProductDetails  { get; set; }
        public string? ProductColor  { get; set; }
        public string? ProductSize { get; set; }
        public string? ProductPrice { get; set; }
        public string? CompanyName  { get; set; }
        public string? Address  { get; set; }
        public string? Phone { get; set; }
    }
}
