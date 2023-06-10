using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.ResponseDTOs;

namespace NLayer.Repository.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly IMapper _mapper;
        public GameRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<GameDisplayResponse>> GetAllGameDisplayInformation()
        {
            var games = await _context.Games.AsNoTracking().AsQueryable().ToListAsync();
            var gameDisplayResponses = _mapper.Map<List<GameDisplayResponse>>(games);
            foreach (var game in gameDisplayResponses)
            {
                var genre = await _context.Genres.FindAsync(game.GenreId);
                game.GenreName = genre.Name;
            }
            return gameDisplayResponses;
        }

        public async Task<List<GameDisplayResponse>> GetGenreGameDisplayInformation(int genreId)
        {
			var games = await _context.Games.Where(g => g.GenreId == genreId).AsNoTracking().AsQueryable().ToListAsync();
			var gameDisplayResponses = _mapper.Map<List<GameDisplayResponse>>(games);
			var genre = await _context.Genres.FindAsync(genreId);
			foreach (var game in gameDisplayResponses)
			{
				game.GenreName = genre.Name;
			}
			return gameDisplayResponses;
		}
    }
}
