using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Template.API.Application.Interfaces.v1;
using Template.API.Application.Services.v1;
using Template.API.Application.ViewModel.v1;

namespace Template.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/user")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        } 

        [HttpPost]
        [Route("authenticate")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Authenticate(LoginViewModel login)
        {
            try
            {
                var result = await _userService.Authenticate(login);

                if (result == null)
                {
                    throw new Exception("Please try again.");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }
    }

}
