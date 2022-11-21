using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelApp.API.Controllers.Base;
using PersonnelApp.Model.UserDto;
using PersonnelApp.Service;

namespace PersonnelApp.API.Controllers
{
  
    public class UserController : BaseController
    {
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
