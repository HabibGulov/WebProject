﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProject.Migrations
{
    [DbContext(typeof(StaffManagementDBContext))]
    [Migration("20241006145338_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Country");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("CreatedAt")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("DateOfBirth");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("HireDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastName");

                    b.Property<Guid?>("ManagerId")
                        .IsRequired()
                        .HasColumnType("uuid")
                        .HasColumnName("ManagerId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Phone");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Position");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Salary");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("UpdatedAt")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Employees", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
