using Microsoft.AspNetCore.Mvc;

namespace Games
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly GameRepository _repository;

        public GamesController(GameRepository repository)
        {
            _repository = repository;
        }

        // GET: api/games
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAllGames()
        {
            var games = await _repository.GetAllGamesAsync();
            return Ok(games);
        }

        // GET: api/games/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _repository.GetGameByIdAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // GET: api/games/genres/{genre}
        [HttpGet("genres/{genre}")]
        public async Task<ActionResult<List<Game>>> GetGamesByGenre(string genre)
        {
            var games = await _repository.GetGamesByGenreAsync(genre);
            return Ok(games);
        }

        // POST: api/games
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            var createdGame = await _repository.CreateGameAsync(game);
            return CreatedAtAction(nameof(GetGameById), new { id = createdGame.Id }, createdGame);
        }

        // PUT: api/games/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, Game game)
        {
            var updatedGame = await _repository.UpdateGameAsync(id, game);

            if (updatedGame == null)
            {
                return NotFound();
            }

            return Ok(updatedGame);
        }

        // DELETE: api/games/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGame(int id)
        {
            var result = await _repository.DeleteGameAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
