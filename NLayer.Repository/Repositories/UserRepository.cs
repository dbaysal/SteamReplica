using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.RequestDTOs;
using NLayer.Core.ResponseDTOs;

namespace NLayer.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest loginRequest)
        {
            return _mapper.Map<UserLoginResponse>(await _context.Users.SingleOrDefaultAsync(u =>
                u.Username == loginRequest.Username && u.Password == loginRequest.Password));
        }
    }
}
