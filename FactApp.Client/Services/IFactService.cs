using FactApp.Shared.Models;

namespace FactApp.Client.Services
{
    public interface IFactService
    {
        Task<FactDto> GetFact();
        Task<List<FactDto>> GetFacts(int count, int offset);
        Task<int> GetFactsCount();
    }
}
