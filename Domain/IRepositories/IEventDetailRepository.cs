using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IRepositories
{
    public interface IEventDetailRepository
    {
        IEnumerable<EventDetail> List();
        Task Add(EventDetail eventDetail);
        Task<EventDetail> FindByIdAsync(long id);
        void Update(EventDetail eventDetail);
        void Delete(EventDetail eventDetail);
    }
}
