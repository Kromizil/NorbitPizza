using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NorbitPizzaApp.Api.Model;

public partial class NorbitPizzaContext : DbContext
{
    public NorbitPizzaContext()
    {
    }

    public NorbitPizzaContext(DbContextOptions<NorbitPizzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PizzaFormat> PizzaFormats { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductIngredient> ProductIngredients { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.240.5;Initial Catalog=NorbitPizza;User Id=api;Password=P@ssW0rd;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Format>(entity =>
        {
            entity.ToTable("Format");

            entity.Property(e => e.FormatName).HasMaxLength(20);
            entity.Property(e => e.PriceMultiplier).HasColumnType("decimal(5, 3)");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.Property(e => e.IngredientName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Basket");

            entity.ToTable("Order");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(13);

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethod)
                .HasConstraintName("FK_Order_PaymentMethod");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Order_Status");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodId).ValueGeneratedNever();
            entity.Property(e => e.PaymentName).HasMaxLength(50);
        });

        modelBuilder.Entity<PizzaFormat>(entity =>
        {
            entity.ToTable("PizzaFormat");

            entity.HasOne(d => d.Format).WithMany(p => p.PizzaFormats)
                .HasForeignKey(d => d.FormatId)
                .HasConstraintName("FK_PizzaFormat_Format");

            entity.HasOne(d => d.Pizza).WithMany(p => p.PizzaFormats)
                .HasForeignKey(d => d.PizzaId)
                .HasConstraintName("FK_PizzaFormat_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Pizza");

            entity.ToTable("Product");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(2048);
            entity.Property(e => e.ImageName).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(15);

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_PizzaCategory");

            entity.ToTable("ProductCategory");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_PizzaCategory_Category");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PizzaCategory_Pizza");
        });

        modelBuilder.Entity<ProductIngredient>(entity =>
        {
            entity.HasKey(e => e.ProductIngridientId).HasName("PK_PizzaIngredient");

            entity.ToTable("ProductIngredient");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.ProductIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK_PizzaIngredient_Ingredient");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductIngredients)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PizzaIngredient_Pizza");
        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity.HasKey(e => e.ProductOrderId).HasName("PK_PizzaOrder");

            entity.ToTable("ProductOrder");

            entity.HasOne(d => d.Basket).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.BasketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PizzaBasket_Basket");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductOrder_Product");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.ProductTypeId).ValueGeneratedNever();
            entity.Property(e => e.TypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
