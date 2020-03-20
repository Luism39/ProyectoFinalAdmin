namespace ProyectoFinalAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UsernameId { get; set; }

        public int EmailId { get; set; }

        [Required]
        [StringLength(100)]
        public string Puesto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; }

        public virtual Login Login { get; set; }

        public virtual Login Login1 { get; set; }
    }
}
