using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class ItemsContext : DbContext
    {
        public ItemsContext()
        {
        }

        public ItemsContext(DbContextOptions<ItemsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V72DRD0\\SQLEXPRESS;Database=Items;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Discount)
                    .IsRequired()
                    .HasColumnName("discount");

                entity.Property(e => e.Editable)
                    .IsRequired()
                    .HasColumnName("editable");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.NewPrice).HasColumnName("newPrice");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price");

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasColumnName("supplier");
            });
        }
    }
}
