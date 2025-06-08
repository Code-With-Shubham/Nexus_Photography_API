using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographyStyleController : ControllerBase
    {
        private readonly IRepository _repository;

        public PhotographyStyleController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotographyStyleDTO>>> GetPhotographyStyles()
        {
            var items = await _repository.GetPhotographyStylesAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<PhotographyStyle>> AddPhotographyStyle([FromForm] PhotographyStyleDTO dto)
        {
            var created = await _repository.AddPhotographyStyleAsync(dto);
            return CreatedAtAction(nameof(GetPhotographyStyles), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhotographyStyle(int id, [FromForm] PhotographyStyleDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _repository.UpdatePhotographyStyleAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotographyStyle(int id)
        {
            var deleted = await _repository.DeletePhotographyStyleAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}