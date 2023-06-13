using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_MahdiTaremi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shop_MahdiTaremi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static  UserLogin user = new UserLogin();

        private readonly IConfiguration _configuration; 
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserLoginDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            return Ok(user); 
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginDto request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong Password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(UserLogin user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            //var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AppSettings:Tokens"));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
