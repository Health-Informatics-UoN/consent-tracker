﻿// <auto-generated />
using System;
using ConsentApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConsentApp.Data.Entities.Patient", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DoB")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ConsentApp.Data.Entities.Study", b =>
                {
                    b.Property<string>("StudyId")
                        .HasColumnType("text");

                    b.HasKey("StudyId");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("PatientStudy", b =>
                {
                    b.Property<string>("PatientsPatientId")
                        .HasColumnType("text");

                    b.Property<string>("StudiesStudyId")
                        .HasColumnType("text");

                    b.HasKey("PatientsPatientId", "StudiesStudyId");

                    b.HasIndex("StudiesStudyId");

                    b.ToTable("PatientStudy");
                });

            modelBuilder.Entity("PatientStudy", b =>
                {
                    b.HasOne("ConsentApp.Data.Entities.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsentApp.Data.Entities.Study", null)
                        .WithMany()
                        .HasForeignKey("StudiesStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
