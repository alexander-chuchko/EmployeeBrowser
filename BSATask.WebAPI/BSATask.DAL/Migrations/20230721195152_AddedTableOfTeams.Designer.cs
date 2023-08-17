﻿// <auto-generated />
using System;
using BSATask.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSATask.DAL.Migrations
{
    [DbContext(typeof(BSATaskContext))]
    [Migration("20230721195152_AddedTableOfTeams")]
    partial class AddedTableOfTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BSATask.DAL.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HeadWorks"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "BinaryStudio"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Epam"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AltexSoft"
                        });
                });

            modelBuilder.Entity("BSATask.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Project", b =>
                {
                    b.HasOne("BSATask.DAL.Entities.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId");

                    b.HasOne("BSATask.DAL.Entities.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Task", b =>
                {
                    b.HasOne("BSATask.DAL.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BSATask.DAL.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.User", b =>
                {
                    b.HasOne("BSATask.DAL.Entities.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.Team", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BSATask.DAL.Entities.User", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
