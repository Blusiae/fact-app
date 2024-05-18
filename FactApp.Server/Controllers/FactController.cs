using FactApp.Server.Services;
using FactApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController(IFactService _factService, IFileService _fileService) : ControllerBase
    {
        [HttpGet("/api/[controller]/new")]
        public async Task<ActionResult<FactDto>> GetFact()
        {
            var fact = await _factService.GetFact();

            if(fact is null)
                return NotFound();

            return Ok(fact);
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetFacts([FromQuery]int count, [FromQuery]int offset)
        {
            var facts = await _factService.GetFacts(count, offset);

            if (facts is null)
                return NotFound();

            return Ok(facts);
        }

        [HttpGet("/api/[controller]/count")]
        public ActionResult<int> GetFactsCount()
        {
            return _fileService.GetLinesCount();
        }
    }
}
