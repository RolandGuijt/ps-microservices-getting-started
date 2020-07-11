using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }

        [Required]
        public Guid BasketId { get; set; }

        [Required]
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        [Required]
        public int TicketAmount { get; set; }

        [Required]
        public int Price { get; set; }

        public Basket Basket { get; set; }
    }
}
