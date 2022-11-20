using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelApp.Model.UserDto;
using PersonnelApp.Service;
using PersonnelApp.Service.Security;

namespace PersonnelApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            try
            {
                UserManager userManager = new();
                var dto = userManager.LoginCheck(loginUserDto);
                var token = JwtTokenGenerator.GenerateToken(dto);
                return Created("", token);
            }
            catch (Exception ex)
            {

                return BadRequest("Kullanıcı adı yada şifre hatalı.");
            }
        }

    }
}
