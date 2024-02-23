using AutoMapper;
using Company.API.DTOs.Users;
using Company.API.Filters;
using Company.BLL.Services;
using Company.Models.Entities.Users;
using Company.Models.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers.Users.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        public readonly IUserService _userService;
        private readonly ILogger<UsersController> logger;
        private readonly IMapper mapper;

        public UsersController(IUserService service,ILogger<UsersController> logger, IMapper mapper ) {
            _userService = service;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ServiceFilter(typeof(LoggerFilter))]
        public async Task<ActionResult<List<User>>> ActionResult()
        {
            try
            {
                
                logger.LogInformation("GetUsers");
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<List<User>>> ActionResultById( int Id)
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public ActionResult Post(UserDTO userCration)
        {
            try
            {
                var user = mapper.Map<User>(userCration);
                _userService.CreateUser(user);
                return Ok(user);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Put(User user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int userId)
        {
            try
            {
                _userService.DeactivateUser(userId);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
