using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

		public BasketService(IGenericRepository<Basket> repository, IUnitOfWork unitOfWork, IBasketRepository basketRepository, IMapper mapper) : base(repository, unitOfWork)
        {
	        _unitOfWork = unitOfWork;
	        _basketRepository = basketRepository;
            _mapper = mapper;
        }


        public async Task<List<GameDisplayResponse>> GetUserBasket(int userId)

        {
            return await _basketRepository.GetUserBasket(userId);
        }

        public async Task AddToUserBasket(int userId, int gameId)
        {
            await _basketRepository.AddToUserBasket(userId, gameId);
            await _unitOfWork.CommitAsync();

        }


        public async Task RemoveFromUserBasket(int userId, int gameId)
        {
            await _basketRepository.RemoveFromUserBasket(userId, gameId);
            await _unitOfWork.CommitAsync();
        }


        public async Task BuyAllFromBasket(int userId)
        {
            await _basketRepository.BuyAllFromBasket(userId);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsBasketEmpty(int userId)
        {
	        return await _basketRepository.IsBasketEmpty(userId);
        }
    }
}
