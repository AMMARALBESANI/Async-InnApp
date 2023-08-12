using HotelAppDemo.Model.DTO;
using HotelAppDemo.Model.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelAppDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser userservise;
        public UserController(IUser service)
        {
            userservise = service;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO Data)
        {

            var user = await userservise.Register(Data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));

        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await userservise.Authenticate(loginDto.UserName, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }


        [Authorize(Policy ="create")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDTO>> Profile ()
        {
            return await userservise.GetUser(this.User);
        }

    }
}
