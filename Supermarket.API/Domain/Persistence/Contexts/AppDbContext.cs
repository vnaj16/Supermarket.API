using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Category Entity
            //Con esto creo las tablas, se pone en plural de la entity
            builder.Entity<Category>().ToTable("Categories").HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            #endregion

            //Seed Data
            builder.Entity<Category>().HasData
                (
                new Category { Id = 100, Name = "Frutas" },
                new Category { Id = 101, Name = "Dulces" }
                );

            #region Product Entity
            builder.Entity<Product>().ToTable("Products").HasKey(p=>p.Id);
            builder.Entity<Product>().Property(p => p.Id).
                IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).
                IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            #endregion

            #region Tag Entity
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Tag>().HasKey(t => t.Id);
            builder.Entity<Tag>().Property(t => t.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(t => t.Name)
                .IsRequired().HasMaxLength(30);
            #endregion

            #region ProducTag Entity
            builder.Entity<ProductTag>().ToTable("ProductTags");
            builder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);
            #endregion

            //Apply Naming Conventions Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
