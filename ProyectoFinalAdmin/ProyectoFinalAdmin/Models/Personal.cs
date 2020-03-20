namespace ProyectoFinalAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UsernameId { get; set; }

        [Required]
        [StringLength(50)]
        public string Puesto { get; set; }

        public virtual Login Login { get; set; }
    }
}
