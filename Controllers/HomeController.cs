using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Video_Game_Library.Data;
using Video_Game_Library.Models;

namespace Video_Game_Library.Controllers
{
    public class HomeController : Controller
    {
        private VideoGameDBDAL GameRepo;

        public HomeController(VideoGameDBContext context) : base()
        {
            GameRepo = new VideoGameDBDAL(context);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }
        public IActionResult Library()
        {
            ViewData["Title"] = "Library";
            return View(GameRepo.GetCollection());
        }

        [HttpPost]
        public IActionResult Borrow(string name,DateTime date, int i)
        {
            Game g = GameRepo.GetCollection().FirstOrDefault(e => e.Index == i);
            g.LoanedTo = name;
            g.LoanDate = date;
            return View("Library", GameRepo.GetCollection());
        }

        [HttpPost]
        public IActionResult Return(int i)
        {
            Game g = GameRepo.GetCollection().FirstOrDefault(e => e.Index == i);
            g.LoanedTo = null;
            g.LoanDate = DateTime.MinValue;
            return View("Library", GameRepo.GetCollection());
        }
        [HttpPost]
        public IActionResult Search(string key)
        {
            return View("Library", GameRepo.SearchForGames(key));
        }
        [HttpPost]
        public IActionResult Filter(string Genre, string Rating, string Platform)
        {
            return View("Library", GameRepo.FilterCollection(Genre, Platform, Rating));

        }


        [HttpGet]
        public IActionResult Add()
        {
            return View("AddGame");
        }
        [HttpPost]
        public IActionResult Add(Game game)
        {
            if (ModelState.IsValid)
            {
            GameRepo.AddGame(game);
            return View("Library", GameRepo.GetCollection());
            }
            else
            {
                return View("AddGame");
            }




            //GameRepo.AddGame(new Game { Title = title, Platform = platform, Genre = genre, Rating = rating, ReleaseYear = releaseYear, Image = imageUrl });

        }
        [HttpPost]
        public IActionResult Remove(int Index)
        {
            GameRepo.DeleteGame(Index);
            return View("Library", GameRepo.GetCollection());
        }
        [HttpGet]
        public IActionResult Edit(int Index)
        {
            Game g = GameRepo.GetGameByID(Index);
            GameRepo.DeleteGame(Index);
            return View("Edit", g);
        }
        [HttpPost]
        public IActionResult Edit(Game g)
        {
            GameRepo.EditGame(g);
            return View("Library", GameRepo.GetCollection());
        }
    }
}
