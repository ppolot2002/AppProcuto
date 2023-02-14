using System;
using System.Collections.Generic;
using Datos.Models;
using Microsoft.EntityFrameworkCore;

namespace Datos.DataContext
{

    public partial class DbapiContext : DbContext
    {
        public DbapiContext()
        {
        }

        public DbapiContext(DbContextOptions<DbapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTO__B40CC6CD300FE10D");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}