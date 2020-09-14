using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HollywoodTest.Domain.IRepositories;
using HollywoodTest.Domain.Models;
using HollywoodTest.Persistence.Contexts;

namespace HollywoodTest.Persistence.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository(AppDbContext context) : base(context)
        {
        }

        public  IEnumerable<Tournament> ListAsync()
        {
            return _context.Tournaments.ToList();
        }

        public async Task AddAsync(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
        }

        public async Task<Tournament> FindByIdAsync(long id)
        {
           return await _context.Tournaments.FindAsync(id);
        }

        public void Update(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
        }

        public void Delete(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
        }
    }
}
