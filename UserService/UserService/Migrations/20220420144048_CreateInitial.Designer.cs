﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220420144048_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserService.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UserModels");
                });
#pragma warning restore 612, 618
        }
    }
}
