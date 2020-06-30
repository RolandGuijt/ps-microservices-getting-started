using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GloboTicket.Services.ShoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {  
        [HttpGet("{basketId}")]
        public ActionResult<Basket> Get(Guid basketId)
        {
            return new Basket();
        }
         
        [HttpPost]
        public async void Post(BasketForCreation basketForCreation)
        {
        }         
    }
}
