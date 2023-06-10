using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Repository.Repositories
{
    
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly IMapper _mapper;
     
        public BasketRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            
        }

        public async Task<List<GameDisplayResponse>> GetUserBasket(int userId)
        {
            List<Game> userGames = new();
            var basket = await _context.Baskets.Where(b => b.Id == userId)
                .Include(b => b.Games).FirstOrDefaultAsync();
            if (basket.Games != null)
            {
                basket.Games.ForEach(ug => userGames.Add(ug));
            }
            
            return _mapper.Map<List<GameDisplayResponse>>(userGames);

        }

        public async Task AddToUserBasket(int userId, int gameId)
        {
            var basket = await _context.Baskets.Where(b => b.Id == userId).Include(b=> b.Games).FirstOrDefaultAsync();
            var game = await _context.Games.Where(g => g.Id == gameId).FirstOrDefaultAsync();
            basket.Games.Add(game);

        }

        public async Task RemoveFromUserBasket(int userId, int gameId)
        {
            var basket = await _context.Baskets.Where(b => b.Id == userId).Include(b=>b.Games).FirstOrDefaultAsync();
            var game = await _context.Games.Where(g => g.Id == gameId).FirstOrDefaultAsync();
            basket.Games.Remove(game);
        }

        public async Task BuyAllFromBasket(int userId)
        {
	        var basket = await _context.Baskets.Where(b => b.Id == userId).Include(b => b.Games).FirstOrDefaultAsync();
            foreach (var game in basket.Games)
            {
                await _context.UserGames.AddAsync(new()
                {
                    GameId = game.Id,
                    UserId = userId
                });
            }
            basket.Games.Clear();
        }

        public async Task<bool> IsBasketEmpty(int userId)
        {
	        
			var basket = await _context.Baskets.Where(b => b.Id == userId).Include(b => b.Games).FirstOrDefaultAsync();
			return basket.Games.Count == 0;
        }
    }
}
