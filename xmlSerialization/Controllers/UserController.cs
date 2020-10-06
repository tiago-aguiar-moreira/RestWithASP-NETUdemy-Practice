using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using xmlSerialization.Model;

namespace xmlSerialization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
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
    }
}