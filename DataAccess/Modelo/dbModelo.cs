namespace DataAccess.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbModelo : DbContext
    {
        public dbModelo()
            : base("name=dbModelo")
        {
        }

        public virtual DbSet<AREA> AREA { get; set; }
        public virtual DbSet<INMUEBLE> INMUEBLE { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<USUARIO_AREA> USUARIO_AREA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AREA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<AREA>()
                .Property(e => e.INMUEBLE)
                .IsUnicode(false);

            modelBuilder.Entity<AREA>()
                .HasMany(e => e.USUARIO_AREA)
                .WithRequired(e => e.AREA1)
                .HasForeignKey(e => e.AREA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INMUEBLE>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<INMUEBLE>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO_PATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO_MATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.USUARIO_AREA)
                .WithRequired(e => e.USUARIO1)
                .HasForeignKey(e => e.USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
