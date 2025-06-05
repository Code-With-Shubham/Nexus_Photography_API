using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("PhotoGallery")]
public partial class PhotoGallery
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    public string? Src { get; set; }

    [StringLength(50)]
    public string? Layout { get; set; }

    [StringLength(50)]
    public string? Category { get; set; }

    [StringLength(255)]
    public string? Alt { get; set; }
}
