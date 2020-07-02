using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Client.Models.Api
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
