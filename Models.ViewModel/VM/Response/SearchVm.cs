using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.VM.Response
{
   public class SearchVm
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public string TypeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }

    }
    public class SearchProgressVm
    {

        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string SidNameAr { get; set; }
        public string SidNameEn { get; set; }
        public string OutPutCount { get; set; }
        public string ActivitesCount { get; set; }
        public string OutPutFinishedCount { get; set; }
        public string ActivitesFinishedCount { get; set; }
        public string TasksCount { get; set; }
    }

    public class SearchResult
    {
        public int TotalCount { get; set; }
        public int Code { get; set; }
        public List<SearchVm> Result { get; set; }

    }

    public class SearchResultReset
    {
       // public int TotalCount { get; set; }
        public int Code { get; set; }

    }
}
