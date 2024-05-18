using FactApp.Shared.Models;

namespace FactApp.Server.Services
{
    public class FactService(HttpClient http, IFileService _fileService) : IFactService
    {
        public async Task<FactDto?> GetFact()
        {
            var response = await http.GetAsync("https://catfact.ninja/fact");
            var fact = await response.Content.ReadFromJsonAsync<FactDto>();

            if(fact is null)
                return null;

            await _fileService.SaveToFile("facts.txt", fact);
            return fact;
        }

        public async Task<List<FactDto>> GetFacts(int count, int offset)
        {
            var lines = await _fileService.GetLines(count, offset);

            var facts = lines.Select(l =>
            {
                var splittedLine = l.Split(";?;");
                return new FactDto { Fact = splittedLine[0], Length = int.Parse(splittedLine[1]) };
            }).ToList();

            return facts;
        }
    }
}
