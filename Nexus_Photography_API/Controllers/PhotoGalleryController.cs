using Microsoft.AspNetCore.Mvc;
using Nexus_Photography_API.Services;
using Nexus_Photography_API.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PhotoGalleryController : ControllerBase
{
    private readonly IRepository _repository;

    public PhotoGalleryController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPhotoGalleries()
    {
        var result = await _repository.GetPhotoGalleriesAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddPhotoGallery([FromForm] PhotoGalleryDTO dto)
    {
        var result = await _repository.AddPhotoGalleryAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePhotoGallery([FromForm] PhotoGalleryDTO dto)
    {
        var success = await _repository.UpdatePhotoGalleryAsync(dto);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhotoGallery(int id)
    {
        var success = await _repository.DeletePhotoGalleryAsync(id);
        if (!success) return NotFound();
        return Ok();
    }
}