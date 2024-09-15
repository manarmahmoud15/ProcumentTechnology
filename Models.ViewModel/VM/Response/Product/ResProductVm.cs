using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.ViewModel.Product

{
    public class ResProductVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Details { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Price { get; set; }
        public string? Notes { get; set; }
        public IFormFile? Photo { get; set; }
        public string? PhotoPath { get; set; }

    }

}
