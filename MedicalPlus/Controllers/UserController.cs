using DataAccessEF.Repositories;
using DataAccessEF.UnitOfWorks;
using Domain.Identity;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;
using Domain.Models.WebModels;
using MedicalPlus.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicalPlus.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWorks _unitOfWorks;
        public UserController(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._unitOfWorks = unitOfWorks;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var fios = await _unitOfWorks.FioRepo.GetAll();
            var genders = await _unitOfWorks.GenderRepo.GetAll();
            List<User> users = await this._unitOfWorks.UserRepo.GetAll();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach (var user in users)
            {

                var roles = await _userManager.GetRolesAsync(user);
                RoleModel role = new RoleModel() { Id = "0", Name = "default" };
                if (roles.Count != 0)
                {
                    var temp = await _roleManager.FindByNameAsync(roles[0]);
                    role = GetRoleByName(temp);
                }

                Fio fio = fios.FirstOrDefault(x=>x.IdFio==user.IdFio);
                Gender gender = genders.FirstOrDefault(x => x.IdGender == user.IdGenderNavigation.IdGender);
                EmployeeModel employee = new EmployeeModel()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    Role = role,
                    Password = user.PasswordHash,
                    CurrentPassword = user.PasswordHash,
                    UserName = user.UserName,
                    Fio = new FioModel(fio.IdFio, fio.Name, fio.Surname, fio.Patronymic),
                    Gender = new GenderModel(gender.IdGender, gender.Name)
                };
                employees.Add(employee);
            }
            return Ok(employees);
        }


        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {

            User user = await this._unitOfWorks.UserRepo.GetById(id);


            var roles = await _userManager.GetRolesAsync(user);
            RoleModel role = new RoleModel() { Id = "0", Name = "default" };
            if (roles.Count != 0)
            {
                var temp = await _roleManager.FindByNameAsync(roles[0]);
                role = new RoleModel() { Id = temp.Id, Name = temp.Name };
            }

            EmployeeModel employee = new EmployeeModel()
            {
                Email = user.Email,
                UserId = user.Id,
                Role = role,
                Password = user.PasswordHash,
                CurrentPassword = user.PasswordHash,
                UserName = user.UserName,
                Fio = new FioModel(user.IdFioNavigation.IdFio, user.IdFioNavigation.Name, user.IdFioNavigation.Surname, user.IdFioNavigation.Patronymic),
                Gender = new GenderModel(user.IdGenderNavigation.IdGender, user.IdGenderNavigation.Name)
            };



            return Ok(employee);
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
        public async Task<IActionResult> Update([FromBody]EmployeeModel employee)
        {
            User dbEmployee = _unitOfWorks.UserRepo.GetAll().Result.FirstOrDefault(p => p.Id.Equals(employee.UserId));
            if (dbEmployee != null)
            {
                Fio fio = _unitOfWorks.FioRepo.GetAll().Result.FirstOrDefault(f => f.IdFio.Equals(employee.Fio.IdFio));
                if (fio != null)
                {
                    fio.Surname = employee.Fio.Surname;
                    fio.Name = employee.Fio.Name;
                    fio.Patronymic = employee.Fio.Patronymic;
                }

                Gender gender = _unitOfWorks.GenderRepo.GetAll().Result.FirstOrDefault(g => g.IdGender.Equals(employee.Gender.IdGender));
                if (gender != null)
                    dbEmployee.IdGenderNavigation = gender;

                var roles = await _userManager.GetRolesAsync(dbEmployee);
                await _userManager.RemoveFromRolesAsync(dbEmployee, roles);
                var role = _roleManager.Roles.FirstOrDefault(x => x.Id.Equals(employee.Role.Id));
                if (role != null)
                    await _userManager.AddToRoleAsync(dbEmployee, role.Name);
                else
                    await _userManager.AddToRoleAsync(dbEmployee, UserRoles.User);

            }
            _unitOfWorks.Commit();
            return Ok();
        }

        private RoleModel GetRoleByName(IdentityRole role)
        {
            RoleModel model = new()
            {
                Id = role.Id
            };
            model.Name = role.Name switch
            {
                UserRoles.Admin => "Адміністратор",
                UserRoles.Doctor => "Доктор",
                UserRoles.Assistant => "Лаборант",
                UserRoles.Recorder => "Регістратор",
                _ => model.Name
            };
            return model;
        }
    }
}
