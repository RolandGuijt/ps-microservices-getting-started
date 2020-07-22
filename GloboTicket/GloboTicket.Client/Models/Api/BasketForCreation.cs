using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Web.Models.Api
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
