﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.Persistence.Context;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    [DbContext(typeof(eCommerceDbContext))]
    [Migration("20220329162433_addnewtable")]
    partial class addnewtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUserAddress", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UsersAddresses");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUserInfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userAddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("userAddressID");

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.CartItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("cartID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("cartID");

                    b.HasIndex("productID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("categoryID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.SellerList", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("productID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.ToTable("SellerLists");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUserInfo", b =>
                {
                    b.HasOne("eCommerce.Domain.Entities.AppUserAddress", "userAddress")
                        .WithMany("userInfoList")
                        .HasForeignKey("userAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Domain.Entities.AppUser", "User")
                        .WithOne("userInfo")
                        .HasForeignKey("eCommerce.Domain.Entities.AppUserInfo", "userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("userAddress");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("eCommerce.Domain.Entities.Cart", "Cart")
                        .WithMany("CartItemList")
                        .HasForeignKey("cartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Product", b =>
                {
                    b.HasOne("eCommerce.Domain.Entities.Category", "category")
                        .WithMany("ProductList")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.SellerList", b =>
                {
                    b.HasOne("eCommerce.Domain.Entities.Product", "product")
                        .WithMany("SellerList")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("userInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.AppUserAddress", b =>
                {
                    b.Navigation("userInfoList");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Cart", b =>
                {
                    b.Navigation("CartItemList");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("eCommerce.Domain.Entities.Product", b =>
                {
                    b.Navigation("SellerList");
                });
#pragma warning restore 612, 618
        }
    }
}
