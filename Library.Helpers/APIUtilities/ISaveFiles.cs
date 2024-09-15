
using System;

namespace Library.Helpers.APIUtilities
{
    public interface ISaveFiles //: ISaveAllImage
    {
        string SaveFile(string imgStr, string folderName,string oldFileName);
        bool IsBase64Encoded(string imgStr);
    }
}
