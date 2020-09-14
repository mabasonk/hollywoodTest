using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IRepositories
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> ListAsync();
        Task AddAsync(Tournament tournament);
        Task<Tournament> FindByIdAsync(long id);
        void Update(Tournament tournament);
        void Delete(Tournament tournament);
    }
}
