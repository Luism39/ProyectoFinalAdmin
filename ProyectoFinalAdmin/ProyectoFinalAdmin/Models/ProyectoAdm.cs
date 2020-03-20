namespace ProyectoFinalAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProyectoAdm : DbContext
    {
        public ProyectoAdm()
            : base("name=ProyectoAdm")
        {
        }

        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Version_Doc)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.RepeatPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Documento)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.UsernameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Personal)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.UsernameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.UsernameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Usuario1)
                .WithRequired(e => e.Login1)
                .HasForeignKey(e => e.EmailId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Puesto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Puesto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nivel)
                .IsUnicode(false);
        }
    }
}
