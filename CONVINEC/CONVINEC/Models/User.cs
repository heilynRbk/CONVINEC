namespace CONVINEC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int pkUser { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(11)]
        [Display(Name = "Cédula")]
        public string DNI { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Completo")]
        public string fullName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime birthdate { get; set; }

        [Required]
        [StringLength(350)]
        [Display(Name = "Dirección")]
        public string address { get; set; }

        public int fkOccupation { get; set; }
        
        public bool isActive { get; set; }

        public virtual Occupation Occupation { get; set; }
    }
}
