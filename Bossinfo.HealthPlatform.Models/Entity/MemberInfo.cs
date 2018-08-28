namespace Bossinfo.HealthPlatform.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberInfo")]
    public partial class MemberInfo
    {
        [StringLength(20)]
        public string ID { get; set; }

        [Required]
        [StringLength(20)]
        public string IDNo { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        public short Genger { get; set; }

        public DateTime BDate { get; set; }

        [StringLength(16)]
        public string Tel { get; set; }

        [StringLength(16)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(16)]
        public string Fax { get; set; }

        [StringLength(20)]
        public string Occupation { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
