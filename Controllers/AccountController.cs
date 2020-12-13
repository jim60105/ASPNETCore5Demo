using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Demo.Models;
using static ASPNETCore5Demo.Models.Login;
using ASPNETCore5Demo.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCore5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly JwtHelpers jwt;
        public AccountController(JwtHelpers jwt, ILogger<AccountController> logger)
        {
            this.jwt = jwt;
            this.logger = logger;
        }

        [HttpPost("~/login")]
        public ActionResult<LoginResult> Login(LoginModel model)
        {
            if (ValidUsers(model))
            {
                return new LoginResult()
                {
                    Token = jwt.GenerateToken(model.UserName, 10)
                };
            }
            return BadRequest();
        }

        private bool ValidUsers(LoginModel model)
        {
            return true;
        }
    }
}