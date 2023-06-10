using NLayer.Core.Models;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Repositories;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class GameService : Service<Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGenericRepository<Game> repository, IUnitOfWork unitOfWork, IGameRepository gameRepository) : base(repository, unitOfWork)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameDisplayResponse>> GetAllGameDisplayInformation()
        {
            return await _gameRepository.GetAllGameDisplayInformation();
        }

        public async Task<List<GameDisplayResponse>> GetGenreGameDisplayInformation(int genreId)
        {
	        return await _gameRepository.GetGenreGameDisplayInformation(genreId);
        }
    }
}
