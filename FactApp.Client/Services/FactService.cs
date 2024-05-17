using FactApp.Shared.Models;
using System.Net.Http.Json;

namespace FactApp.Client.Services
{
    public class FactService(HttpClient http) : IFactService
    {
        public async Task<FactDto> GetFact()
        {
            var response = await http.GetAsync("/api/fact");

            if(response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<FactDto>();

            return new(){ Fact = "No fact found." };
        }
    }
}
