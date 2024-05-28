using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("Link")]
public partial class Link
{
    [Key]
    public int LinkId { get; set; }

    [Column("Link")]
    [StringLength(300)]
    public string Link1 { get; set; } = null!;

    public int MusicalElementId { get; set; }

    public int PlatformId { get; set; }

    [ForeignKey("MusicalElementId")]
    [InverseProperty("Links")]
    public virtual MusicalElement MusicalElement { get; set; } = null!;

    [ForeignKey("PlatformId")]
    [InverseProperty("Links")]
    public virtual Platform Platform { get; set; } = null!;
}
