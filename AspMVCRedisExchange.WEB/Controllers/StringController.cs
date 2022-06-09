using AspMVCRedisExchange.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AspMVCRedisExchange.WEB.Controllers
{
    public class StringController : Controller
    {
        private readonly RedisService _redisService;

        private readonly IDatabase _database;

        public StringController(RedisService redisService)
        {
            _redisService = redisService;

            _redisService.Connect();

            _database = _redisService.GetDatabase(0);
        }

        public IActionResult Index()
        {
            _database.StringSet("name", "fth");

            _database.StringSet("age", "10");

            return View();
        }


        public IActionResult ShowString()
        {
            _database.StringIncrement("age");

            ViewBag.Name = _database.StringGet("age");


            return View();
        }

    }
}
