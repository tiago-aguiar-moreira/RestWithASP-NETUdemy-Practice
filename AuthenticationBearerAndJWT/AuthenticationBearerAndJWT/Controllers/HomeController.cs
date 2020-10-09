using AuthenticationBearerAndJWT.Model;
using AuthenticationBearerAndJWT.Repository;
using AuthenticationBearerAndJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationBearerAndJWT.Controllers
{
    /* tutorial: https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt */

    [Route("api/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Authenticate([FromBody]User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            //user.Password = "";

            // Retorna os dados
            return new OkObjectResult(new
            {
                user = new
                {
                    user.Id,
                    user.Username,
                    Password = string.Empty,
                    user.Role
                },
                token = token
            });
        }
    }
}