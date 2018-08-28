namespace Bossinfo.HealthPlatform.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeasureInfo")]
    public partial class MeasureInfo
    {
        [Key]
        public long UID { get; set; }

        [Required]
        [StringLength(20)]
        public string MemberIDNo { get; set; }

        [Required]
        [StringLength(4000)]
        public string MIData { get; set; }

        [Required]
        public DateTime MIDate { get; set; }
    }
}
