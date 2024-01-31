using DataAccessEF.Repositories;
using DataAccessEF.UnitOfWorks;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using MedicalPlus.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicalPlus.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public UserController(UnitOfWorks unitOfWorks)
        {
            this._unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this._unitOfWorks.UserRepo.GetAll());
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(this._unitOfWorks.UserRepo.GetById(id));
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            this._unitOfWorks.UserRepo.Delete(id);
            this._unitOfWorks.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(User user)
        {
            this._unitOfWorks.UserRepo.Update(user);
            this._unitOfWorks.Commit();
            return Ok();
        }
    }
}
