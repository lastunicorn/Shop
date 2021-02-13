﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.WithRepositories.DataAccess.EntityFramework;

namespace Shop.WithRepositories.DataAccess.EntityFramework.Migrations
{
    [DbContext(typeof(RepositoryPatternDbContext))]
    partial class RepositoryPatternDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Shop.WithRepositories.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.WithRepositories.Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Shop.WithRepositories.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chocolate",
                            Price = 12m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 2,
                            Name = "Water",
                            Price = 5m,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chips",
                            Price = 3m,
                            Quantity = 15
                        });
                });

            modelBuilder.Entity("Shop.WithRepositories.Domain.ProductWithReservations", b =>
                {
                    b.HasBaseType("Shop.WithRepositories.Domain.Product");

                    b.ToTable("Products");

                    b.HasDiscriminator().HasValue("ProductWithReservations");
                });

            modelBuilder.Entity("Shop.WithRepositories.Domain.Order", b =>
                {
                    b.HasOne("Shop.WithRepositories.Domain.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Shop.WithRepositories.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Payment");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
