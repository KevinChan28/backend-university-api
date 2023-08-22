using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpEventRepository : IEventRepository
    {
        UniversityDb2Context _universityDB;

        public ImpEventRepository(UniversityDb2Context universityDB)
        {
            _universityDB = universityDB;
        }


        public async Task<int> RegisterEvent(Event eventNew)
        {
            EntityEntry<Event> newEvent = _universityDB.Events.Add(eventNew);
            await _universityDB.SaveChangesAsync();

            return newEvent.Entity.Id;
        }
    }
}
