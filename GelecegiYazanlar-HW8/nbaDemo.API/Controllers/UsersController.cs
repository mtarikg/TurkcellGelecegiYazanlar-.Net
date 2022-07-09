using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nbaDemo.API.Filters;
using nbaDemo.API.Models;
using nbaDemo.Business.Abstracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [TypeFilter(typeof(LogInfo<UsersController>))]
        public IActionResult Login(UserLoginModel model)
        {
            var user = userService.ValidateUser(model.Username, model.Password);

            if (user != null)
            {
                // Claim info
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                };

                // Producing secret key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a very secret key."));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Defining the features of the token
                var token = new JwtSecurityToken(
                    issuer: "nba",
                    audience: "nba.com",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credential
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest(new { message = "Invalid username or password." });
        }
    }
}
