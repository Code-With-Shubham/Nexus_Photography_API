using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

public partial class CoupleFilm
{
    [Key]
    public int Id { get; set; }

    public byte[]? Thumbnail { get; set; }

    [StringLength(500)]
    public string? YoutubeLink { get; set; }
}
