using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Models;
using NLayer.Core.RequestDTOs;
using NLayer.Core.Services;
using SteamReplica.Models;

namespace SteamReplica.Controllers
{
	public class UserController : Controller
	{
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public IActionResult Index()
        {
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Login(UserLoginRequest userLoginInformation, string? returnURL)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Login(userLoginInformation);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Sid, Convert.ToString(user.Id))
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimPrinciple = new(claimsIdentity);
                   await HttpContext.SignInAsync(claimPrinciple);

                    if (!string.IsNullOrEmpty(returnURL) && Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }


                    return Redirect("/Game/Index");

                }
            }
            
            
            return View();
		}

       
        public IActionResult Login(string? returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Game/Index");
        }
	}
}
