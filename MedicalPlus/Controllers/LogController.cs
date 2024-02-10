using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlus.Controllers
{
    [Route("api/log")]
    [Authorize]
    [ApiController]
    public class LogController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public LogController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.LogRepo.GetAll().Result);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.LogRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.LogRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Log log)
        {
            log.ChangeDate = DateTime.UtcNow;
            this._unitOfWorks.LogRepo.Update(log);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(LogModel log)
        {

            LogAction logAction= await this._unitOfWorks.ActionRepo.GetById(log.IdAction.ToString());
            User user = await this._unitOfWorks.UserRepo.GetById(log.IdUser.ToString());
            Log logModel = new Log(log.ObjectName, log.Message, DateTime.UtcNow, DateTime.UtcNow, logAction, user);
            this._unitOfWorks.LogRepo.Add(logModel);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
