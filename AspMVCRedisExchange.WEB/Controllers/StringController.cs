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
            _database.StringSet("name", "fth krm mvi mry");

            _database.StringSet("age", "10");

            return View();
        }


        public IActionResult ShowString()
        {
            _database.StringIncrement("age", 5);

            _database.StringDecrement("age", 2);

            //var age = _database.StringDecrementAsync("age", 1).Result;

            _database.StringDecrementAsync("age", 5).Wait();

            //ViewBag.Age = _database.StringGet("age");

            ViewBag.Name = _database.StringGetRangeAsync("name", 3, 6).Result;

            ViewBag.NameLenght = _database.StringLengthAsync("name").Result;


            return View();
        }

    }
}
