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
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
