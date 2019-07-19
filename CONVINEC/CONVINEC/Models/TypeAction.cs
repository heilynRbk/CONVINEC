namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeAction")]
    public partial class TypeAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeAction()
        {
            QuestionActivity = new HashSet<QuestionActivity>();
        }

        [Key]
        public int pkTypeAction { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string description { get; set; }

        public bool isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionActivity> QuestionActivity { get; set; }
    }
}
