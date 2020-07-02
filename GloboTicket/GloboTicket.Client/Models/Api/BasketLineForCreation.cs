using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Client.Models.Api
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
