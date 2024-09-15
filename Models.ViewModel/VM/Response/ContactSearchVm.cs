using Models.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.VM.Response
{
   public class ContactSearchVm
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public List<ContactSearchBasicVm> Bodyes { get; set; }
        public List<ContactSearchBasicVm> ContactOecd { get; set; }
        public List<ContactSearchBasicVm> ContactEntity { get; set; }
        public string Leading { get; set; }
        public List<ContactSearchBasicVm> Affiliates { get; set; }
        public List<ContactSearchBasicVm> Adherence { get; set; }
        public List<ContactSearchBasicVm> Committes { get; set; }
        public List<ContactSearchBasicVm> CommittesAction { get; set; }

    }

    public class ContactSearchResult
    {
        public int TotalCount { get; set; }
        public int Code { get; set; }
        public List<ContactSearchVm> Result { get; set; }

    }

    public class ContactSearchResultReset
    {
        public int KeyWord { get; set; }

    }

    public class ContactSearchFilter
    {
        public string ProjectName { get; set; }
        public string ContactName { get; set; }
        public int? Committe { get; set; }
        public string Email { get; set; }
        public int? ImplementingBody { get; set; }
        public int? Entity { get; set; }

    }
}
