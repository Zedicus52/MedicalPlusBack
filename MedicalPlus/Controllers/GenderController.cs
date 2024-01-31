using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
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
        public GenderController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.GenderRepo.GetAll());
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.GenderRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.GenderRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Gender user)
        {
            this._unitOfWorks.GenderRepo.Update(user);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Gender user)
        {
            this._unitOfWorks.GenderRepo.Add(user);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
