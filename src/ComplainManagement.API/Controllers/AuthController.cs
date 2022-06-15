using ComplainManagement.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.Controllers
{
    
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        [ApiVersion("1.1")]
        [HttpPost("api/auth/register")]
        
        public async Task<IActionResult> Registration([FromBody] RegisterVm registerVm)
        {

            return null;
        }
    }
}
