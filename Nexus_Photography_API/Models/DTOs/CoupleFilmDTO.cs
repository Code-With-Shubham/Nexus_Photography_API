public class CoupleFilmDTO
{
    public int Id { get; set; }
    public string? Thumbnail { get; set; }
    public IFormFile? ThumbnailFile { get; set; } // File input from form-data
    public string? YoutubeLink { get; set; }
}