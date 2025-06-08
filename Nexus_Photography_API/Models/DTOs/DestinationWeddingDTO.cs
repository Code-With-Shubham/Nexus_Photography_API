using Microsoft.AspNetCore.Http;

namespace Nexus_Photography_API.Models.DTOs
{
    public class DestinationWeddingDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateOnly? Date { get; set; }
    }
}