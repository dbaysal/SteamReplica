using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NLayer.Repository.Repositories
{
    public class UserGameRepository : GenericRepository<UserGame>, IUserGameRepository
    {
        public UserGameRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> HasGame(int userId, int gameId)
        {
	       
	        var userGames = await _context.UserGames.Where(ug => ug.GameId == gameId && ug.UserId == userId).FirstOrDefaultAsync();
            return userGames != null;
        }
    }
}
