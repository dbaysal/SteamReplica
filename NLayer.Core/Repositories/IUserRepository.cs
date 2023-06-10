using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.RequestDTOs;

namespace NLayer.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<UserLoginResponse> Login(UserLoginRequest loginRequest);
    }
}
