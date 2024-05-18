using FactApp.Shared.Models;
using System.Net.Http.Json;

namespace FactApp.Client.Services
{
    public class FactService(HttpClient http) : IFactService
    {
        public async Task<FactDto> GetFact()
        {
            var response = await http.GetAsync("/api/Fact/new");

            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FactDto>();
            }

            return new(){ Fact = "No fact found." };
        }

        public async Task<List<FactDto>> GetFacts(int count, int offset)
        {
            var response = await http.GetAsync($"/api/Fact?count={count}&offset={offset}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<FactDto>>();

            return [];
        }

        public async Task<int> GetFactsCount()
        {
            var response = await http.GetAsync("/api/Fact/count");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<int>();

            return 0;
        }
    }
}
