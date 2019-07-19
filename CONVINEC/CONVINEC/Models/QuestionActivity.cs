namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionActivity")]
    public partial class QuestionActivity
    {
        [Key]
        public int pkQuestionActivity { get; set; }

        public int fkQuestion { get; set; }

        public int fkTypeAction { get; set; }

        [Required]
        [StringLength(100)]
        public string fullname { get; set; }

        public DateTime date { get; set; }

        [Required]
        public string description { get; set; }

        public bool isActive { get; set; }

        public virtual Question Question { get; set; }

        public virtual TypeAction TypeAction { get; set; }
    }
}
