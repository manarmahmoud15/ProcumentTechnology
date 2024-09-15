using Medianesta.DataLayer.Base;
using System.Web;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Report : PrimEntityDto<int>
    {

        public int Id { get; set; }
        public DateTime? Date  { get; set; }
        public string? Product  { get; set; }
        public string? CompanyName { get; set; }
        public string? Price { get; set; }
        public string? Quantity  { get; set; }
        public string? TotalPrice  { get; set; }
        public string? Convenant { get; set; }//    العهده 
        public string? RestCovenant { get; set; }
    }
}
