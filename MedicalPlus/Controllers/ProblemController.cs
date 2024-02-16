using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedicalPlus.Controllers
{
    [Route("api/problem")]
    [Authorize]
    [ApiController]
    public class ProblemController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public ProblemController(IUnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.ProblemRepo.GetAll().Result);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(this._unitOfWorks.ProblemRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            this._unitOfWorks.ProblemRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ProblemModel problem)
        {

            Problem newProblem = await this._unitOfWorks.ProblemRepo.GetById(problem.IdProblem);
            newProblem.ChangeDate = DateTime.Now;
            newProblem.MacroDesc = problem.MacroDesc;
            newProblem.MicroDesc = problem.MicroDesc;
            newProblem.Diagnosis = problem.Diagnosis;

            newProblem.IdDifficulty = problem.IdDifficulty;
            newProblem.IdDifficultyNavigation = await this._unitOfWorks.DifficultyRepo.GetById(problem.IdDifficulty);

            newProblem.IdPatient = problem.IdPatient;
            newProblem.IdPatientNavigation = await this._unitOfWorks.PatientRepo.GetById(problem.IdPatient);

            var identity = User.Identity as ClaimsIdentity;
            User user = await this._unitOfWorks.UserRepo.GetByName(identity.Name);
            
            newProblem.IdUser = user.Id;
            newProblem.IdUserNavigation = user;

            this._unitOfWorks.ProblemRepo.Update(newProblem);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ProblemModel problem)
        {

            var identity = User.Identity as ClaimsIdentity;
            User user = await this._unitOfWorks.UserRepo.GetByName(identity.Name);
            Difficulty difficulty = await this._unitOfWorks.DifficultyRepo.GetById(problem.IdDifficulty);
            Patient patient = await this._unitOfWorks.PatientRepo.GetById(problem.IdPatient);
            Problem problemModel = new Problem(problem.Diagnosis, problem.MicroDesc, problem.MacroDesc, DateTime.UtcNow, DateTime.UtcNow, user, difficulty, patient);
            this._unitOfWorks.ProblemRepo.Add(problemModel);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
