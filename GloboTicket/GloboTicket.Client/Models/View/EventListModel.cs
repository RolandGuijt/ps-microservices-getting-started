using System;
using System.Collections.Generic;
using GloboTicket.Grpc;

namespace GloboTicket.Web.Models.View
{
    public class EventListModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
