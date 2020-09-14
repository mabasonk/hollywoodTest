using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Domain.Models;
using HollywoodTest.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodTest.Controllers
{
    [Route("/api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EventResource> GetAllEventsAsync()
        {
            var events = _eventService.List();

            var resource =  _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return resource;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] EventResource resource)
        {
            var eventToSave = _mapper.Map<EventResource, Event>(resource);

            var result = await _eventService.AddAsync(eventToSave);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EventResource resource)
        {
            var eventToUpdate = _mapper.Map<EventResource, Event>(resource);

            var result = await _eventService.Update(id, eventToUpdate);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventService.Delete(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }
    }
}
