namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            QuestionActivity = new HashSet<QuestionActivity>();
        }

        [Key]
        public int pkQuestion { get; set; }

        [Display(Name = "Tema")]
        public int fkTopic { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Completo")]
        public string fullName { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Título")]
        public string tittle { get; set; }

        [Required]
        [Display(Name = "Consulta")]
        public string description { get; set; }

        public bool isActive { get; set; }

        public virtual Topic Topic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionActivity> QuestionActivity { get; set; }
    }
}
