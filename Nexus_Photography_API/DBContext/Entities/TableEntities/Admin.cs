using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("Admin")]
[Index("Username", Name = "UQ__Admin__536C85E481D18D03", IsUnique = true)]
[Index("Pswd", Name = "UQ__Admin__A5C0E110BE19440D", IsUnique = true)]
public partial class Admin
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Pswd { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Type { get; set; }
}
