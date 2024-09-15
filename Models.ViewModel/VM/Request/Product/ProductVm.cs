using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.ViewModel.Product

{
    public class ProductVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Details { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Price { get; set; }
        public string? Notes { get; set; }

        // For receiving the file in the request
        public IFormFile? Photo { get; set; }

        // For storing the file path after saving
        public string? PhotoPath { get; set; }
    }

    public class ProductFilter
    {
    }

}
