using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.Response;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository _repository;

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactForm>>> GetContactForms()
        {
            var forms = await _repository.GetContactFormsAsync();
            return Ok(forms);
        }


        [HttpPost]
        public async Task<APIResponse> CreateContactForm([FromBody] ContactFormDTO dto)
        {
            var created = await _repository.AddContactFormAsync(dto);
            if(created == null)
            {
                return new APIResponse
                {
                    Code = 500,
                    Status = "Error",
                    Message = "Failed to add Contact Form"
                };
            }
            else
            {
                return new APIResponse
                {
                    Code = 200,
                    Status = "Success",
                    Message = "Contact Form added successfully",
                    Data = created
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactForm(int id, [FromBody] ContactForm entity)
        {
            if (id != entity.Id) return BadRequest();
            var updated = await _repository.UpdateContactFormAsync(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactForm(int id)
        {
            var deleted = await _repository.DeleteContactFormAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}