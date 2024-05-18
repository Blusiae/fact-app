using FactApp.Shared.Models;

namespace FactApp.Server.Services
{
    public interface IFileService
    {
        Task SaveToFile(string fileName, FactDto fact);
        Task<List<string>> GetLines(int count, int offset);
        int GetLinesCount();
    }
}
