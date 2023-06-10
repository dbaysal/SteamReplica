using NLayer.Core.Models;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Repositories;
using NLayer.Core.RequestDTOs;
using NLayer.Core.ResponseDTOs;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
        }



        public async Task<UserLoginResponse> Login(UserLoginRequest loginRequest)
        {
            return await _userRepository.Login(loginRequest);
        }

        
    }
}
