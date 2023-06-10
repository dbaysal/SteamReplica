using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.Services;
using SteamReplica.Models;

namespace SteamReplica.Controllers
{
	[Authorize]
	public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IService<Genre> _genreService;
        

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int genreId)
        {
            var sid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                .Select(c => c.Value).SingleOrDefault());
            ViewBag.isCartEmpty = await _basketService.IsBasketEmpty(sid);


            var basketContent = await _basketService.GetUserBasket(sid);

            return View(basketContent);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int gameId)
        {
	        var sid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid)
		        .Select(c => c.Value).SingleOrDefault());

			await _basketService.AddToUserBasket(sid, gameId);

	        return Redirect("/Basket/Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int gameId)
        {
	        var sid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid)
		        .Select(c => c.Value).SingleOrDefault());

	        await _basketService.RemoveFromUserBasket(sid, gameId);

	        return Redirect("/Basket/Index");
        }
        [HttpGet]
        public async Task<IActionResult> BuyAll()
        {
	        var sid = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid)
		        .Select(c => c.Value).SingleOrDefault());

	        await _basketService.BuyAllFromBasket(sid);

	        return Redirect("/Basket/Index");
        }

	}
}
