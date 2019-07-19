namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeIndicator")]
    public partial class TypeIndicator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeIndicator()
        {
            IndicatorHistory = new HashSet<IndicatorHistory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codIndicadorInterno { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string description { get; set; }

        public bool isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndicatorHistory> IndicatorHistory { get; set; }
    }
}
