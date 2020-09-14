using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.IServices.Communication;
using HollywoodTest.Domain.Models;

namespace HollywoodTest.Domain.IServices
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> ListAsync();
        Task<TournamentResponse> SaveAsync(Tournament tournament);
        Task<TournamentResponse> UpdateAsync(int id, Tournament tournament);
        Task<TournamentResponse> DeleteAsync(int id);
    }
}
