namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionLog")]
    public partial class ActionLog
    {
        [Key]
        public int pkActionLog { get; set; }

        public int fkTypeActionLog { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(350)]
        public string notes { get; set; }

        public virtual TypeActionLog TypeActionLog { get; set; }
    }
}
