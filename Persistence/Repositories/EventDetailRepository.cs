using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using HollywoodTest.Domain.IRepositories;
using HollywoodTest.Domain.Models;
using HollywoodTest.Persistence.Contexts;

namespace HollywoodTest.Persistence.Repositories
{
    public class EventDetailRepository : BaseRepository, IEventDetailRepository
    {
        public EventDetailRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<EventDetail> List()
        {
            return _context.EventDetails.Include(e => e.Event)
                .Include(x => x.EventDetailStatus).AsNoTracking();
        }

        public async Task Add(EventDetail eventDetail)
        {
            await _context.EventDetails.AddAsync(eventDetail);
        }

        public async Task<EventDetail> FindByIdAsync(long id)
        {
            return await _context.EventDetails.Include(e => e.Event)
                        .Include(x => x.EventDetailStatus)
                        .FirstOrDefaultAsync(x => x.EventDetailId == id);
        }

        public  void Update(EventDetail eventDetail)
        {
            _context.EventDetails.Update(eventDetail);
        }

        public void Delete(EventDetail eventDetail)
        {
            _context.EventDetails.Remove(eventDetail);
        }
    }
}
