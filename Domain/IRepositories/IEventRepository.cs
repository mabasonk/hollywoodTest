using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IRepositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> List();
        Task Add(Event eventToAdd);
        Task<Event> FindByIdAsync(long id);
        void Update(Event enventToUpdate);
        void Delete(Event eventToDelete);
    }
}
