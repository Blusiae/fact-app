using FactApp.Shared.Models;

namespace FactApp.Server.Services
{
    public interface IFileService
    {
        Task SaveToFile(string fileName, FactDto fact);
    }
}
