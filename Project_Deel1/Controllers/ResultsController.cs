using Ghaddoura_Imran_Project.Models;
using Ghaddoura_Imran_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ghaddoura_Imran_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController([FromServices] IResultsService resultsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Result>>> GetAllResults()
        {
            var courses = await resultsService.GetAllResults();
            if (courses is null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Result?>> GetSingleResultDetails(Guid id)
        {
            var course = await resultsService.GetSingleResultDetails(id);
            if (course is null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> AddResult(Result result)
        {
            await resultsService.AddResult(result);
            return CreatedAtAction(nameof(GetSingleResultDetails), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateResult([FromBody] Result item, [FromRoute] Guid id)
        {
            if (item.Id != id)
            {
                return BadRequest("ID in body does not match ID in route.");
            }

            var result = await resultsService.UpdateResult(item);

            if (result is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteResult(Guid id)
        {
            var result = await GetSingleResultDetails(id);
            if (result is null)
            {
                return NotFound();
            }
            await resultsService.DeleteResult(id);
            return NoContent();
        }
    }
}
