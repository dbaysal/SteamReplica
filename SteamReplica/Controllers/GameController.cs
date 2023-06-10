using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.Services;
using SteamReplica.Models;

namespace SteamReplica.Controllers
{
  
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        private readonly IService<Genre> _genreService;
        private readonly IUserGameService _userGameService;
		private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IGameService gameService, IService<Genre> genreService, IMapper mapper, IUserGameService userGameService)
        {
            _logger = logger;
            _gameService = gameService;
            _genreService = genreService;
            _mapper = mapper;
            _userGameService = userGameService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int genreId)
        {
	        var sid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid)
		        .Select(c => c.Value).SingleOrDefault());
	        if (sid != null)
	        {
		        ViewBag.repo = _userGameService;
                ViewBag.userId = sid;
	        }


			var games = genreId != default(int) ? await _gameService.GetGenreGameDisplayInformation(genreId) 
											: await _gameService.GetAllGameDisplayInformation();

            var genres = _mapper.Map<List<GenreDisplayResponse>>(await _genreService.GetAllAsync());
            return View(new GameDisplayModel
            {
                Games = games,
                Genres = genres
                
            });
        }
    }
}
