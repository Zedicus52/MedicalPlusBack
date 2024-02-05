using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/difficulty")]
    [Authorize]
    [ApiController]
    public class DifficultyController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public DifficultyController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.DifficultyRepo.GetAll());
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.DifficultyRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.DifficultyRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Difficulty difficulty)
        {
            this._unitOfWorks.DifficultyRepo.Update(difficulty);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(DifficultyModel difficulty)
        {

            Difficulty difficultyModel = new Difficulty(difficulty.Name);
            this._unitOfWorks.DifficultyRepo.Add(difficultyModel);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
