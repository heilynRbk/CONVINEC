namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemLog")]
    public partial class SystemLog
    {
        [Key]
        public int pkSystemLog { get; set; }

        [Required]
        [StringLength(100)]
        public string table { get; set; }

        [Required]
        [StringLength(100)]
        public string column { get; set; }

        [Required]
        [StringLength(250)]
        public string previousValue { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(350)]
        public string notes { get; set; }
    }
}
