using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/fio")]
    [Authorize]
    [ApiController]
    public class FioController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public FioController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.FioRepo.GetAll().Result);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.FioRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.FioRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Fio fio)
        {
            this._unitOfWorks.FioRepo.Update(fio);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(FioModel fio)
        {
            Fio fioModel = new Fio(fio.Name,fio.Surname,fio.Patronymic);
            this._unitOfWorks.FioRepo.Add(fioModel);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
