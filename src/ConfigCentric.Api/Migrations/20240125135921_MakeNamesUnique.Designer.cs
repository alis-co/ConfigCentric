﻿// <auto-generated />
using System;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConfigCentric.Api.Migrations
{
    [DbContext(typeof(ConfigCentricDbContext))]
    [Migration("20240125135921_MakeNamesUnique")]
    partial class MakeNamesUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConfigCentric.Api.Models.ConfigValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("EnvironmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("Name", "EnvironmentId")
                        .IsUnique();

                    b.ToTable("ConfigValues");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.Environment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("Name", "ProjectId")
                        .IsUnique();

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.ConfigValue", b =>
                {
                    b.HasOne("ConfigCentric.Api.Models.Environment", "Environment")
                        .WithMany("ConfigValues")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Environment");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.Environment", b =>
                {
                    b.HasOne("ConfigCentric.Api.Models.Project", "Project")
                        .WithMany("Environments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.Environment", b =>
                {
                    b.Navigation("ConfigValues");
                });

            modelBuilder.Entity("ConfigCentric.Api.Models.Project", b =>
                {
                    b.Navigation("Environments");
                });
#pragma warning restore 612, 618
        }
    }
}
