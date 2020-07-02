using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Services.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllEvents")]
        public async Task<ActionResult<IEnumerable<Models.EventDto>>> Get()
        {
            var result = await _eventRepository.GetEvents(Guid.Empty);
            return Ok(_mapper.Map<List<Models.EventDto>>(result));
        }

        [HttpGet("{categoryId}", Name = "GetEventsByCategory")]
        public async Task<ActionResult<IEnumerable<Models.EventDto>>> Get(Guid categoryId)
        {
            var result = await _eventRepository.GetEvents(categoryId);
            return Ok(_mapper.Map<List<Models.EventDto>>(result));
        }

        [HttpGet("{eventId}", Name = "GetEventByEventId")]
        public async Task<ActionResult<Models.EventDto>> GetById(Guid eventId)
        {
            var result = await _eventRepository.GetEventById(eventId);
            return Ok(_mapper.Map<Models.EventDto>(result));
        }

        [HttpGet("GetEventsByIds/{eventIds}", Name = "GetEventsByEventIds")]
        public async Task<ActionResult<IEnumerable<Models.EventDto>>> GetByIds([FromQuery]Guid[] eventIds)
        {
            var result = await _eventRepository.GetEventsByIds(eventIds);
            return Ok(_mapper.Map<List<Models.EventDto>>(result));
        }
    }
}