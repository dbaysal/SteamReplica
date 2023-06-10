using AutoMapper;
using NLayer.Core;
using NLayer.Core.Models;
using NLayer.Core.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {      
        public MapProfile() 
        {

            CreateMap<Game, GameDisplayResponse>();
            CreateMap<Genre, GenreDisplayResponse>();
            CreateMap<User, UserLoginResponse>();
            
        }
    }
    
}
