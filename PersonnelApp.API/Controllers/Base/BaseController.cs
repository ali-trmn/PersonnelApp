using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PersonnelApp.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("GlobalCors")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
      
    }
}
