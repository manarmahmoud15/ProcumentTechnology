using Library.Helpers.Extensions;
using Library.Helpers.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.Base
{
    public class SearchModel
    {
        public int Company { get; set; }
        public int Branch { get; set; }
        public int UserId { get; set; }
        public string WhereStatement { get; set; }
        public string SearchUrl { get; set; }
        public string IndexUrl { get; set; }
        public string CreateUrl { get; set; }
        public string DeleteUrl { get; set; }



        public int? Page { get; set; }

        public int PageIndex
        {
            get { return this.Page.HasValue ? this.Page.Value - 1 : Global.DefaultPageIndex; }
        }

        private int _pageSize;
        [UIHint("DDLPageSize")]
        public int PageSize
        {
            get
            {
                return _pageSize == 0 ? Global.DefaultPageSize : _pageSize;
            }
            set { _pageSize = value; }
        }

        public int Orderby { get; set; }

        public string SortBy { get; set; }

        [UIHint("FilterByEditor")]
        public string FilterBy { get; set; }

        public int TotalRows { get; set; }
        public int PageNo { get; set; }
        public string UpdateTargetId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }


    }
    public class BaseParam<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public T Filter { get; set; }
        public IEnumerable<SortModel> OrderByValue { get; set; }

    }

}
