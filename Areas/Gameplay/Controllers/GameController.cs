using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Gameplay.ViewModels;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;

namespace QuizNSwap.Areas.Gameplay.Controllers
{
    [Area("Gameplay")]
    public class GameController : Controller
    {
        private readonly QuizNSwapContext _context;
        public GameController(QuizNSwapContext dbContext) {
            this._context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public dynamic Index([FromBody] EnterGame model)
        {
            Player player = new Player();
            player.Name = model.Name;
            Console.WriteLine(model.Code);

            Game game = this._context.Games.FirstOrDefault(g => g.Code == model.Code);

            if (game == null) {
                return Ok("Game not found");
            }
  
            player.Game = game;

            this._context.Add(player);
            this._context.SaveChanges();

            return Ok("Player added");
        }

        public void Socket() {
            
        }
    }
}
