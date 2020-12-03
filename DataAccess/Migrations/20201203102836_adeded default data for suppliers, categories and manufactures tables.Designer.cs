﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201203102836_adeded default data for suppliers, categories and manufactures tables")]
    partial class adededdefaultdataforsupplierscategoriesandmanufacturestables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BlogModels.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Category 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Category 4"
                        });
                });

            modelBuilder.Entity("BlogModels.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufactures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manufacture 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manufacture 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manufacture 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Manufacture 4"
                        });
                });

            modelBuilder.Entity("BlogModels.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogModels.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Supplier 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Supplier 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Supplier 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Supplier 4"
                        });
                });

            modelBuilder.Entity("BlogModels.Models.Post", b =>
                {
                    b.HasOne("BlogModels.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogModels.Models.Manufacture", "Manufacture")
                        .WithMany("Posts")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogModels.Models.Supplier", "Supplier")
                        .WithMany("Posts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacture");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BlogModels.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BlogModels.Models.Manufacture", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BlogModels.Models.Supplier", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
