namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndicatorHistory")]
    public partial class IndicatorHistory
    {
        [Key]
        public int pkIndicatorHistory { get; set; }

        public int fkTypeIndicator { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

        public virtual TypeIndicator TypeIndicator { get; set; }
    }
}
