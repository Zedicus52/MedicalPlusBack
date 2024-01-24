using Domain.Identity;
using Domain.Models;
using Domain.Models.WebModels;
using MedicalPlus.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicalPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }

     


      
       

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] Login model)
        {
            var user = await this._userManager.FindByNameAsync(model.UserName);
            if (user != null && await this._userManager.CheckPasswordAsync(user, model.Password))
            {



                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    return BadRequest("You are not confirmed mail");
                }

                var userRole = await this._userManager.GetRolesAsync(user);
                var authClaims = new List<Claim> {

                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in userRole)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = AuthHelper.GetToken(authClaims, this._configuration);

                return Ok(new
                {
                    user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }




        [HttpPost]
        [Route("regUser")]
        public async Task<IActionResult> RegUser([FromQuery] Register model)
        {
            var userEx = await this._userManager.FindByNameAsync(model.UserName);
            if (userEx != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User in db already");

            User user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var res = await this._userManager.CreateAsync(user, model.Password);
            if (!res.Succeeded)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, res.Errors); 
            }
            this.SetRole(model.UserName, UserRoles.User);
            return Ok();
        }

        [HttpPost]
        [Route("setAdmin")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> SetRole(string username, string role)
        {

            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await _roleManager.RoleExistsAsync(UserRoles.Recorder))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Recorder));
                
                if (!await _roleManager.RoleExistsAsync(UserRoles.Assistant))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Assistant));

                if (!await _roleManager.RoleExistsAsync(UserRoles.Doctor))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                if (await this._roleManager.RoleExistsAsync(role))
                    await this._userManager.AddToRoleAsync(user, role);

                return Ok("Role added!");
            }
            return StatusCode(404);
        }

        [HttpPost]
        [Route("checkAccess")]
        public IActionResult CheckAccess(string role)
        {
            if (HttpContext.User.IsInRole(role))
            {
                return Ok();
            }

            return Unauthorized();
        }

        
    }
}
