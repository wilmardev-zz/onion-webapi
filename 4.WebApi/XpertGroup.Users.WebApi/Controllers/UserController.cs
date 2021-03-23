using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XpertGroup.Users.Application.Interfaces;

namespace XpertGroup.Users.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication userApplication;

        public UserController(IUserApplication userApplication)
        {
            this.userApplication = userApplication;
        }

        [HttpGet, Route("user/{userName}")]
        public async Task<IActionResult> Get([FromRoute] string userName)
        {
            var response = await this.userApplication.Get(userName);
            if (!response.Success)
                return StatusCode(500);
            return Ok(response);
        }
    }
}
