using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("ArtitsDetail")]
public partial class ArtitsDetail
{
    [Key]
    public int MusicalElementId { get; set; }

    [StringLength(50)]
    public string RealName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Birthdate { get; set; }

    public bool HasBand { get; set; }

    [InverseProperty("MusicalElement1")]
    public virtual MusicalElement? MusicalElement { get; set; }
}
