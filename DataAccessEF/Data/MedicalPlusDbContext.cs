using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessEF.Data;

public partial class MedicalPlusDbContext : IdentityDbContext<User>

{
    public MedicalPlusDbContext(DbContextOptions configurations) : base(configurations)
    {
    }

    public virtual DbSet<Domain.Models.Action> Actions { get; set; }

    public virtual DbSet<Difficulty> Difficulties { get; set; }

    public virtual DbSet<Fio> Fios { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=DESKTOP-TI1VB56\\SQLEXPRESS;Database=MedicalPlus;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Models.Action>(entity =>
        {
            entity.HasKey(e => e.IdAction);
            entity.Property(e => e.ActionText).HasColumnName("Action");
        });

        modelBuilder.Entity<Difficulty>(entity =>
        {
            entity.HasKey(e => e.IdDifficulty);
        });

        modelBuilder.Entity<Fio>(entity =>
        {
            entity.HasKey(e => e.IdFio).HasName("PK_FIOes");
            entity.ToTable("FIOs");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.IdLog);
            entity.Property(e => e.ChangeDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.HasOne(d => d.IdActionNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdAction)
                .HasConstraintName("FK_Logs_Actions");
            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Logs_Users");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient);
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.HasOne(d => d.IdFioNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdFio)
                .HasConstraintName("FK_Patients_FIOs");
            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("FK_Patients_Genders");
            entity.HasOne(d => d.IdProblemNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdProblem)
                .HasConstraintName("FK_Patients_Problems");
        });

        modelBuilder.Entity<Problem>(entity =>
        {
            entity.HasKey(e => e.IdProblem);
            entity.Property(e => e.ChangeDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.HasOne(d => d.IdDifficultyNavigation).WithMany(p => p.Problems)
                .HasForeignKey(d => d.IdDifficulty)
                .HasConstraintName("FK_Problems_Difficulties");
            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Problems)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Problems_Users");
        });



        modelBuilder.Entity<User>(entity =>
        {
         
            entity.HasOne(d => d.IdFioNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdFio)
                .HasConstraintName("FK_Users_FIOs");
   
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
