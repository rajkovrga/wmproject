using BlogModels.Models;
using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LNVJ1GV\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Category 1"
            },
            new Category
            {
                Id = 2,
                Name = "Category 2"
            },
            new Category
            {
                Id = 3,
                Name = "Category 3"
            },
            new Category
            {
                Id = 4,
                Name = "Category 4"
            });
            modelBuilder.Entity<Manufacture>().HasData(new Manufacture
            {
                Id = 1,
                Name = "Manufacture 1"
            },
            new Category
            {
                Id = 2,
                Name = "Manufacture 2"
            },
            new Category
            {
                Id = 3,
                Name = "Manufacture 3"
            },
            new Category
            {
                Id = 4,
                Name = "Manufacture 4"
            });
            modelBuilder.Entity<Supplier>().HasData(new Supplier
            {
                Id = 1,
                Name = "Supplier 1"
            },
           new Category
           {
               Id = 2,
               Name = "Supplier 2"
           },
           new Category
           {
               Id = 3,
               Name = "Supplier 3"
           },
           new Category
           {
               Id = 4,
               Name = "Supplier 4"
           });
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
