using Medianesta.DataLayer.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class UsersJob : PrimEntityDto<int>
    {
        public int UserID  { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID  { get; set; }
        public string Budget  { get; set; }
        public string Deadline { get; set; }
        public int FreelancerId  { get; set; }
        public int StatusId  { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
