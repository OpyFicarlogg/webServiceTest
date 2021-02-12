using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsFirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Jean", "Fred", "John", "Eric", "Henri", "Sam", "Daisy", "X-3b", "Svetlana", "Kenny"
        };

        private static readonly string[] LastNames = new[]
        {
            "Fuchs", "Meyer", "Denzen", "Ranch", "Hander","Mastos", "Puzer", "Kester", "Nachima", "Irochina"
        };

        private static readonly string[] Towns = new[]
        {
            "Thann", "Mulhouse", "Colmar"
        };

        private static readonly string[] Types = new[]
        {
            "M","F", "O"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Name = Names[rng.Next(Names.Length)],
                LastName = LastNames[rng.Next(LastNames.Length)],
                Age = rng.Next(18, 55),
                Type = Types[rng.Next(Types.Length)],
                Town = Towns[rng.Next(Towns.Length)]
            })
            .ToArray();
        }


        [HttpGet("{id}")]
        public User GetOneUser(long id)
        {
            
            var rng = new Random();
            return new User
            {
                Name = Names[rng.Next(Names.Length)],
                LastName = LastNames[rng.Next(LastNames.Length)],
                Age = rng.Next(18, 55),
                Type ="M",
                Town = Towns[rng.Next(Towns.Length)]
            };
        }
    }

    
}
