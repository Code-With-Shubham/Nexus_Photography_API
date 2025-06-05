using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.Models.Response;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataController> _logger;

        public DataController(IRepository repository, IConfiguration configuration, ILogger<DataController> logger)
        {
            _configuration = configuration;
            _repository = repository;
            _logger = logger;
            _logger.LogInformation("\n\n DataController Logs : \n");
        }

        // Coupleflims

        [HttpGet("CoupleFilms")]
        public async Task<ActionResult<IEnumerable<CoupleFilm>>> GetStudents()
        {
            var CoupleFilms = await _repository.GetCoupleflimsAsync();
            return Ok(CoupleFilms);
        }


        [HttpPost("couplefilms")]
        public async Task<APIResponse> CreateCoupleFilm([FromBody] CoupleFilmsDTO entity)
        {
            var created = await _repository.AddCoupleFilmAsync(entity);
            if (created.Code == 200)
            {
                return created;
            }
            else
            {
                return new APIResponse
                {
                    Code = 500,
                    Message = "Failed to add Couple Film"
                };
            }

        }

        [HttpPut("couplefilms/{id}")]
        public async Task<IActionResult> UpdateCoupleFilm(int id, [FromBody] CoupleFilm entity)
        {
            if (id != entity.Id) return BadRequest();
            var updated = await _repository.UpdateCoupleFilmAsync(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("couplefilms/{id}")]
        public async Task<IActionResult> DeleteCoupleFilm(int id)
        {
            var deleted = await _repository.DeleteCoupleFilmAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        

        // Photogallary

        // CoupleStories

        // CulturalWeddings

        // DestinationWeddings

        // MostPopularFilms

        // MostPopularWeddings

        // PhotographyStyles

        // Testimonials

        // ClientSays

        // ContactForms

        // Admins

        // Add methods for handling requests related to the above entities here



    }
}
