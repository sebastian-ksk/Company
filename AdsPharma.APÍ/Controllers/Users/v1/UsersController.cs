using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers.Users.v1
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpGet(Name = "GetUsers")]
        public ActionResult ActionResult()
        {
            return Ok();
        }

    }
}
