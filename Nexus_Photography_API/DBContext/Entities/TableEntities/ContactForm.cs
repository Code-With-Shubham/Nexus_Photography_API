using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nexus_Photography_API.DBContext.Entities.TableEntities;

[Table("ContactForm")]
public partial class ContactForm
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(150)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public DateOnly? DateOfEvent { get; set; }

    [StringLength(100)]
    public string? EventType { get; set; }

    [StringLength(100)]
    public string? WeddingStyle { get; set; }

    [StringLength(255)]
    public string? Venue { get; set; }

    public int? GuestCount { get; set; }

    [StringLength(100)]
    public string? ReachSource { get; set; }
}
