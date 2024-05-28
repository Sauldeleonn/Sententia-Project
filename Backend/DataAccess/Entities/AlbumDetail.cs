using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("AlbumDetail")]
public partial class AlbumDetail
{
    [Key]
    public int MusicalElementId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleaseDate { get; set; }

    [ForeignKey("MusicalElementId")]
    [InverseProperty("AlbumDetail")]
    public virtual MusicalElement MusicalElement { get; set; } = null!;
}
