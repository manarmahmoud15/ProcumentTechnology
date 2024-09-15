using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Models.ViewModel.Base
{
    public class ImgManager
    {
        private readonly string WebRootPath;

        public ImgManager(string WebRootPath)
        {
            this.WebRootPath = WebRootPath;
        }
        public async System.Threading.Tasks.Task<string> UploudImageAsync(string DomainName, string FileName, IFormFile ImgFile, string FolderURL)
        {
            FileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(ImgFile.FileName);
            FileName += extension;
            string FileFullPath = Path.Combine(WebRootPath, FolderURL);
            string FilePath = Path.Combine(FileFullPath, FileName);

            //ImgFile.CopyTo(new FileStream(FilePath, FileMode.Create));
            //string ImgPath = DomainName + "\\" + FolderURL + "\\" + FileName;

            //return ImgPath;


            using (var localFile = System.IO.File.OpenWrite(FilePath))
            using (var uploadedFile = ImgFile.OpenReadStream())
            {
                await uploadedFile.CopyToAsync(localFile);
            }
            //ImgFile.CopyTo(new FileStream(FilePath, FileMode.Create));
            string ImgPath = DomainName + "\\" + FolderURL + "\\" + FileName;

            return ImgPath;
        }

        public void DeleteImage(string FilePath, string DomainName)
        {
            FilePath = FilePath.Replace(DomainName, "");
            string FileFullPath = WebRootPath + FilePath;
            // If file with same name exists delete it
            if (File.Exists(FileFullPath))
            {
                File.Delete(FileFullPath);
            }
        }

        public IFormFile ResizeImage(IFormFile ImgFile, int Width = 600, int Height = 600)
        {
            Image image = Image.FromStream(ImgFile.OpenReadStream(), true, true);
            Bitmap newImage = new Bitmap(Width, Height);
            using Graphics g = Graphics.FromImage(newImage);
            g.DrawImage(image, 0, 0, Width, Height);

            return ImgFile;
        }
    }
}
