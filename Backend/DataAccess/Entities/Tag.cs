using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("Tag")]
public partial class Tag
{
    [Key]
    public int TagId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [ForeignKey("TagId")]
    [InverseProperty("Tags")]
    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    [ForeignKey("TagId")]
    [InverseProperty("Tags")]
    public virtual ICollection<MusicalElement> MusicalElements { get; set; } = new List<MusicalElement>();
}
