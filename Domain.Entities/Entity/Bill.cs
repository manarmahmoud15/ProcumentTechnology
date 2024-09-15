using Medianesta.DataLayer.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Bill : PrimEntityDto<int>
    {
        public int Id   { get; set; }
        public DateTime? Date { get; set; }
        public string? CompanyName { get; set; }
        public string? Details  { get; set; }
        public string? BillNumber { get; set; }
        public string? BillFile {  get; set; }
        [NotMapped]
        public IFormFile? pdfPhoto {  get; set; } // upload image and PDF

    }
}
