using DadJokeAPI.Helper;
using DadJokeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DadJokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadJokeController : ControllerBase
    {
        private ConnectAPIService connectAPIService;

        private readonly ILogger<DadJokeController> _logger;
        private readonly IConfiguration _config;
        public DadJokeController(ILogger<DadJokeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            connectAPIService = new ConnectAPIService(_config);
        }

        [HttpGet(Name = "GetDadJoke")]
        public DadJoke Get()
        {
            var dadjoke = connectAPIService.ReturnDadJoke();
            return dadjoke.Result;
        }


    }
}