using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        public Task<List<GameDisplayResponse>> GetAllGameDisplayInformation();
        public Task<List<GameDisplayResponse>> GetGenreGameDisplayInformation(int genreId);
	}
}
