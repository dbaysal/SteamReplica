using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IGameService : IService<Game>
    {
        public Task<List<GameDisplayResponse>> GetAllGameDisplayInformation();
        public Task<List<GameDisplayResponse>> GetGenreGameDisplayInformation(int genreId);
	}
}
