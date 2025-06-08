using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CulturalWeddingController : ControllerBase
    {
        private readonly IRepository _repository;
        public CulturalWeddingController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CulturalWeddingDTO>>> GetAll()
        {
            var items = await _repository.GetCulturalWeddingsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CulturalWeddingDTO dto)
        {
            var created = await _repository.AddCulturalWeddingAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CulturalWeddingDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _repository.UpdateCulturalWeddingAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteCulturalWeddingAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}