using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/problem")]
    [Authorize]
    [ApiController]
    public class ProblemController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public ProblemController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.ProblemRepo.GetAll());
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.ProblemRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.ProblemRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Problem user)
        {
            this._unitOfWorks.ProblemRepo.Update(user);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Problem user)
        {
            this._unitOfWorks.ProblemRepo.Add(user);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
