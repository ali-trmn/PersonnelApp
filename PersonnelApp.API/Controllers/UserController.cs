using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelApp.Model.UserDto;
using PersonnelApp.Service;

namespace PersonnelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(AddUserInput addUserInput)
        {
            try
            {
                UserManager userManager = new();
                userManager.Insert(addUserInput);
                return Ok("Kayıt işlemi başarılı.");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
