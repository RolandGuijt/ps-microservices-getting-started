using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
