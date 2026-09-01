using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<Game> PostGame(Game addGame)
        {
            addGame.Id = Guid.NewGuid();
            GameList.Add(addGame);
            return GameList;
        }

        [HttpDelete]
        [Route("games/{Id}")]
        public IEnumerable<Game> DeleteGame(Guid Id)
        {
            Game foundGame = GameList.SingleOrDefault(x => x.Id == Id);
            if (foundGame != null)
                GameList.Remove(foundGame);
            return GameList;
        }
    }
}
