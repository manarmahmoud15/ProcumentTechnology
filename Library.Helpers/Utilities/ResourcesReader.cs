using System.Threading;

namespace Library.Helpers.Utilities
{
    public class ResourcesReader
    {
        public static bool IsArabic
        {
            
            get { return Thread.CurrentThread.CurrentCulture.Name.StartsWith("ar"); }
        }
    }
}
