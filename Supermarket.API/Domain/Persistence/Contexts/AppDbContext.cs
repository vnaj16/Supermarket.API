using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
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
        }
    }
}
