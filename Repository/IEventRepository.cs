namespace Api_backend_university.Repository
{
    public interface IEventRepository
    {
        Task<int> RegisterEvent(Event eventNew);
    }
}
