using DataAccessEF.Data;
using DataAccessEF.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.UnitOfWorks;

namespace DataAccessEF.UnitOfWorks;

public class UnitOfWorks : IUnitOfWorks
{
    public IActionRepo ActionRepo { get; }
    public IDifficultyRepo DifficultyRepo { get; }
    public IFioRepo FioRepo { get; }
    public IGenderRepo GenderRepo { get; }
    public ILogRepo LogRepo { get; }
    public IPatientRepo PatientRepo { get; }
    public IProblemRepo ProblemRepo { get; }

    public IUserRepo UserRepo { get; }
    private readonly MedicalPlusDbContext _dbContext;


    public UnitOfWorks(MedicalPlusDbContext dbContext)
    {
        _dbContext = dbContext;
        ActionRepo = new ActionRepo(_dbContext);
        DifficultyRepo = new DifficultyRepo(_dbContext);
        FioRepo = new FioRepo(_dbContext);
        GenderRepo = new GenderRepo(_dbContext);
        LogRepo = new LogRepo(_dbContext);
        PatientRepo = new PatientRepo(_dbContext);
        ProblemRepo = new ProblemRepo(_dbContext);
     
        UserRepo = new UserRepo(_dbContext);
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}