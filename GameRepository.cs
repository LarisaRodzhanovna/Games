using Microsoft.EntityFrameworkCore;

namespace Games
{
    public class GameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<List<Game>> GetGamesByGenreAsync(string genre)
        {
            return await _context.Games.Where(g => g.Genres.Contains(genre)).ToListAsync();
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> UpdateGameAsync(int id, Game game)
        {
            var existingGame = await _context.Games.FindAsync(id);

            if (existingGame == null)
            {
                return null;
            }

            existingGame.Name = game.Name;
            existingGame.Developer = game.Developer;
            existingGame.Genres = game.Genres;

            await _context.SaveChangesAsync();

            return existingGame;
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
