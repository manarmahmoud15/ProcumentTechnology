using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Helpers.APIUtilities
{
    public class HttpResponse<T>
    {
        public string error { get; set; }
        public string message { get; set; }
        public string status_code { get; set; }
        public T data { get; set; }
        public Pagination pagination { get; set; }
    }
    public class Pagination
    {
        public int allCount { get; set; }
        public int filtersCount { get; set; }
        public int resultCount { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

}
