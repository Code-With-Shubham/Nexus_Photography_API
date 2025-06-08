using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("PhotographyStyle")]
public partial class PhotographyStyle
{
    [Key]
    public int Id { get; set; }

    public byte[]? Src { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }
}
