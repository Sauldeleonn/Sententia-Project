using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("MusicalElement")]
public partial class MusicalElement
{
    [Key]
    public int MusicalElementId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string Bio { get; set; } = null!;

    public int MusicalElementTypeId { get; set; }

    [InverseProperty("MusicalElement")]
    public virtual ICollection<Link> Links { get; set; } = new List<Link>();

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElement")]
    public virtual ArtitsDetail MusicalElement1 { get; set; } = null!;

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElement")]
    public virtual BandDetail MusicalElement2 { get; set; } = null!;

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElement")]
    public virtual SongDetail MusicalElement3 { get; set; } = null!;

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElement")]
    public virtual AlbumDetail MusicalElementNavigation { get; set; } = null!;

    [ForeignKey("MusicalElementTypeId")]
    [InverseProperty("MusicalElements")]
    public virtual MusicalElementType MusicalElementType { get; set; } = null!;

    [InverseProperty("MusicalElement")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElements")]
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElements")]
    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElements")]
    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    [ForeignKey("MusicalElementId")]
    [InverseProperty("MusicalElements")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
