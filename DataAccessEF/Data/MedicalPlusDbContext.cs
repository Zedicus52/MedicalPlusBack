using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessEF.Data;

public partial class MedicalPlusDbContext : DbContext
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

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
}
