using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;

namespace NLayer.Core.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        public Task<List<GameDisplayResponse>> GetUserBasket(int userId);
        public Task AddToUserBasket(int userId, int gameId);
        public Task RemoveFromUserBasket(int userId, int gameId);
        public Task BuyAllFromBasket(int userId);
        public Task<bool> IsBasketEmpty(int userId);
	}
}
