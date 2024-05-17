using FactApp.Server.Services;
using FactApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController(HttpClient http, IFileService fs) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FactDto>> GetFact()
        {
            var response = await http.GetAsync("https://catfact.ninja/fact");
            var fact = await response.Content.ReadFromJsonAsync<FactDto>();

            if(fact is null)
                return NotFound();

            await fs.SaveToFile("facts.txt", fact);
            return Ok(fact);
        }
    }
}
