using Medianesta.DataLayer.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Communications : PrimEntityDto<int>
    {
        public int Id   { get; set; }
        public string? Images { get; set; }
        public string? LogoImg { get; set; }
        public string? Price { get; set; }
        public string? CompanyName  { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Details  { get; set; }
    }
}
