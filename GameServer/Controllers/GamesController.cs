using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameServer.Requests;
using GameServer.Helpers;
using GameServer.Responses;
using GameServer.Business;
using GameServer.Business.Exceptions;

namespace GameServer.Controllers
{
    [Route("api")]
    public class GamesController : ControllerBase
    {
        private GameService GameService = new GameService();

        public GamesController()
        {
            //GameList.Add(new Game { Name = "Tomb Raider" });
        }

        [HttpGet]
        [Route("games")]
        public List<GetGameResponse> GetGames()
        {
            List <GetGameResponse> response = GameService.GetGames();
            return response;
        }

        [HttpPost]
        [Route("games")]
        public ActionResult PostGame(PostGameRequest addGameParametr)
        {
            try
            {
                PostGameResponse result = GameService.CreateGame(addGameParametr);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("games/{Id}")]
        public void DeleteGame(Guid Id)
        {
            GameService.DeleteGame(Id);
        }

        [HttpPut]
        [Route("games/{Id}")]
        public ActionResult PutGame(PutGameRequest gameParametr, Guid Id)
        {
            try
            {
                PutGameResponse result = GameService.UpdateGame(gameParametr, Id);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);  
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
