using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using datingapp.api.Data;
using datingapp.api.Dtos;
using datingapp.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace datingapp.api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _Repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository Repo,IConfiguration config)
        {
            _Repo = Repo;
            _config = config;
        }
[HttpPost("Register")]
public async Task<IActionResult>Register(userToRegisterDto UsertoRegisterDto)
{
    UsertoRegisterDto.UserName=UsertoRegisterDto.UserName.ToLower();
    if( await _Repo.UserExist(UsertoRegisterDto.UserName))
    return BadRequest("User Already Exist");
    var userTocreate =new user
    {
userName=UsertoRegisterDto.UserName
    };
   await _Repo.Register(userTocreate,UsertoRegisterDto.Password);
   return StatusCode(201);

}

[HttpPost("Login")]
public async Task<IActionResult> login(UserForLoginDto userForloginDto)
{
    var userFromRepo=await _Repo.login(userForloginDto.UserName.ToLower(),userForloginDto.Password);
    if(userFromRepo==null)
    return Unauthorized();
var claims = new[]
{
new Claim(ClaimTypes.NameIdentifier,userFromRepo.id.ToString()),
new Claim(ClaimTypes.Name,userFromRepo.userName)
};
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

var tokenDescropter= new SecurityTokenDescriptor
{
    Subject=new ClaimsIdentity(claims),
    Expires=DateTime.Now.AddDays(1),
    SigningCredentials=cred
};
var tokenhandler = new JwtSecurityTokenHandler();
var token =tokenhandler.CreateToken(tokenDescropter);
return Ok(new {
                token = tokenhandler.WriteToken(token)
            });
}




    }

}