using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Entities
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
