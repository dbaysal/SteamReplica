using NLayer.Core.ResponseDTOs;

namespace SteamReplica.Models
{
    public class GameDisplayModel
    {
        public List<GameDisplayResponse> Games { get; set; }
        public List<GenreDisplayResponse> Genres { get; set; }
    }
}
