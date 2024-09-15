using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Helpers.APIUtilities
{
    public class DataPaging<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IEnumerable<T> Result { get; set; }
        public DataPaging(int pageNumber, int pageSize, int pagesCount, int totalCount, IEnumerable<T> result)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            PagesCount = pagesCount;
            TotalCount = totalCount;
            Result = result;
        }
    }

    public class DataPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalCountNew { get; set; }
        public object Result { get; set; }
        public DataPaging(int pageNumber, int pageSize, int totalCount, object result)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            Result = result;
        }
    }

}
