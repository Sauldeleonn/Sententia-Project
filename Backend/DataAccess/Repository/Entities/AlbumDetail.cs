using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("AlbumDetail")]
public partial class AlbumDetail
{
    [Key]
    public int MusicalElementId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleaseDate { get; set; }

    [InverseProperty("MusicalElementNavigation")]
    public virtual MusicalElement? MusicalElement { get; set; }
}
