using System;
using System.Collections.Generic;
using System.Linq;
using ImplementsHATEOAS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImplementsHATEOAS.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
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
        public IActionResult Get() => new OkObjectResult(Users);
        
        [HttpGet("{id}")]
        public IActionResult Get(int id) => new OkObjectResult(Users.FirstOrDefault(f => f.Id == id));

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if(user == null)
                return BadRequest();
                
            user.Id = Users.Max(f => f.Id) + 1;

            Users.Add(user);

            return new OkObjectResult(user);
        }

        [HttpPut]
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
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return BadRequest();
                
            Users = Users.Where(u => u.Id != id).ToList();

            return NoContent();
        }
    }
}