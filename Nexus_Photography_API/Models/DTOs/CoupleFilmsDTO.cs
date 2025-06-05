using System.ComponentModel.DataAnnotations;

namespace Nexus_Photography_API.Models.DTOs
{
    public class CoupleFilmsDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string? Thumbnail { get; set; }

        [StringLength(500)]
        public string? YoutubeLink { get; set; }
    }
}
