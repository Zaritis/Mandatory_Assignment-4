using Assignment_4.FootballPlayersManager;
using Assignment1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager.FootballPlayersManager _manager = new FootballPlayersManager.FootballPlayersManager();
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<FootBallPlayer> GetAll()
        {
            List<FootBallPlayer> players = _manager.GetAll();
            if(players == null) return NotFound();
            else return Ok(players);
            //returns an action result as i wish to get a statuscode for whether or not this works. I expect either to get status code 200 or 404 if something fails with the list of getting all items from _manager
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootBallPlayer> GetById(int id)
        {
            FootBallPlayer player = _manager.GetFootBallPlayerById(id);
            if(player == null) return NotFound();
            else return Ok(player);
            //Same as above but this time I have defined {id} as something to be required to use this method in the httpGet method
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<FootBallPlayer> Post([FromBody] FootBallPlayer value)
        {
            FootBallPlayer player = _manager.Add(value);
            _manager.GetFootBallPlayerById(value.Id);
            if (player == null) return NotFound();
            if (player != null) return Created("FootballPlayer/api", "Created FootballPlayer!");
            return _manager.Add(value);
            //With the post method i declare httpPost, and as parameter i use [FromBody] and take an object footballplayer, and i add this player to the list of players in manager
            //I then check if player is null or not, and define error codes to use depending on outcome. I expect either code 200, 201(Created) or 404 if player is not found
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        [HttpPut]
        public ActionResult<FootBallPlayer> Put(int id, [FromBody]FootBallPlayer value)
        {
            FootBallPlayer player = _manager.Update(id, value);
            if (player == null) return NotFound("Can't find player!" + id + value);
            if (player.Name.Length < 2) return BadRequest();
            else return Ok(value);
            //Here I define the method as a httpPut method, and do my check for if the object is null, then I also use an if statement to check if players name is long enough
            //If players' name is not longer than 2 characters, status code 400(Bad Request) as name has to be longer than 2 characters
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public ActionResult<FootBallPlayer> Delete(int id)
        {
            FootBallPlayer player = _manager.Delete(id);
            if (player == null) return NotFound("Cannot delete a player does not exist" + id);
            if(player != null) return Ok(player);
            return _manager.Delete(id);
            //Here I declare httpDelete to use this method, of deleting a player based on their id, if no such player exists, error 404 not found, if it works, code 200ok as i have not created anything and an ok is enough for me
        }
    }
}
