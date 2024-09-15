using Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class OECDDbContext : DbContext
    {
        private ISeedData _iSeedData;
        public OECDDbContext()
        {
        }

        //public OECDDbContext(DbContextOptions<OECDDbContext> options, ISeedData iSeedData)
        //    : base(options)
        //{
        //    _iSeedData = iSeedData;
        //}
        public OECDDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersJob> UsersJobs { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Price> ClientOrders { get; set; }
        public virtual DbSet<Products> ClientReviews { get; set; }
        public virtual DbSet<Company> FreelancerReviews { get; set; }
        public virtual DbSet<FreelancerService> FreelancerServices { get; set; }
        public virtual DbSet<Electronics> Electronics { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Communications> Communications { get; set; }
        public virtual DbSet<UsersJobCategory> UsersJobCategory { get; set; }
        public virtual DbSet<UsersJobStatus> UsersJobStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<UsersJob>(entity =>
            //{
            //    entity.HasKey(e => e.JobId);

            //    entity.Property(e => e.JobName)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //});



            #region Seed Data

            //modelBuilder.Entity<NotificationType>().HasData(_iSeedData.ReturnNotificationTypeList());

            #endregion
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
