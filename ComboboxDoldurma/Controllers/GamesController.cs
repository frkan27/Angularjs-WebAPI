using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComboboxDoldurma.Controllers
{
    public class GamesController : ApiController
    {
        Console[] Consoles = new Console[]
        {
            new Console{Id=1,Name="Xbox",Price=1500},
            new Console{Id=2,Name="Ps4",Price=1250},
            new Console{Id=3,Name="Ps3",Price=800}
        };
        Game[] Games = new Game[]
        {
            new Game{Id=1,Name="GearsOfWar",ConsoleId=1},
            new Game{Id=2,Name="HeartStone",ConsoleId=1},
            new Game{Id=3,Name="Fifa19",ConsoleId=1},
            new Game{Id=4,Name="Mortalkombat",ConsoleId=2},
            new Game{Id=5,Name="Streetfighter",ConsoleId=2},
            new Game{Id=6,Name="Hunter",ConsoleId=2},
            new Game{Id=7,Name="Limbo",ConsoleId=3},
            new Game{Id=8,Name="Bridge",ConsoleId=3},
            new Game{Id=9,Name="Shadow",ConsoleId=3}
        };
        Shop[] Shops = new Shop[]
       {
            new Shop { Id = 1, Name = "Shopto",GameId= 1 },
            new Shop { Id = 2, Name = "Ebay",  GameId=1 },
            new Shop { Id = 3, Name = "Amazon", GameId=2 },
            new Shop { Id = 4, Name = "Argos", GameId=2 },
            new Shop { Id = 5, Name = "Gamespot", GameId=3 },
            new Shop { Id = 6, Name = "Mall", GameId=3 },
            new Shop { Id = 7, Name = "Virgin", GameId=4 },
            new Shop { Id = 8, Name = "GameShop", GameId=5},
            new Shop { Id = 9, Name = "Virtual Shop", GameId=6 },
            new Shop { Id = 10, Name = "GameLand", GameId=7 },
            new Shop { Id = 11, Name = "Sendit", GameId=8 },
            new Shop { Id = 12, Name = "BuyBuy", GameId=9 }
       };
        public IEnumerable<Console> Get()
        {
            return Consoles;
        }
        public IEnumerable<Game> Get(int id)
        {
            return Games.Where(x => x.ConsoleId == id).ToList();
        }

        public IEnumerable<Shop> GetShops(int gameId)
        {
            return Shops.Where(x => x.GameId == gameId).ToList();
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
