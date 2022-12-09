﻿// <auto-generated />
using System;
using EmployeesCh12.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeesCh12.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20221209013436_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeesCh12.Models.Benefits", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<bool>("Dental")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<bool>("Health")
                        .HasColumnType("bit");

                    b.Property<decimal>("LifeIns")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool>("Vision")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("EmployeesCh12.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeesCh12.Models.DepartmentLocation", b =>
                {
                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID", "LocationID");

                    b.HasIndex("LocationID");

                    b.ToTable("DepartmentLocations");
                });

            modelBuilder.Entity("EmployeesCh12.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("BenefitID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeesCh12.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EmployeesCh12.Models.Benefits", b =>
                {
                    b.HasOne("EmployeesCh12.Models.Employee", "Employee")
                        .WithOne("Benefits")
                        .HasForeignKey("EmployeesCh12.Models.Benefits", "EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesCh12.Models.DepartmentLocation", b =>
                {
                    b.HasOne("EmployeesCh12.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeesCh12.Models.Location", "Location")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesCh12.Models.Employee", b =>
                {
                    b.HasOne("EmployeesCh12.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
