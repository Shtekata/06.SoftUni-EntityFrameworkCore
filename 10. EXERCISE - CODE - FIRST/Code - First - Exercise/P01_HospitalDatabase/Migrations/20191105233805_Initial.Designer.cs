﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20191105233805_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.Property<int>("DiagnoseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int>("PatientId");

                    b.HasKey("DiagnoseId");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<bool>("HasInsurance");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.Property<int>("PatientId");

                    b.Property<int>("MedicamentId");

                    b.HasKey("PatientId", "MedicamentId");

                    b.HasIndex("MedicamentId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.Property<int>("VisitationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("PatientId");

                    b.HasKey("VisitationId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visitations");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Diagnoses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Medicament", "Medicament")
                        .WithMany("Patients")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Medicaments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Visitations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
