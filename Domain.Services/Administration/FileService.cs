using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstracts.Administration;
using Domain.Services.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Domain.Services.Administration
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment env)
        {
            this.environment = env;
        }
        public Tuple<int , string> SaveFile (IFormFile File)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                var path = Path.Combine(contentPath, "Upload");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var ext = Path.GetExtension(File.FileName);
                var allowedExtensions = new string[] { ".pdf", ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed" , string.Join("," ,allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                File.CopyTo(stream);
                stream.Close();
                return new Tuple<int,string> (1 , newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string> (0, "error has occured");
            }
        }

        public bool DeleteFile (string FileName)
        {
            try
            {
                var wwwPath = this.environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Upload\\", FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
