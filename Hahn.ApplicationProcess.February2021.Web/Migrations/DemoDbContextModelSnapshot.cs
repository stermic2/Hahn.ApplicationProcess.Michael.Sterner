﻿// <auto-generated />
using System;
using Hahn.ApplicationProcess.February2021.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hahn.ApplicationProcess.February2021.Web.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    partial class DemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "en_US.utf8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Hahn.ApplicationProcess.February2021.Domain.Models.Asset.AssetEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AssetName")
                        .HasColumnType("text");

                    b.Property<bool>("Broken")
                        .HasColumnType("boolean");

                    b.Property<string>("CountryOfDepartment")
                        .HasColumnType("text");

                    b.Property<int>("Department")
                        .HasColumnType("integer");

                    b.Property<string>("EMailAddressOfDepartment")
                        .HasColumnType("text");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}