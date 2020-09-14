using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IServices
{
    public interface IEventDetailService
    {
        IEnumerable<EventDetail> List();
        Task<EventDetailResponse> AddAsync(EventDetail eventToAdd);
        Task<EventDetailResponse> Update(int id, EventDetail eventToUpdate);
        Task<EventDetailResponse> Delete(int id);
    }
}
