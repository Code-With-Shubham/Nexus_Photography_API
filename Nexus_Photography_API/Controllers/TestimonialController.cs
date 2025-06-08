using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Services;
using Nexus_Photography_API.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class TestimonialController : ControllerBase
{
    private readonly IRepository _repository;

    public TestimonialController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTestimonials()
    {
        var result = await _repository.GetTestimonialsAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddTestimonial([FromForm] TestimonialDTO dto)
    {
        var result = await _repository.AddTestimonialAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial([FromForm] TestimonialDTO dto)
    {
        var success = await _repository.UpdateTestimonialAsync(dto);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        var success = await _repository.DeleteTestimonialAsync(id);
        if (!success) return NotFound();
        return Ok();
    }
}