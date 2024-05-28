using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("Genre")]
public partial class Genre
{
    [Key]
    public int GenreId { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [ForeignKey("GenreId")]
    [InverseProperty("Genres")]
    public virtual ICollection<MusicalElement> MusicalElements { get; set; } = new List<MusicalElement>();
}
