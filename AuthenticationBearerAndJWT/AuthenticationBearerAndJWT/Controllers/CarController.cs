using AuthenticationBearerAndJWT.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthenticationBearerAndJWT.Controllers
{
    /* tutorial: https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt */

    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Get() => new OkObjectResult(CarRepository.Get());

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize]
        public IActionResult Get(int id) => new OkObjectResult(CarRepository.Get(id));
    }
}