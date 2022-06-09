using AspMVCRedisExchange.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspMVCRedisExchange.WEB.Controllers
{
    public class HashSetController : BaseController
    {
        public string listKey = "books";

        public HashSetController(RedisService redisService) : base(redisService)
        {
        }

        public IActionResult Index()
        {
            HashSet<string> bookList = new HashSet<string>();

            if(_database.KeyExists(listKey))
                _database.SetMembers(listKey).ToList().ForEach(x => bookList.Add(x));

            return View(bookList);
        }

        [HttpPost]
        public IActionResult Add(string book)
        {
            if (!_database.KeyExists(listKey))
                _database.KeyExpireAsync(listKey, DateTime.Now.AddMinutes(5)).Wait();

            _database.SetAddAsync(listKey, book).Wait();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string book)
        {
            await _database.SetRemoveAsync(listKey, book);

            return RedirectToAction("Index");
        }
    }
}
