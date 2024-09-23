using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP.ProductManagement.Repository.Models;

public partial class ProductManagementContext : DbContext
{
    public ProductManagementContext()
    {
    }

    public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost,1435;uid=sa;pwd=123@123Abc;database=Lab1_PRN231;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName).HasMaxLength(40);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        // Seed data for Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Beverages" },
            new Category { CategoryId = 2, CategoryName = "Condiments" },
            new Category { CategoryId = 3, CategoryName = "Confections" },
            new Category { CategoryId = 4, CategoryName = "Dairy Products" },
            new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
            new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
            new Category { CategoryId = 7, CategoryName = "Produce" },
            new Category { CategoryId = 8, CategoryName = "Seafood" }
        );

        // Seed data for Products
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Chai", CategoryId = 1, UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductId = 2, ProductName = "Chang", CategoryId = 1, UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductId = 3, ProductName = "Aniseed Syrup", CategoryId = 2, UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", CategoryId = 2, UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix", CategoryId = 2, UnitPrice = 21.35m, UnitsInStock = 0 },
            new Product { ProductId = 6, ProductName = "Grandma's Boysenberry Spread", CategoryId = 2, UnitPrice = 25.00m, UnitsInStock = 120 },
            new Product { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears", CategoryId = 7, UnitPrice = 30.00m, UnitsInStock = 15 },
            new Product { ProductId = 8, ProductName = "Northwoods Cranberry Sauce", CategoryId = 2, UnitPrice = 40.00m, UnitsInStock = 6 },
            new Product { ProductId = 9, ProductName = "Mishi Kobe Niku", CategoryId = 6, UnitPrice = 97.00m, UnitsInStock = 29 },
            new Product { ProductId = 10, ProductName = "Ikura", CategoryId = 8, UnitPrice = 31.00m, UnitsInStock = 31 },
            new Product { ProductId = 11, ProductName = "Queso Cabrales", CategoryId = 4, UnitPrice = 21.00m, UnitsInStock = 22 },
            new Product { ProductId = 12, ProductName = "Queso Manchego La Pastora", CategoryId = 4, UnitPrice = 38.00m, UnitsInStock = 86 },
            new Product { ProductId = 13, ProductName = "Konbu", CategoryId = 8, UnitPrice = 6.00m, UnitsInStock = 24 },
            new Product { ProductId = 14, ProductName = "Tofu", CategoryId = 7, UnitPrice = 23.25m, UnitsInStock = 35 },
            new Product { ProductId = 15, ProductName = "Genen Shouyu", CategoryId = 2, UnitPrice = 15.50m, UnitsInStock = 39 },
            new Product { ProductId = 16, ProductName = "Pavlova", CategoryId = 3, UnitPrice = 17.45m, UnitsInStock = 52 },
            new Product { ProductId = 17, ProductName = "Alice Mutton", CategoryId = 6, UnitPrice = 39.00m, UnitsInStock = 0 },
            new Product { ProductId = 18, ProductName = "Carnarvon Tigers", CategoryId = 8, UnitPrice = 62.50m, UnitsInStock = 8 },
            new Product { ProductId = 19, ProductName = "Teatime Chocolate Biscuits", CategoryId = 3, UnitPrice = 9.20m, UnitsInStock = 25 },
            new Product { ProductId = 20, ProductName = "Sir Rodney's Marmalade", CategoryId = 3, UnitPrice = 81.00m, UnitsInStock = 40 },
            new Product { ProductId = 21, ProductName = "Sir Rodney's Scones", CategoryId = 3, UnitPrice = 10.00m, UnitsInStock = 3 }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
