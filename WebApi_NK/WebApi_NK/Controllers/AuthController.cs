using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi_NK.DTOs.Auth;

namespace WebApi_NK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDto>> Login([FromBody] LoginRequest request)
        {
            if (request is not { Login: "Admin", Password: "pass123" })
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,"admin"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,"admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super secret key"));

            var signingCredentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(

                    issuer: "https://localhost:5033",
                    audience: "https://localhost:5033",
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials:signingCredentials,
                    claims:claims
                );

            
            var tokenValue=new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthTokenDto
            {
                Token = tokenValue
            };

        }
    }
}
