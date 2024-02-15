using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/gender")]
    [Authorize]
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public GenderController(IUnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {

            return Ok(_unitOfWorks.GenderRepo.GetAll().Result);

        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(this._unitOfWorks.GenderRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            this._unitOfWorks.GenderRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Gender gender)
        {
            this._unitOfWorks.GenderRepo.Update(gender);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] GenderModel gender)
        {
            Gender genderModel = new Gender(gender.Name);
            _unitOfWorks.GenderRepo.Add(genderModel);
            _unitOfWorks.Commit();
            return Ok();
        }
    }
}
