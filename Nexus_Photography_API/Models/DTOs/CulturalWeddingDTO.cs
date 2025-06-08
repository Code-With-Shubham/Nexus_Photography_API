using Microsoft.AspNetCore.Http;

public class CulturalWeddingDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ReadBlogs { get; set; }
}