using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")] //auth instead of [controller]
    [ApiController]
    public class Auth : ControllerBase
    {
        private IConfiguration configuration;

        public Auth(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin == null)
                return BadRequest("Invalid login request! Contact the administrator");

            if(userLogin.Username == "Admin" && userLogin.Password == "password1") // This is for testing purposes. Ideally yous get user details from the database
            {
                var secreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"]));
                var signingCredentials = new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256);

                // If working with Roles
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userLogin.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7078",
                    audience: "https://localhost:7078",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = token });
            };

            return Unauthorized();
        }
    }
}
