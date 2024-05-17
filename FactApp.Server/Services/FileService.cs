using FactApp.Shared.Models;

namespace FactApp.Server.Services
{
    public class FileService : IFileService
    {
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        public async Task SaveToFile(string fileName, FactDto fact)
        {
            using FileStream fs = File.Open($"{_path}/{fileName}", FileMode.Append);
            using StreamWriter sw = new(fs);

            await sw.WriteLineAsync(fact.Fact);
        }
    }
}
