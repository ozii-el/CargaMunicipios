using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CargarDatos.Models
{
    public partial class CesarElcoBitContext : DbContext
    {
        public CesarElcoBitContext()
        {
        }

        public CesarElcoBitContext(DbContextOptions<CesarElcoBitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EntidadFederativa> EntidadFederativas { get; set; }
        public virtual DbSet<Localidad> Localidads { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EntidadFederativa>(entity =>
            {
                entity.HasKey(e => e.EntidadId);

                entity.ToTable("EntidadFederativa");

                entity.Property(e => e.EntidadId)
                    .ValueGeneratedNever()
                    .HasColumnName("EntidadID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAbreviado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => new { e.EntidadId, e.MunicipioId, e.LocalidadId });

                entity.ToTable("Localidad");

                entity.Property(e => e.EntidadId).HasColumnName("EntidadID");

                entity.Property(e => e.MunicipioId).HasColumnName("MunicipioID");

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadID");

                entity.Property(e => e.Ambito)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LatitudDecimal).HasColumnType("decimal(12, 8)");

                entity.Property(e => e.LongitudDecimal).HasColumnType("decimal(12, 8)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => new { e.EntidadId, e.MunicipioId });

                entity.ToTable("Municipio");

                entity.Property(e => e.EntidadId).HasColumnName("EntidadID");

                entity.Property(e => e.MunicipioId).HasColumnName("MunicipioID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
