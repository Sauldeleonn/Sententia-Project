using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

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

    [ForeignKey("MusicalElementId")]
    [InverseProperty("ArtitsDetail")]
    public virtual MusicalElement MusicalElement { get; set; } = null!;
}
