using System;
using Microsoft.AspNetCore.Mvc;

namespace OrderPresentationApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController (IConfiguration configuration, IAuthService authService) {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login (LoginUsuarioViewModel usuario) { 
            
        }
    }
}
