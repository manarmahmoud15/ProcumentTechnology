using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Library.Helpers.APIUtilities
{
    public class SaveFiles : ISaveFiles//: ISaveAllImage
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public SaveFiles(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string SaveFile(string imgStr,string folderName,string fileName)
        {
            try
            {
                var path = _hostingEnvironment.WebRootPath;
                string extention = "";
                string FileName = "";
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path ?? throw new InvalidOperationException());
                }
                string convert = imgStr;
                if (imgStr.StartsWith("data:image/jpeg;base64"))
                {
                    convert = imgStr.Replace("data:image/jpeg;base64,", string.Empty);
                    extention = ".jpeg";
                }
                if (imgStr.StartsWith("data:image/Jpeg;base64"))
                {
                    convert = imgStr.Replace("data:image/Jpeg;base64,", string.Empty);
                    extention = ".jpeg";
                }
                if (imgStr.StartsWith("data:image/jpg;base64"))
                {
                    convert = imgStr.Replace("data:image/jpg;base64,", string.Empty);
                    extention = ".jpg";
                }
                if (imgStr.StartsWith("data:image/Jpg;base64"))
                {
                    convert = imgStr.Replace("data:image/Jpg;base64,", string.Empty);
                    extention = ".jpg";
                }
                else if (imgStr.StartsWith("data:image/Png;base64"))
                {
                    convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
                    extention = ".png";
                }
                else if (imgStr.StartsWith("data:image/png;base64"))
                {
                    convert = imgStr.Replace("data:image/png;base64,", string.Empty);
                    extention = ".png";
                }
                else if (imgStr.StartsWith("data:text/plain;base64"))
                {
                    convert = imgStr.Replace("data:text/plain;base64,", string.Empty);
                    extention = ".text";
                }
                else if (imgStr.StartsWith("data:image/Gif;base64"))
                {
                    convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
                    extention = ".gif";
                }
                else if (imgStr.StartsWith("data:image/gif;base64"))
                {
                    convert = imgStr.Replace("data:image/gif;base64,", string.Empty);
                    extention = ".gif";
                }
                else if (imgStr.StartsWith("data:application/pdf;base64"))
                {
                    convert = imgStr.Replace("data:application/pdf;base64,", string.Empty);
                    extention = ".pdf";
                }
                else if (imgStr.StartsWith("data:application/zip;base64"))
                {
                    convert = imgStr.Replace("data:application/zip;base64,", string.Empty);
                    extention = ".zip";
                }
                else if (imgStr.StartsWith("data:application/rar;base64"))
                {
                    convert = imgStr.Replace("data:application/zip;base64,", string.Empty);
                    extention = ".rar";
                }
                else if (imgStr.StartsWith("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64"))
                {
                    convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", string.Empty);
                    extention = ".docx";
                }
                else if (imgStr.StartsWith("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64"))
                {
                    convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", string.Empty);
                    extention = ".xlsx";
                }
                else if (imgStr.StartsWith("data:application/vnd.ms-excel;base64"))
                {
                    convert = imgStr.Replace("data:application/vnd.ms-excel;base64,", string.Empty);
                    extention = ".xlsx";
                }
                else if (imgStr.StartsWith("data:application/octet-stream;base64"))
                {
                    convert = imgStr.Replace("data:application/octet-stream;base64,", string.Empty);
                    extention = ".zip";
                }
                if (string.IsNullOrEmpty(fileName))
                   FileName = DateTime.Now.ToString("ddMMyyyhhMMssfff") + extention;
                else
                    FileName = fileName;

                string imgPath = Path.Combine(path , folderName, FileName);
                if (File.Exists(imgPath))
                {
                    extention = Path.GetExtension(FileName);
                    string namwWithoutExtention  = Path.GetFileNameWithoutExtension(FileName);
                    FileName = namwWithoutExtention+DateTime.Now.ToString("ddMMyyyhhMMssfff") + extention;
                    imgPath = Path.Combine(path, folderName,FileName);
                }
               
                byte[] imageBytes = Convert.FromBase64String(convert);

                File.WriteAllBytes(imgPath, imageBytes);
                return folderName+"/"+FileName; //Path.Combine( folderName, FileName) ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsBase64Encoded(string imgStr)
        {
            try
            {
                string convert = imgStr;
                if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
                else if (imgStr.Contains("data:image/Jpeg;base64")) convert = imgStr.Replace("data:image/Jpeg;base64,", string.Empty);
                else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
                else if (imgStr.Contains("data:image/png;base64")) convert = imgStr.Replace("data:image/png;base64,", string.Empty);
                else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
                else if (imgStr.Contains("data:image/gif;base64")) convert = imgStr.Replace("data:image/gif;base64,", string.Empty);
                else if (imgStr.Contains("data:application/pdf;base64")) convert = imgStr.Replace("data:application/pdf;base64,", string.Empty);
                else if (imgStr.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64")) convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", string.Empty);
                else if (imgStr.Contains("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64")) convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", string.Empty);
                else if (imgStr.Contains("data:application/vnd.ms-excel;base64")) convert = imgStr.Replace("data:application/vnd.ms-excel;base64,", string.Empty);
                else if (imgStr.Contains("data:application/octet-stream;base64")) convert = imgStr.Replace("data:application/octet-stream;base64,", string.Empty);
                else if (imgStr.Contains("data:application/pdf;base64")) convert = imgStr.Replace("data:application/rar;base64,", string.Empty);
                else if (imgStr.Contains("data:application/rar;base64")) convert = imgStr.Replace("data:application/zip;base64,", string.Empty);
                else if (imgStr.Contains("data:text/plain;base64")) convert = imgStr.Replace("data:text/plain;base64,", string.Empty);

                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(convert);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return true;// (convert.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }

        //public byte[] SaveImageindataBase(string imgStr, string imgName)
        //{
        //    try
        //    {
        //        string convert = imgStr;
        //        if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
        //        else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
        //        else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
        //        byte[] imageBytes = Convert.FromBase64String(convert);
        //        return imageBytes;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        //public bool IsBase64Encoded(String imgStr)
        //{
        //    try
        //    {
        //        string convert = imgStr;
        //        if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
        //        else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
        //        else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
        //        else if (imgStr.Contains("data:application/pdf;base64")) convert = imgStr.Replace("data:application/pdf;base64,", string.Empty);
        //        else if (imgStr.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64")) convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64,", string.Empty);

        //        // If no exception is caught, then it is possibly a base64 encoded string
        //        byte[] data = Convert.FromBase64String(convert);
        //        // The part that checks if the string was properly padded to the
        //        // correct length was borrowed from d@anish's solution
        //        return (convert.Replace(" ", "").Length % 4 == 0);
        //    }
        //    catch
        //    {
        //        // If exception is caught, then it is not a base64 encoded string
        //        return false;
        //    }
        //}

    }
}
