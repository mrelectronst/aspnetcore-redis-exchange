using AspMVCRedisExchange.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AspMVCRedisExchange.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly RedisService _redisService;

        internal readonly IDatabase _database;

        public BaseController(RedisService redisService)
        {
            _redisService = redisService;

            _redisService.Connect();

            _database = _redisService.GetDatabase(0);
        }
    }
}
