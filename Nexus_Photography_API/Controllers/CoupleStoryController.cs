using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.Response;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupleStoryController : ControllerBase
    {
        private readonly IRepository _repository;

        public CoupleStoryController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoupleStory>>> GetCoupleStories()
        {
            var stories = await _repository.GetCoupleStoriesAsync();
            return Ok(stories);
        }

        [HttpPost]
        public async Task<APIResponse> CreateCoupleStory([FromForm] CoupleStoryDTO dto)
        {
            var created = await _repository.AddCoupleStoryAsync(dto);
        
            if (created == null)
            {
                return new APIResponse
                {
                    Code = 500,
                    Status = "Error",
                    Message = "Failed to add Couple Story"
                };
            }
            else
            {
                return new APIResponse
                {
                    Code = 200,
                    Status = "Success",
                    Message = "Couple Story added successfully",
                    Data = created
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoupleStory(int id, [FromForm] CoupleStoryDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _repository.UpdateCoupleStoryAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupleStory(int id)
        {
            var deleted = await _repository.DeleteCoupleStoryAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}