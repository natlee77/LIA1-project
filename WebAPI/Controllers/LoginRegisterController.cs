using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Model;
using WebAPI.Services;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginRegisterController : ControllerBase
    {
        private readonly LIADbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IDatabaseServices _services;

        public LoginRegisterController(LIADbContext context, IConfiguration configuration, IDatabaseServices services)
        {
            _context = context;
            _configuration = configuration;
            _services = services;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var result = (await _services.CeateUserAsync(model));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLoginModel.Email);
                if (user != null)
                {
                    if (user.ValidatePassword(userLoginModel.Password))
                    {
                        var th = new JwtSecurityTokenHandler();
                        var expiresDate = DateTime.Now.AddHours(1);

                        var td = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[] {
                            new Claim("UserId", user.Id.ToString()),
                            new Claim ("Expires", expiresDate.ToString())
                            }),
                            Expires = expiresDate,
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_configuration.GetSection("SecretKey").Value)),
                                SecurityAlgorithms.HmacSha512Signature
                            )
                        };
                        var _accessToken = th.WriteToken(th.CreateToken(td));

                        return new OkObjectResult(new
                        {
                            AccessToken = _accessToken,
                            Id = user.Id

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
            return new BadRequestObjectResult($"Failed Try(Attempt)");
        }
    }
}
