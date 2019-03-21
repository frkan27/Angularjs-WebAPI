using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Combobox.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetConsoles()
        {
            var product = new List<Console>();
            HttpClient client = new HttpClient(); 
            client.BaseAddress = new Uri("http://localhost:33902");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Games");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<List<Console>>(data);

            }
            else
            {

            }
            return Json(product, JsonRequestBehavior.AllowGet);


        }

        public async Task<JsonResult> GetGames(int ConsoleId)
        {
            var games = new List<Game>();
            HttpClient client = new HttpClient();
            client.BaseAddress= new Uri("http://localhost:33902");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Games"+ConsoleId);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                games = JsonConvert.DeserializeObject<List<Game>>(data);

            }
            else
            {

            }
            return Json(games, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> GetShops(int GameId)
        {
            var shops = new List<Shop>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:33902");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Games/GetShops/" + GameId);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                shops = JsonConvert.DeserializeObject<List<Shop>>(data);

            }
            else
            {

            }
            return Json(shops, JsonRequestBehavior.AllowGet);

        }








        public class Console
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public class Game
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal ConsoleId { get; set; }
        }
        public class Shop
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal GameId { get; set; }
        }



    }
}