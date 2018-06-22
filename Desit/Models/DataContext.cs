using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Desit.Models
{
    public partial class DataContext : DbContext
    {
        // AGREGADA MANUALMENTE
        public static string ConnectionString { private get; set; }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AdminLog> AdminLog { get; set; }
        public virtual DbSet<AdminLogTipo> AdminLogTipo { get; set; }
        public virtual DbSet<Barrio> Barrio { get; set; }
        public virtual DbSet<Central> Central { get; set; }
        public virtual DbSet<CentralLog> CentralLog { get; set; }
        public virtual DbSet<CentralLogTipo> CentralLogTipo { get; set; }
        public virtual DbSet<IntSecuencial> IntSecuencial { get; set; }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString); // TODO: agregar MySql options???
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminNombre);

                entity.ToTable("admin");

                entity.Property(e => e.AdminNombre)
                    .HasColumnName("admin_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Contrasenia)
                    .HasColumnName("contrasenia")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<AdminLog>(entity =>
            {
                entity.ToTable("admin_log");

                entity.HasIndex(e => e.AdminLogTipoId)
                    .HasName("fk_administrador_log_administrador_log_tipo1_idx");

                entity.HasIndex(e => e.AdminNombre)
                    .HasName("fk_administrador_log_administrador1_idx");

                entity.Property(e => e.AdminLogId)
                    .HasColumnName("admin_log_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminLogTipoId)
                    .HasColumnName("admin_log_tipo_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminNombre)
                    .IsRequired()
                    .HasColumnName("admin_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.AdminLogTipo)
                    .WithMany(p => p.AdminLog)
                    .HasForeignKey(d => d.AdminLogTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_administrador_log_administrador_log_tipo1");

                entity.HasOne(d => d.AdminNombreNavigation)
                    .WithMany(p => p.AdminLog)
                    .HasForeignKey(d => d.AdminNombre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_administrador_log_administrador1");
            });

            modelBuilder.Entity<AdminLogTipo>(entity =>
            {
                entity.ToTable("admin_log_tipo");

                entity.Property(e => e.AdminLogTipoId)
                    .HasColumnName("admin_log_tipo_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.ToTable("barrio");

                entity.HasIndex(e => e.Nombre)
                    .HasName("nombre_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BarrioId)
                    .HasColumnName("barrio_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Central>(entity =>
            {
                entity.ToTable("central");

                entity.HasIndex(e => e.BarrioId)
                    .HasName("fk_central_barrio_idx");

                entity.Property(e => e.CentralId)
                    .HasColumnName("central_ID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.BarrioId)
                    .HasColumnName("barrio_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasColumnName("contrasenia")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Barrio)
                    .WithMany(p => p.Central)
                    .HasForeignKey(d => d.BarrioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_central_barrio");
            });

            modelBuilder.Entity<CentralLog>(entity =>
            {
                entity.ToTable("central_log");

                entity.HasIndex(e => e.CentralId)
                    .HasName("fk_central_log_central1_idx");

                entity.HasIndex(e => e.CentralLogTipoId)
                    .HasName("fk_central_log_central_log_tipo1_idx");

                entity.Property(e => e.CentralLogId)
                    .HasColumnName("central_log_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CentralId)
                    .IsRequired()
                    .HasColumnName("central_ID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.CentralLogTipoId)
                    .HasColumnName("central_log_tipo_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Central)
                    .WithMany(p => p.CentralLog)
                    .HasForeignKey(d => d.CentralId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_central_log_central1");

                entity.HasOne(d => d.CentralLogTipo)
                    .WithMany(p => p.CentralLog)
                    .HasForeignKey(d => d.CentralLogTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_central_log_central_log_tipo1");
            });

            modelBuilder.Entity<CentralLogTipo>(entity =>
            {
                entity.ToTable("central_log_tipo");

                entity.Property(e => e.CentralLogTipoId)
                    .HasColumnName("central_log_tipo_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<IntSecuencial>(entity =>
            {
                entity.ToTable("int_secuencial");

                entity.Property(e => e.IntSecuencialId)
                    .HasColumnName("int_secuencial_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intervalo)
                    .HasColumnName("intervalo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reintentos)
                    .HasColumnName("reintentos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Timeout)
                    .HasColumnName("timeout")
                    .HasColumnType("int(11)");
            });
        }
    }
}
