﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientConnect.Models;

#nullable disable

namespace PatientConnect.Migrations
{
    [DbContext(typeof(PatientConnectDbContext))]
    partial class PatientConnectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("PatientConnect.Models.Doctor", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProviderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Specialty")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("PatientConnect.Models.Login", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("PatientConnect.Models.Patient", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DoctorEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Email");

                    b.HasIndex("DoctorEmail");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PatientConnect.Models.Patient", b =>
                {
                    b.HasOne("PatientConnect.Models.Doctor", null)
                        .WithMany("Patients")
                        .HasForeignKey("DoctorEmail");
                });

            modelBuilder.Entity("PatientConnect.Models.Doctor", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
