using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace ASPNETCore5Demo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult err() => Problem();
    }
}
