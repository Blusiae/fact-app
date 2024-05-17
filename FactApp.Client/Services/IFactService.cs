using FactApp.Shared.Models;

namespace FactApp.Client.Services
{
    public interface IFactService
    {
        Task<FactDto> GetFact();
    }
}
