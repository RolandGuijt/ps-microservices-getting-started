using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Client.Models.Api
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
