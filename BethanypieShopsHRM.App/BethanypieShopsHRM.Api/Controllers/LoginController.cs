using BethanypieShopsHRM.Api.Repository;

using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BethanypieShopsHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public IConfiguration _configuration;
        public LoginController(IConfiguration config, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _configuration = config;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login.email != null && login.password != null)
            {
                var user = await _userRepository.AuthenticateUser(login.email, login.password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(1),
                        signingCredentials: signIn);

                    return Ok(new LoginResult
                    {
                        Name = user.email,
                        UserName = user.email,
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Message = "Logged in"
                    });
                }
                else
                {
                    return Ok(
                         new LoginResult
                         {
                             Message = "Invalid Username or Password",
                             Token = "",
                         });
                }
            }
            else
            {
                return Ok(
                         new LoginResult
                         {
                             Message = "Invalid Username or Password",
                             Token = "",
                         });
            }
        }

    }   
    
}
