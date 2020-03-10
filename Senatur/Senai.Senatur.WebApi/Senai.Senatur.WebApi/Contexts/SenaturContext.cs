using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class SenaturContext : DbContext
    {
        public SenaturContext()
        {
        }

        public SenaturContext(DbContextOptions<SenaturContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<TiposUsuarioDomain> TiposUsuario { get; set; }
        public virtual DbSet<UsuariosDomain> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=N-1S-DEV-13\\SQLEXPRESS; Initial Catalog=Senatur_Tarde_; user Id=sa; pwd=sa@132;");

                //DEV7\\SQLEXPRESS

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasKey(e => e.IdPacote);

                entity.Property(e => e.DataIda).HasColumnType("date");

                entity.Property(e => e.DataVolta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomePacote)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarioDomain>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosDomain>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB97315118DD33")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__4E88ABD4");
            });
        }
    }
}
