using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
   public class GloboKasDbContext : DbContext
    {
        public GloboKasDbContext(DbContextOptions<GloboKasDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Calificacion> Calificacion { get; set; }
         public virtual DbSet<Cliente> Cliente { get; set; }
         public virtual DbSet<Rol> Rol { get; set; }
         public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");
                entity.Property(e => e.Idcliente).HasColumnName("idcliente");
                entity.Property(e => e.Punto).HasColumnType("punto");
                entity.Property(e => e.Fechacreacion).HasColumnName("fechacreacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.IdUsuario).HasColumnName("IDUSUARIO");
                entity.Property(e => e.Correo).HasColumnName("CORREO");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.IdRol).HasColumnName("IDROL");
                entity.Property(e => e.Descripcion).HasColumnType("DESCRIPCION");
                entity.Property(e => e.Estado).HasColumnName("ESTADO");
                entity.Property(e => e.FechaCreacion).HasColumnName("FECHACREACION");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Idrol).HasColumnName("idrol");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.Estado).HasColumnName("estado");

            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Idcliente).HasColumnName("idcliente");
                //entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");
                entity.Property(e => e.Nombre).HasColumnName("nombre");

            });

        }
    }
    }
