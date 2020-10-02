using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentationWithSwagger.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocumentationWithSwagger.Controllers
{
    [Produces("application/json", "application/xml")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IList<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Zack Snyder",
                Birth = new DateTime(1992, 8, 6),
                PhoneNumber = "959188484"
            },
            new User
            {
                Id = 2,
                Name = "Antonio Bandeiras",
                Birth = new DateTime(1989, 1, 4),
                PhoneNumber = "945556466"
            },
            new User
            {
                Id = 3,
                Name = "Emily Blunt",
                Birth = new DateTime(1975, 3, 21),
                PhoneNumber = "955897748"
            }
        };
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get() => new OkObjectResult(Users);
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(int id) => new OkObjectResult(Users.FirstOrDefault(f => f.Id == id));

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Post([FromBody]User user)
        {
            if(user == null)
                return BadRequest();
                
            user.Id = Users.Max(f => f.Id) + 1;

            Users.Add(user);

            return new OkObjectResult(user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Put([FromBody]User user)
        {
            if(user == null)
                return BadRequest();
                
            var findUser = Users.FirstOrDefault(f => f.Id == user.Id);

            findUser.Birth = user.Birth;
            findUser.Name = user.Name;
            findUser.PhoneNumber = user.PhoneNumber;

            return new OkObjectResult(user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return BadRequest();
                
            Users = Users.Where(u => u.Id != id).ToList();

            return NoContent();
        }
    }
}
