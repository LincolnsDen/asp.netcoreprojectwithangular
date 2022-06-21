﻿// <auto-generated />
using System;
using AngularMonthlyProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularMonthlyProject.Migrations
{
    [DbContext(typeof(DbContextAng))]
    partial class DbContextAngModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularMonthlyProject.Models.Fruit", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeasonID")
                        .HasColumnType("int");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SeasonID");

                    b.ToTable("fruits");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.FruitSupplier", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("fruitSuppliers");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.Season", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("seasons");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.Vegetable", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SeasonID");

                    b.ToTable("vegetables");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.Fruit", b =>
                {
                    b.HasOne("AngularMonthlyProject.Models.Season", "Season")
                        .WithMany("Fruits")
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.Vegetable", b =>
                {
                    b.HasOne("AngularMonthlyProject.Models.Season", "Season")
                        .WithMany("Vegetables")
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("AngularMonthlyProject.Models.Season", b =>
                {
                    b.Navigation("Fruits");

                    b.Navigation("Vegetables");
                });
#pragma warning restore 612, 618
        }
    }
}
