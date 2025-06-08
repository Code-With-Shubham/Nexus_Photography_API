using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Services;
using Nexus_Photography_API.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class DestinationWeddingController : ControllerBase
{
    private readonly IRepository _repository;

    public DestinationWeddingController(IRepository repository)
    {
        _repository = repository;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetDestinationWeddings()
    //{
    //    var result = await _repository.GetDestinationWeddingsAsync();
    //    return Ok(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> AddDestinationWedding([FromForm] DestinationWeddingDTO dto)
    //{
    //    var result = await _repository.AddDestinationWeddingAsync(dto);
    //    return Ok(result);
    //}

    //[HttpPut]
    //public async Task<IActionResult> UpdateDestinationWedding([FromForm] DestinationWeddingDTO dto)
    //{
    //    var success = await _repository.UpdateDestinationWeddingAsync(dto);
    //    if (!success) return NotFound();
    //    return Ok();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteDestinationWedding(int id)
    //{
    //    var success = await _repository.DeleteDestinationWeddingAsync(id);
    //    if (!success) return NotFound();
    //    return Ok();
    //}
}