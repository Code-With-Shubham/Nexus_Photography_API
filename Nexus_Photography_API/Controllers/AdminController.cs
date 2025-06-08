using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IRepository repository, IConfiguration configuration, ILogger<AdminController> logger)
        {
            _configuration = configuration;
            _repository = repository;
            _logger = logger;
            _logger.LogInformation("\n\n AdminController Logs : \n");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAdmins()
        {
            var admins = await _repository.GetAdminsAsync();
            return Ok(admins);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> AddAdmin([FromBody] AdminDTO dto)
        {
            var created = await _repository.AddAdminAsync(dto);
            return CreatedAtAction(nameof(GetAdmins), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var deleted = await _repository.DeleteAdminAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
