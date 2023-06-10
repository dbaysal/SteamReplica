using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Service.Services;

namespace SteamReplica.UtilityClasses
{
	public class BuilderConfigurator
	{
		public static void AddScopes(WebApplicationBuilder builder)
		{
			
			builder.Services.AddScoped<IBasketService, BasketService>();
			builder.Services.AddScoped<IBasketRepository, BasketRepository>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IGameService, GameService>();
			builder.Services.AddScoped<IGameRepository, GameRepository>();
			builder.Services.AddScoped<IUserGameService, UserGameService>();
			builder.Services.AddScoped<IUserGameRepository, UserGameRepository>();

		}

		public static void SqlConnection(WebApplicationBuilder builder, string connectionString)
		{
			builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
		}

		public static void AddAuthentication(WebApplicationBuilder builder)
		{
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(option =>
				{
					option.LoginPath = "/User/Login";
					option.ReturnUrlParameter = "returnURL";

				});
		}
	}
}
