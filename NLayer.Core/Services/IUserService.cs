using NLayer.Core.Models;
using NLayer.Core.RequestDTOs;
using NLayer.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IUserService : IService<User>
    {
        public Task<UserLoginResponse> Login(UserLoginRequest loginRequest);
    }
}
