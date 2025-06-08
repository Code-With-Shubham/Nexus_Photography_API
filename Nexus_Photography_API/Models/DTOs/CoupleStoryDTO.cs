public class CoupleStoryDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? Location { get; set; }
    public DateOnly? Date { get; set; }
}