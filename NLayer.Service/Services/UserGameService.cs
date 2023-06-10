using NLayer.Core.Models;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class UserGameService : Service<UserGame>, IUserGameService
    {
        private readonly IUserGameRepository _userGameRepository;
        public UserGameService(IGenericRepository<UserGame> repository, IUnitOfWork unitOfWork, IUserGameRepository userGameRepository) : base(repository, unitOfWork)
        {
	        _userGameRepository = userGameRepository;
        }

        public async Task<bool> HasGame(int userId, int gameId)
        {
	        return await _userGameRepository.HasGame(userId, gameId);
        }
    }
}
