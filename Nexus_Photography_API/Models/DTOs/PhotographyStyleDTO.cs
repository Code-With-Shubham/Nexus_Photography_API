public class PhotographyStyleDTO
{
    public int Id { get; set; }
    public string? Src { get; set; }
    public IFormFile? SrcFile { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}