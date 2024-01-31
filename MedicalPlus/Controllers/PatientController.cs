using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/patient")]
    [Authorize]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public PatientController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.PatientRepo.GetAll());
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.PatientRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.PatientRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Patient user)
        {
            this._unitOfWorks.PatientRepo.Update(user);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Patient user)
        {
            this._unitOfWorks.PatientRepo.Add(user);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
