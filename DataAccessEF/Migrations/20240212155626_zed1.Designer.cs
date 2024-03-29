﻿// <auto-generated />
using System;
using DataAccessEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessEF.Migrations
{
    [DbContext(typeof(MedicalPlusDbContext))]
    [Migration("20240212155626_zed1")]
    partial class zed1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Difficulty", b =>
                {
                    b.Property<int>("IdDifficulty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDifficulty"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDifficulty");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Domain.Models.Fio", b =>
                {
                    b.Property<int>("IdFio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFio"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFio")
                        .HasName("PK_FIOes");

                    b.ToTable("FIOs", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Gender", b =>
                {
                    b.Property<int>("IdGender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGender"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGender");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Domain.Models.Log", b =>
                {
                    b.Property<int>("IdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLog"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdAction")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLog");

                    b.HasIndex("IdAction");

                    b.HasIndex("IdUser");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Domain.Models.LogAction", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAction"));

                    b.Property<string>("ActionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Action");

                    b.HasKey("IdAction");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdFio")
                        .HasColumnType("int");

                    b.Property<int?>("IdGender")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IdPatient");

                    b.HasIndex("IdFio");

                    b.HasIndex("IdGender");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Models.Problem", b =>
                {
                    b.Property<int>("IdProblem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProblem"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdDifficulty")
                        .HasColumnType("int");

                    b.Property<int?>("IdPatient")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MacroDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MicroDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProblem");

                    b.HasIndex("IdDifficulty");

                    b.HasIndex("IdPatient");

                    b.HasIndex("IdUser");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("IdFio")
                        .HasColumnType("int");

                    b.Property<int?>("IdGender")
                        .HasColumnType("int");

                    b.Property<int?>("IdGenderNavigationIdGender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdFio");

                    b.HasIndex("IdGenderNavigationIdGender");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Log", b =>
                {
                    b.HasOne("Domain.Models.LogAction", "IdActionNavigation")
                        .WithMany("Logs")
                        .HasForeignKey("IdAction")
                        .HasConstraintName("FK_Logs_Actions");

                    b.HasOne("Domain.Models.User", "IdUserNavigation")
                        .WithMany("Logs")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_Logs_Users");

                    b.Navigation("IdActionNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.HasOne("Domain.Models.Fio", "IdFioNavigation")
                        .WithMany("Patients")
                        .HasForeignKey("IdFio")
                        .HasConstraintName("FK_Patients_FIOs");

                    b.HasOne("Domain.Models.Gender", "IdGenderNavigation")
                        .WithMany("Patients")
                        .HasForeignKey("IdGender")
                        .HasConstraintName("FK_Patients_Genders");

                    b.Navigation("IdFioNavigation");

                    b.Navigation("IdGenderNavigation");
                });

            modelBuilder.Entity("Domain.Models.Problem", b =>
                {
                    b.HasOne("Domain.Models.Difficulty", "IdDifficultyNavigation")
                        .WithMany("Problems")
                        .HasForeignKey("IdDifficulty")
                        .HasConstraintName("FK_Problems_Difficulties");

                    b.HasOne("Domain.Models.Patient", "IdPatientNavigation")
                        .WithMany("Problems")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("FK_Problems_Patients");

                    b.HasOne("Domain.Models.User", "IdUserNavigation")
                        .WithMany("Problems")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_Problems_Users");

                    b.Navigation("IdDifficultyNavigation");

                    b.Navigation("IdPatientNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Fio", "IdFioNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdFio")
                        .HasConstraintName("FK_Users_FIOs");

                    b.HasOne("Domain.Models.Gender", "IdGenderNavigation")
                        .WithMany()
                        .HasForeignKey("IdGenderNavigationIdGender");

                    b.Navigation("IdFioNavigation");

                    b.Navigation("IdGenderNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Difficulty", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Domain.Models.Fio", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Gender", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Domain.Models.LogAction", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Problems");
                });
#pragma warning restore 612, 618
        }
    }
}
