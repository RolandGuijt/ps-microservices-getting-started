using System;
using GloboTicket.Client.Models;
using Microsoft.AspNetCore.Http;

namespace GloboTicket.Client.Extensions
{
    public static  class RequestCookieCollection
    {
        public static Guid GetCurrentBasketId(this IRequestCookieCollection cookies, Settings settings)
        {
            Guid.TryParse(cookies[settings.BasketIdCookieName], out Guid basketId);
            return basketId;
        }
    }
}
