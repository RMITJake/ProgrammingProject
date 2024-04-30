﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientConnect.Data;

#nullable disable

namespace PatientConnect.Migrations
{
    [DbContext(typeof(PatientConnectContext))]
    partial class PatientConnectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PatientConnect.Models.Login", b =>
                {
                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(94)
                        .HasColumnType("char");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LoginID");

                    b.HasIndex("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("PatientConnect.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("PostCode")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProviderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("Specialisation")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PatientConnect.Models.Login", b =>
                {
                    b.HasOne("PatientConnect.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
