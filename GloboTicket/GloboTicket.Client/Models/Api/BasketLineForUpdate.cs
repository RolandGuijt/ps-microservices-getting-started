using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Client.Models.Api
{
    public class BasketLineForUpdate
    {
        [Required]
        public Guid LineId { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
