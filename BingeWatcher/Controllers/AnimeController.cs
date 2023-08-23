using BingeWatcher.Data;
using Microsoft.AspNetCore.Mvc;


namespace BingeWatcher.Controllers
{
    public class AnimeController : Controller
    {
        public readonly AppDbContext _db;
        public AnimeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> SyncWithAPI()
        {
            HttpClient client = new HttpClient();
            const string URL = "https://api.myanimelist.net/v2";
            const string query = "/anime/ranking?ranking_type=all";
            client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", "123");
            var response = await client.GetAsync((URL+query));
            return RedirectToAction("index");

        }


        public IActionResult Index()
        {

            return View();
        }
    }
}
