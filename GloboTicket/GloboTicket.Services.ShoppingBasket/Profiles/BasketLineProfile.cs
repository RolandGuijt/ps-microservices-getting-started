using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Profiles
{
    public class BasketLineProfile : Profile
    {
        public BasketLineProfile()
        {
            CreateMap<Models.BasketLineForCreation, Entities.BasketLine>();
            CreateMap<Models.BasketLineForUpdate, Entities.BasketLine>();
            CreateMap<Entities.BasketLine, Models.BasketLine>().ReverseMap();

        }
    }
}
