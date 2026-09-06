using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameServer.Requests;
using GameServer.Helpers;

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
        public ActionResult PostGame(PostGameRequest addGameParametr)
        {
            string smallName = addGameParametr.Name.ToLower();

            Game[] foundgames = GameList.Where(game => game.Name.ToLower() == smallName).ToArray();

            if (foundgames == null || foundgames.Length == 0 ) {
                Game game = new Game();
                game.Name = addGameParametr.Name;
                try
                {
                    game.Ganre = StringHelpers.StringToGanre(addGameParametr.Ganre);
                }
                catch (Exception)
                {
                    return BadRequest("Not supported ganre");
                }
                game.Year = addGameParametr.Year;
                game.Score = addGameParametr.Score;
                game.Id = Guid.NewGuid();
                GameList.Add(game);
                return Ok(GameList);
            }
            else {
                return Conflict();
            }
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
                try
                {
                    foundGame.Ganre = StringHelpers.StringToGanre(gameParametr.Ganre);
                }
                catch (Exception)
                {
                    return BadRequest("Not supported ganre");
                }
                foundGame.Name = gameParametr.Name;
                foundGame.Year = gameParametr.Year;
                foundGame.Score = gameParametr.Score;
                return Ok(foundGame);
            }
        }
    }
}
