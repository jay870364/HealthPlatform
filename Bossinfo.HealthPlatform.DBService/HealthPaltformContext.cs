namespace Bossinfo.HealthPlatform.DBService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Bossinfo.HealthPlatform.Models.Entity;

    public partial class HealthPaltformContext : DbContext
    {
        public HealthPaltformContext()
            : base("name=HealthPaltformContext")
        {
        }

        public virtual DbSet<Models.Entity.MeasureInfo> MeasureInfo { get; set; }
        public virtual DbSet<Models.Entity.MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<Models.Entity.ResultRemark> ResultRemark { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Entity.ResultRemark>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<Models.Entity.ResultRemark>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
