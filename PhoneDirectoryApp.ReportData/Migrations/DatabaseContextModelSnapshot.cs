﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneDirectoryApp.ReportData.ReportContext;

namespace PhoneDirectoryApp.ReportData.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PhoneDirectoryApp.ReportData.Model.Report", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("RecordPhoneCount")
                        .HasColumnType("integer");

                    b.Property<int>("RecordUserCount")
                        .HasColumnType("integer");

                    b.Property<string>("ReportName")
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Report","public");
                });
#pragma warning restore 612, 618
        }
    }
}
