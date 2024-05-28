using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("SongDetail")]
public partial class SongDetail
{
    [Key]
    public int MusicalElementId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleaseDate { get; set; }

    [ForeignKey("MusicalElementId")]
    [InverseProperty("SongDetail")]
    public virtual MusicalElement MusicalElement { get; set; } = null!;
}
