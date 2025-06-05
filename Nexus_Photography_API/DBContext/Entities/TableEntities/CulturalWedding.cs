using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("CulturalWedding")]
public partial class CulturalWedding
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Image { get; set; }

    [StringLength(500)]
    public string? ReadBlogs { get; set; }
}
