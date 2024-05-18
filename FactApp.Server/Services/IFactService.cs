using FactApp.Shared.Models;

namespace FactApp.Server.Services
{
    public interface IFactService
    {
        Task<FactDto?> GetFact();
    }
}
