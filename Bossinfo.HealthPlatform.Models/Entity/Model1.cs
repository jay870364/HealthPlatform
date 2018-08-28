namespace Bossinfo.HealthPlatform.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<MeasureInfo> MeasureInfo { get; set; }
        public virtual DbSet<MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<ResultRemark> ResultRemark { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultRemark>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<ResultRemark>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
