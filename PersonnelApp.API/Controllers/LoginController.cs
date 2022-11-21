using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PersonnelApp.API.Controllers.Base;
using PersonnelApp.Model.Shared;
using PersonnelApp.Model.UserDto;
using PersonnelApp.Service;
using PersonnelApp.Service.Security;

namespace PersonnelApp.API.Controllers
{



    public class LoginController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Result<LoginUserResult>>> Login(LoginUserDto loginUserDto)
        {
            try
            {
                UserManager userManager = new();
                var dto = userManager.LoginCheck(loginUserDto);
                var token = JwtTokenGenerator.GenerateToken(dto);
                LoginUserResult result = new()
                {
                    Token = token,
                    Role=dto.Role,
                    Username=dto.Username

                };
                return Ok(new Result<LoginUserResult> { Data = result, Success = true });
            }
            catch (Exception ex)
            {

                return BadRequest(new Result<LoginUserResult> {Success = false, Message="Kullanıcı adı şifre hatalı." });
            }
        }

    }
}
