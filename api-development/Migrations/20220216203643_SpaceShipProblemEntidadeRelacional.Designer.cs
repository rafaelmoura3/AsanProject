﻿// <auto-generated />
using System;
using AsanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsanAPI.Migrations
{
    [DbContext(typeof(AsanContext))]
    [Migration("20220216203643_SpaceShipProblemEntidadeRelacional")]
    partial class SpaceShipProblemEntidadeRelacional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsanAPI.Models.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Efficiency")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("AsanAPI.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("AsanAPI.Models.Problem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceShipTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpaceShipTypeId");

                    b.ToTable("SpaceShips");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShipProblem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int>("ProblemId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceShipId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("ProblemId");

                    b.HasIndex("SpaceShipId");

                    b.ToTable("SpaceShipProblem");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpaceShipTypes");
                });

            modelBuilder.Entity("AsanAPI.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("AsanAPI.Models.ToolPerPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Efficiency")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("ToolId");

                    b.ToTable("ToolPerParts");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShip", b =>
                {
                    b.HasOne("AsanAPI.Models.SpaceShipType", "SpaceShipType")
                        .WithMany("SpaceShip")
                        .HasForeignKey("SpaceShipTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SpaceShipType");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShipProblem", b =>
                {
                    b.HasOne("AsanAPI.Models.Part", "Part")
                        .WithMany("SpaceShipProblem")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AsanAPI.Models.Problem", "Problem")
                        .WithMany("SpaceShipProblem")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AsanAPI.Models.SpaceShip", "SpaceShip")
                        .WithMany("SpaceShipProblem")
                        .HasForeignKey("SpaceShipId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Part");

                    b.Navigation("Problem");

                    b.Navigation("SpaceShip");
                });

            modelBuilder.Entity("AsanAPI.Models.ToolPerPart", b =>
                {
                    b.HasOne("AsanAPI.Models.Part", "Part")
                        .WithMany("ToolPerParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AsanAPI.Models.Tool", "Tool")
                        .WithMany("ToolPerParts")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Part");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("AsanAPI.Models.Part", b =>
                {
                    b.Navigation("SpaceShipProblem");

                    b.Navigation("ToolPerParts");
                });

            modelBuilder.Entity("AsanAPI.Models.Problem", b =>
                {
                    b.Navigation("SpaceShipProblem");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShip", b =>
                {
                    b.Navigation("SpaceShipProblem");
                });

            modelBuilder.Entity("AsanAPI.Models.SpaceShipType", b =>
                {
                    b.Navigation("SpaceShip");
                });

            modelBuilder.Entity("AsanAPI.Models.Tool", b =>
                {
                    b.Navigation("ToolPerParts");
                });
#pragma warning restore 612, 618
        }
    }
}
