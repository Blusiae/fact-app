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
    }
}
