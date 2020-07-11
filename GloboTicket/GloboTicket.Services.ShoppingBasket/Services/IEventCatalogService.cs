using System;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Entities;

namespace GloboTicket.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}