using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("Testimonial")]
public partial class Testimonial
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? CoupleName { get; set; }

    public byte[]? Thumbnail { get; set; }

    [StringLength(500)]
    public string? VideoLink { get; set; }

    [Column(TypeName = "text")]
    public string? Quote { get; set; }
}
