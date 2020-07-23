using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Web.Models.Api;

namespace GloboTicket.Web.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid);
        Task<Event> GetEvent(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
