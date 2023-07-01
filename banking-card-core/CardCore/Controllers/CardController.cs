using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedisPackage.Interfaces;

namespace CardCore.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("[Controller]")]
    public class CardController: ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IRedisClient _redis;
        public CardController(Serilog.ILogger logger, IRedisClient redis)
        {
            _logger = logger;
            _redis = redis;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCards(){
            _logger.Information("Get here");
            return Ok("List card");
        }
        [HttpPost]
        public async ValueTask<IActionResult> SetKey([FromQuery] string key, [FromQuery] string value)
        {
            _logger.Information($"Set key {key} - value {value}");
            if (await _redis.Set<string>(key, value)) return Ok();
            return BadRequest("Set key error");
        }
    }
}