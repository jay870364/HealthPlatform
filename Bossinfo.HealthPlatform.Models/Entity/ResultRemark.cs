namespace Bossinfo.HealthPlatform.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResultRemark")]
    public partial class ResultRemark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UID { get; set; }

        public Enums.ResultRemarkType Type { get; set; }

        public double LowRange { get; set; }

        public double HightRange { get; set; }

        [StringLength(10)]
        public string Level { get; set; }

        [StringLength(200)]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
