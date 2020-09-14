using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IServices.Communication
{
    public class EventDetailResponse : BaseResponse<EventDetail>
    {
        public EventDetailResponse(EventDetail resource) : base(resource)
        {
        }

        public EventDetailResponse(string message) : base(message)
        {
        }
    }
}