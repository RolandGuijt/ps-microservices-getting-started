using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GloboTicket.Services.ShoppingBasket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BasketLine> Get()
        {
            return new List<BasketLine>();
        }

        [HttpGet("{basketLineId}")]
        public BasketLine Get([FromQuery] Guid basketLineId)
        {
            return new BasketLine();
        }

        [HttpPost]
        public void Post([FromBody] BasketLineForCreation basketLineForCreation)
        {
        } 

        [HttpPut("{basketLineId}")]
        public void Put([FromQuery] Guid basketLineId, 
            [FromBody] BasketLineForUpdate basketLineForUpdate)
        {
        } 

        [HttpDelete("{basketLineId}")]
        public void Delete(Guid basketLineId)
        {
        }
    }
}
