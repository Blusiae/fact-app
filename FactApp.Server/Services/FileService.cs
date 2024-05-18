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

            await sw.WriteLineAsync($"{fact.Fact};?; {fact.Length}");
        }

        public async Task<List<string>> GetLines(int count, int offset)
        {
            using FileStream fs = File.Open($"{_path}/facts.txt", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            var fileContent = await sr.ReadToEndAsync();

            var lines = fileContent.Split("\n")
                .Skip(offset)
                .Take(count)
                .ToList();

            lines.RemoveAll(string.IsNullOrEmpty); // Remove empty lines

            return lines;
        }

        public int GetLinesCount()
        {
            using FileStream fs = File.Open($"{_path}/facts.txt", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            var count = 0;
            while (sr.ReadLine() is not null)
                count++;

            return count;
        }

    }
}
