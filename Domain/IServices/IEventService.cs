using System.Collections.Generic;
using System.Threading.Tasks;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IServices
{
    public interface IEventService
    {
        IEnumerable<Event> List();
        Task<EventResponse> AddAsync(Event eventToAdd);
        Task<EventResponse> Update(int id, Event eventToUpdate); 
        Task<EventResponse> Delete(int id);
    }
}
