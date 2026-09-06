
using GameServer.Business.Exceptions;
using GameServer.Helpers;
using GameServer.Requests;
using GameServer.Responses;
using System.Linq.Expressions;

namespace GameServer.Business
{
    public class GameService
    {
        static List<Game> GameList = new List<Game>() { new Game { Name = "Tomb Raider" } };

        public List<GetGameResponse> GetGames()
        {
            List<GetGameResponse> response = new List<GetGameResponse>();
            for (int i = 0; i < GameList.Count; i++)
            {
                GetGameResponse gameResponse = new GetGameResponse();
                Game game = GameList[i];
                gameResponse.Name = game.Name;
                gameResponse.Year = game.Year;
                gameResponse.Score = game.Score;
                gameResponse.Ganre = StringHelpers.GanreToString(game.Ganre);
                gameResponse.Id = game.Id;
                response.Add(gameResponse);
            }
            return response;
        }
        public PostGameResponse CreateGame(PostGameRequest addGameParametr)
        {
            string smallName = addGameParametr.Name.ToLower();

            Game[] foundgames = GameList.Where(game => game.Name.ToLower() == smallName).ToArray();

            if (foundgames == null || foundgames.Length == 0)
            {
                Game game = new Game();
                game.Name = addGameParametr.Name;
                try
                {
                    game.Ganre = StringHelpers.StringToGanre(addGameParametr.Ganre);
                }
                catch (Exception)
                {
                    throw new BadRequestException("Not supported ganre") ;
                }
                game.Year = addGameParametr.Year;
                game.Score = addGameParametr.Score;
                game.Id = Guid.NewGuid();
                GameList.Add(game);
                PostGameResponse response = new PostGameResponse();
                response.Name = game.Name;
                response.Year = game.Year;
                response.Score = game.Score;
                response.Ganre = StringHelpers.GanreToString(game.Ganre);
                response.Id = game.Id;
                return response;
            }
            else
            {
                throw new ConflictException("Conflict");
            }
        }
        public PutGameResponse UpdateGame(PutGameRequest putGameRequest, Guid Id) 
        {
            Game foundGame = GameList.SingleOrDefault(x => x.Id == Id);
            if (foundGame == null)
            {
                throw new NotFoundException("NotFound");
            }
            else
            {
                try
                {
                    foundGame.Ganre = StringHelpers.StringToGanre(putGameRequest.Ganre);
                }
                catch (Exception)
                {
                    throw new BadRequestException("Not supported ganre");
                }
                foundGame.Name = putGameRequest.Name;
                foundGame.Year = putGameRequest.Year;
                foundGame.Score = putGameRequest.Score;
                PutGameResponse response = new PutGameResponse();
                response.Name = foundGame.Name;
                response.Year = foundGame.Year;
                response.Score = foundGame.Score;
                response.Ganre = StringHelpers.GanreToString(foundGame.Ganre);
                response.Id = foundGame.Id;
                return response;
            }
        }
        public void DeleteGame(Guid Id) 
        {
            Game foundGame = GameList.SingleOrDefault(game => game.Id == Id);
            if (foundGame != null)
                GameList.Remove(foundGame);
        }
    }
}
