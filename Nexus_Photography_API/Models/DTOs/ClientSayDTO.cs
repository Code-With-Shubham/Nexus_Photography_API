public class ClientSayDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Quote { get; set; }
    public string? Image { get; set; }
    public IFormFile? ImageFile { get; set; } // File input from form-data
}

