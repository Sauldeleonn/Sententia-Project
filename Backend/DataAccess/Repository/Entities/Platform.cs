using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("Platform")]
public partial class Platform
{
    [Key]
    public int PlatformId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Platform")]
    public virtual ICollection<Link> Links { get; set; } = new List<Link>();
}
