using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IServices.Communication
{
    public class EventResponse : BaseResponse<Event>
    {
        public EventResponse(Event resource) : base(resource)
        {
        }

        public EventResponse(string message) : base(message)
        {
        }
    }
}
