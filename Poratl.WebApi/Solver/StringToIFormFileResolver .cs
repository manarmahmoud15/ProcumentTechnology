using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;
using System.IO;

public class StringToIFormFileResolver : IValueResolver<Domain.Entities.Entity.Products, Models.ViewModel.Product.ResProductVm, IFormFile>
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public StringToIFormFileResolver(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IFormFile Resolve(Domain.Entities.Entity.Products source, Models.ViewModel.Product.ResProductVm destination, IFormFile destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.Photo))
            return null;

        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Upload", source.Photo);
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return new FormFile(fileStream, 0, fileStream.Length, "photo", source.Photo);
    }
}
