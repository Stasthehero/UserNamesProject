using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserNamesProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNamesController : ControllerBase
    {
        private static readonly string[] names = new[]
        {
            "Вася", "Коля", "Саня", "Илья"
        };

        private readonly ILogger<UserNamesController> _logger;

        public UserNamesController(ILogger<UserNamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserNames")]
        public IEnumerable<UserNames> Get()
        {
            return Enumerable.Range(1, 4).Select(index => new UserNames()
                {
                    name = names[Random.Shared.Next(names.Length)]
                })
                .ToArray();
        }
    }
}
