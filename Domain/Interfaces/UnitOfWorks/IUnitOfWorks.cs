namespace Domain.Interfaces.UnitOfWorks;

public interface IUnitOfWorks : IDisposable
{
        public IActionRepo ActionRepo { get;}
        public IDifficultyRepo DifficultyRepo { get; }
        public IFioRepo FioRepo { get; }
        public IGenderRepo GenderRepo { get; }
        public ILogRepo LogRepo { get; }
        public IPatientRepo PatientRepo { get; }
        public IProblemRepo ProblemRepo { get; }
      
        public IUserRepo UserRepo { get; }

        int Commit();
}