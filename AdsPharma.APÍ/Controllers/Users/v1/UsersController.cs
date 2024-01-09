using Company.Models.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers.Users.v1
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<UserEntity>> ActionResult()
        {
            return new List<UserEntity>()
            {
                new UserEntity() { Id = 1, Name = "User 1" },
                new UserEntity() { Id = 2, Name = "User 2" },
            };
        }

    }
}
