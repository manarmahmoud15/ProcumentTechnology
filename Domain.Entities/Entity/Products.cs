using Medianesta.DataLayer.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Domain.Entities.Entity
{
    public partial class Products : PrimEntityDto<int>
    {
        public int Id   { get; set; }
        public string? ProductName   { get; set; }
        public string? Details { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Price { get; set; }
        public string? Notes { get; set; }
        public string? Photo { get; set; }
    }
}
