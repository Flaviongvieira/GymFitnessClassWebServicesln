﻿// <auto-generated />
using System;
using GymRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymRepository.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20221208181504_createDB")]
    partial class createDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymModels.FitnessClassSchedule", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<int>("ClassDuration")
                        .HasColumnType("int");

                    b.Property<int>("ClassInstrId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassStartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassStudioId")
                        .HasColumnType("int");

                    b.Property<int>("ClassWeekDay")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassInstrId");

                    b.HasIndex("ClassStudioId");

                    b.ToTable("FitnessClassSchedule");
                });

            modelBuilder.Entity("GymModels.FitnessInstructor", b =>
                {
                    b.Property<int>("InstrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrId"), 1L, 1);

                    b.Property<DateTime>("InstrDoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstrName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrId");

                    b.ToTable("FitnessInstructor");
                });

            modelBuilder.Entity("GymModels.FitnessStudio", b =>
                {
                    b.Property<int>("StudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudioId"), 1L, 1);

                    b.Property<string>("StudioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudioId");

                    b.ToTable("FitnessStudio");
                });

            modelBuilder.Entity("GymModels.FitnessClassSchedule", b =>
                {
                    b.HasOne("GymModels.FitnessInstructor", "ClassInstr")
                        .WithMany("FitClasses")
                        .HasForeignKey("ClassInstrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymModels.FitnessStudio", "ClassStudio")
                        .WithMany("FitClasses")
                        .HasForeignKey("ClassStudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassInstr");

                    b.Navigation("ClassStudio");
                });

            modelBuilder.Entity("GymModels.FitnessInstructor", b =>
                {
                    b.Navigation("FitClasses");
                });

            modelBuilder.Entity("GymModels.FitnessStudio", b =>
                {
                    b.Navigation("FitClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
