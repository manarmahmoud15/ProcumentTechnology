using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
    public interface IFileService
    {
        public Tuple<int, string> SaveFile(IFormFile File);
        public bool DeleteFile(string FileName);

    }
}
