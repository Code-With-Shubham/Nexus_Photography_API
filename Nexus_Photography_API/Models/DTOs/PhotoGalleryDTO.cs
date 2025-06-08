using Microsoft.AspNetCore.Http;

public class PhotoGalleryDTO
{
    public int Id { get; set; }
    public string? Src { get; set; }
    public IFormFile? SrcFile { get; set; }
    public string? Layout { get; set; }
    public string? Category { get; set; }
    public string? Alt { get; set; }
}