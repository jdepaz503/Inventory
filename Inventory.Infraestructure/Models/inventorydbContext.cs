using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Inventory.Infraestructure.Models
{
    public partial class inventorydbContext : DbContext
    {
        public inventorydbContext()
        {
        }

        public inventorydbContext(DbContextOptions<inventorydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");

                entity.ToTable("orden");

                entity.HasIndex(e => e.Sku)
                    .HasName("SKU_idx");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SKU");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
