using System;

namespace Library.Helpers.APIUtilities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
    }


    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}