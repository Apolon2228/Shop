using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models;

public partial class ApiAkhmetovContext : DbContext
{
    public ApiAkhmetovContext()
    {
    }

    public ApiAkhmetovContext(DbContextOptions<ApiAkhmetovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Compatibility> Compatibilities { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__DAD4F3BEBA3D4401");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B1840944F");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compatibility>(entity =>
        {
            entity.HasKey(e => e.CompatibilityId).HasName("PK__Compatib__D56A70CBE3D367F1");

            entity.ToTable("Compatibility");

            entity.Property(e => e.CompatibilityId).HasColumnName("CompatibilityID");
            entity.Property(e => e.ProductId1).HasColumnName("ProductID1");
            entity.Property(e => e.ProductId2).HasColumnName("ProductID2");

            entity.HasOne(d => d.ProductId1Navigation).WithMany(p => p.CompatibilityProductId1Navigations)
                .HasForeignKey(d => d.ProductId1)
                .HasConstraintName("FK__Compatibi__Produ__47DBAE45");

            entity.HasOne(d => d.ProductId2Navigation).WithMany(p => p.CompatibilityProductId2Navigations)
                .HasForeignKey(d => d.ProductId2)
                .HasConstraintName("FK__Compatibi__Produ__48CFD27E");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF999A3FFF");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__5165187F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED411CDF7B");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__BrandI__3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__3B75D760");
        });

        modelBuilder.Entity<ProductSupplier>(entity =>
        {
            entity.HasKey(e => e.ProductSupplierId).HasName("PK__ProductS__BEABB5A06883CC14");

            entity.Property(e => e.ProductSupplierId).HasColumnName("ProductSupplierID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSuppliers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductSu__Produ__4D94879B");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ProductSuppliers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__ProductSu__Suppl__4E88ABD4");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AED3CF31E7");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__Product__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__44FF419A");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PK__Specific__A384CC1D23BC87BD");

            entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");
            entity.Property(e => e.Keys)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("keys");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Specifica__Produ__3F466844");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE6669474BBA418");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC9602703D");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
