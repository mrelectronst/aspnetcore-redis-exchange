using AspMVCRedisExchange.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspMVCRedisExchange.WEB.Controllers
{
    public class ListController : BaseController
    {
        private string ListKey = "books";

        public ListController(RedisService redisService) : base(redisService)
        {
        }

        public IActionResult Index()
        {
            List<string> bookList = new List<string>();

            if (_database.KeyExists(ListKey))
            {
                _database.ListRange(ListKey).ToList().ForEach(x =>
                {
                    bookList.Add(x.ToString());
                });
            }

            return View(bookList);
        }


        [HttpPost]
        public IActionResult Add(string book)
        {
            _database.ListRightPush(ListKey, book);

            return RedirectToAction("index");
        }


    }
}
