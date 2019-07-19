namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeActionLog")]
    public partial class TypeActionLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeActionLog()
        {
            ActionLog = new HashSet<ActionLog>();
        }

        [Key]
        public int pkTypeActionLog { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string description { get; set; }

        public bool isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActionLog> ActionLog { get; set; }
    }
}
