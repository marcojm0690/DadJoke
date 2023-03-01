using DadJokeAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DadJokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeCountController : ControllerBase
    {
        private ConnectAPIService connectAPIService;

        private readonly ILogger<JokeCountController> _logger;
        private readonly IConfiguration _config;
        public JokeCountController(ILogger<JokeCountController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            connectAPIService = new ConnectAPIService(_config);
        }

        [HttpGet(Name = "GetCount")]
        public int GetCount(int id)
        {

            var dadjoke = connectAPIService.ReturnCount();

            return dadjoke.Result;
        }
    }
}
