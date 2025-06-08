using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.Response;
using Nexus_Photography_API.Services;

namespace Nexus_Photography_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSayController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClientSayController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientSay>>> GetClientSays()
        {
            var items = await _repository.GetClientSaysAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateClientSay([FromForm] ClientSayDTO dto)
        {
            APIResponse response = new APIResponse();
            var created = await _repository.AddClientSayAsync(dto);
            if (created == null)
            {
                response.Code = 500;
                response.Status = "Error";
                response.Message = "Failed to add Client Say";
                return BadRequest(response);
            }
            else
            {
                response.Code = 200;
                response.Status = "Success";
                response.Message = "Client Say added successfully";
                response.Data = created;
            }

            return Ok(response);
        }
    }
}