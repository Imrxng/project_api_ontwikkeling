using Ghaddoura_Imran_Project.Models;
using Ghaddoura_Imran_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ghaddoura_Imran_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversitiesController([FromServices] IUniversityService universityService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllUniversities()
        {
            var universities = await universityService.GetAllUniversities();
            if (universities is null)
            {
                return NotFound();
            }
            return Ok(universities);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetOneUniversity([FromRoute] Guid id)
        {
            var university = await universityService.GetOneUniversity(id);
            if (university is null)
            {
                return NotFound();
            }

            return Ok(university);
        }

        [HttpGet("{location:alpha}")]
        public async Task<ActionResult> GetUniversitiesFromLocation([FromRoute] string location)
        {
            var universities = await universityService.GetUniversitiesFromLocation(location);
            if (universities.Count == 0)
            {
                return NotFound();
            }
            return Ok(universities);
        }

        [HttpPost]
        public async Task<ActionResult> AddUniversity([FromBody] University university)
        {
            await universityService.AddUniversity(university);
            return CreatedAtAction(nameof(GetOneUniversity), new { id = university.Id }, university);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> DeleteUniversity([FromBody] University item, [FromRoute] Guid id)
        {
            if (item.Id != id)
            {
                return BadRequest();
            }

            var university = await universityService.UpdateUniversity(item);

            if (university is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteUniversity(Guid id)
        {
            var university = await GetOneUniversity(id);
            if (university is null)
            {
                return NotFound();
            }
            await universityService.DeleteUniversity(id);
            return NoContent();
        }
    }
}
