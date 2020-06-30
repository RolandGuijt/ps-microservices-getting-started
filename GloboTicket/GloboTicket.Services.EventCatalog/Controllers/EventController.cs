using GloboTicket.Services.EventCatalog.Entities;
using GloboTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.Services.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return Ok( await _eventRepository.GetAllEvents());
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> Get(Guid eventId)
        {
            return Ok(await _eventRepository.GetEventById(eventId));
        }

        [HttpGet("?categoryid={categoryId}")]
        public async Task<ActionResult<Event>> GetByCategoryId(Guid categoryId)
        {
            return Ok(await _eventRepository.GetEventsForCategory(categoryId));
        }
    }
}