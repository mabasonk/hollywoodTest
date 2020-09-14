using System.Threading.Tasks;
using AutoMapper;
using HollywoodTest.Domain.IServices;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;
using HollywoodTest.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodTest.Controllers
{
    [Route("/api/eventDetails")]
    [ApiController]
    public class EventDetailsController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IMapper _mapper;

        public EventDetailsController(IEventDetailService eventDetailService, IMapper mapper)
        {
            _eventDetailService = eventDetailService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventDetailResponse), 201)]
        [ProducesResponseType(typeof(EventDetailResponse), 400)]
        public async Task<IActionResult> PostAsync([FromBody] EventDetailResource resource)
        {
            var eventDetails = _mapper.Map<EventDetailResource, EventDetail>(resource);

            var result = await _eventDetailService.AddAsync(eventDetails);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventDetailsResource = _mapper.Map<EventDetail, EventDetailResource>(result.Resource);
            return Ok(eventDetailsResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EventDetailResponse), 201)]
        [ProducesResponseType(typeof(EventDetailResponse), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EventDetailResource resource)
        {
            var eventDetails = _mapper.Map<EventDetailResource, EventDetail>(resource);

            var result = await _eventDetailService.Update(id, eventDetails);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventDetailsResource = _mapper.Map<EventDetail, EventDetailResource>(result.Resource);
            return Ok(eventDetailsResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventDetailResponse), 201)]
        [ProducesResponseType(typeof(EventDetailResponse), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventDetailService.Delete(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventDetailsResource = _mapper.Map<EventDetail, EventDetailResource>(result.Resource);
            return Ok(eventDetailsResource);
        }
    }
}
