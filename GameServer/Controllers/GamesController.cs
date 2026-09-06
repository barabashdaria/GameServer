using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameServer.Requests;

namespace GameServer.Controllers
{
    [Route("api")]
    public class GamesController : ControllerBase
    {
        static List<Game> GameList = new List<Game>() { new Game { Name = "Tomb Raider" } };

        public GamesController()
        {
            //GameList.Add(new Game { Name = "Tomb Raider" });
        }

        [HttpGet]
        [Route("games")]
        public IEnumerable<Game> GetGames()
        {
            return GameList;
        }

        [HttpPost]
        [Route("games")]
        public IEnumerable<Game> PostGame(Game addGameParametr)
        {
            addGameParametr.Id = Guid.NewGuid();
            GameList.Add(addGameParametr);
            return GameList;
        }

        [HttpDelete]
        [Route("games/{Id}")]
        public IEnumerable<Game> DeleteGame(Guid Id)
        {
            Game foundGame = GameList.SingleOrDefault(game => game.Id == Id);
            if (foundGame != null)
                GameList.Remove(foundGame);
            return GameList;
        }

        [HttpPut]
        [Route("games/{Id}")]
        public ActionResult PutGame(PutGameRequest gameParametr, Guid Id)
        {
            Game foundGame = GameList.SingleOrDefault(x => x.Id == Id);
            if (foundGame == null)
            {
                return NotFound();
            }
            else
            {
                foundGame.Ganre = gameParametr.Ganre;
                foundGame.Name = gameParametr.Name;
                foundGame.Year = gameParametr.Year;
                foundGame.Score = gameParametr.Score;
                return Ok(foundGame);
            }
        }
    }
}
