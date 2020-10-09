using AuthenticationBearerAndJWT.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthenticationBearerAndJWT.Controllers
{
    /* tutorial: https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt */

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;

        public UserController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        public IActionResult Get() => new OkObjectResult(UserRepository.Get());

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id) => new OkObjectResult(UserRepository.Get(id));
    }
}