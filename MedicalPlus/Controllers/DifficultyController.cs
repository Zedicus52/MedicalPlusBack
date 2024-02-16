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
        public DifficultyController(IUnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Difficulty> difficulties = await _unitOfWorks.DifficultyRepo.GetAll();
            List<DifficultyModel> difficultyModels = new List<DifficultyModel>();   
            foreach (Difficulty difficulty in difficulties)
            {
            DifficultyModel model = new DifficultyModel();
                model.IdDifficulty = difficulty.IdDifficulty;
                model.Name= difficulty.Name;
                difficultyModels.Add(model);
            }

            return Ok(difficultyModels);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(this._unitOfWorks.DifficultyRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
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
