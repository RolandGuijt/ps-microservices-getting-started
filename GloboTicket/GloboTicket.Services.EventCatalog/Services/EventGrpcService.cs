using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Grpc;
using GloboTicket.Services.EventCatalog.Repositories;
using Grpc.Core;

namespace GloboTicket.Services.EventCatalog.Services
{
    public class EventGrpcService : Events.EventsBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EventGrpcService(IEventRepository eventRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override async Task<GetAllEventsResponse> GetAll(GetAllEventsRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var eventEntities = await _eventRepository.GetEvents(Guid.Empty);
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetAllEventsResponse> GetAllByCategoryId(GetAllEventsByCategoryIdRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var eventEntities = await _eventRepository.GetEvents(Guid.Parse(request.CategoryId));
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetByEventIdResponse> GetByEventId(GetByEventIdRequest request, ServerCallContext context)
        {
            var response = new GetByEventIdResponse();
            var entity = await _eventRepository.GetEventById(Guid.Parse(request.EventId));
            response.Event = _mapper.Map<Event>(entity);
            return response;
        }

        public override async Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, ServerCallContext context)
        {
            var response = new GetAllCategoriesResponse();
            var eventEntities = await _categoryRepository.GetAllCategories();
            response.Categories.Add(_mapper.Map<List<Category>>(eventEntities));
            return response;
        }
    }
}
